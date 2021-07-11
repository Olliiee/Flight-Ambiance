using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Models;
using Org.Strausshome.FS.CrewSoundsNG.Repositories;

using Un4seen.Bass;
using Un4seen.Bass.AddOn.Fx;

namespace Org.Strausshome.FS.CrewSoundsNG.Services
{
    public enum AudioType
    {
        Ambiance,
        Announcement,
        Music
    }

    public class MediaService
    {
        #region Private Fields

        private readonly System.Timers.Timer _audioCheck = new();
        private readonly ILogger<MediaService> _logger;
        private readonly Random _random = new();
        private readonly SettingsRepository _settingsRepository;
        private ProfileItem _profileItem;
        private int bassAmbianceChannel = 1;
        private int bassAnnouncementChannel = 3;
        private int bassMusicChannel = 2;
        private int filter = 5;

        #endregion Private Fields

        #region Public Constructors

        public MediaService(ILogger<MediaService> logger, SettingsRepository settingsRepository)
        {
            _logger = logger;
            _settingsRepository = settingsRepository;

            _audioCheck.Interval = 5000;
            _audioCheck.Elapsed += AudioCheck_Elapsed;
        }

        #endregion Public Constructors

        #region Public Methods

        public void SetHandle(IntPtr Handle)
        {
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Handle);
            BassFx.LoadMe();
            BassFx.BASS_FX_GetVersion();
        }

        public void SetProfileItem(ProfileItem profileItem)
        {
            _audioCheck.Stop();
            _profileItem = profileItem;
            _audioCheck.Start();
        }

        public void SetVolume(float volume, AudioType audioType)
        {
            volume /= 100;
            switch (audioType)
            {
                case AudioType.Ambiance:
                    Bass.BASS_ChannelSetAttribute(bassAmbianceChannel, BASSAttribute.BASS_ATTRIB_VOL, volume);
                    break;

                case AudioType.Announcement:
                    Bass.BASS_ChannelSetAttribute(bassAnnouncementChannel, BASSAttribute.BASS_ATTRIB_VOL, volume);
                    break;

                case AudioType.Music:
                    Bass.BASS_ChannelSetAttribute(bassMusicChannel, BASSAttribute.BASS_ATTRIB_VOL, volume);
                    break;

                default:
                    break;
            }
        }

        public async Task StartAmbiance(ProfileItem profileItem)
        {
            var mediaFiles = profileItem.MediaFile.Where(m => m.Type == MediaType.Ambiance).ToList();
            if (mediaFiles != null && mediaFiles.Count > 0)
            {
                int randomNumber = _random.Next(0, mediaFiles.Count);
                var mediaFile = mediaFiles.Skip(randomNumber).Take(1).FirstOrDefault();
                var status = Bass.BASS_ChannelIsActive(bassAmbianceChannel);
                if (Bass.BASS_ChannelIsActive(bassAmbianceChannel) == BASSActive.BASS_ACTIVE_STOPPED)
                {
                    float volume = GetVolume(Convert.ToSingle(await _settingsRepository.GetAmbianceVolume()), profileItem.FlightStatus.IsEngineRun);
                    bassAmbianceChannel = await PlayAudioFileAsync(mediaFile.Path, bassAmbianceChannel, profileItem.FlightStatus.IsDoorOpen, volume);
                }
            }
        }

        public async Task StartAnnouncement(ProfileItem profileItem)
        {
            var mediaFiles = profileItem.MediaFile.Where(m => m.Type == MediaType.Announcement).OrderBy(m => m.MediaFileId).ToList();

            foreach (var file in mediaFiles)
            {
                StopSound(bassMusicChannel);
                while (Bass.BASS_ChannelIsActive(bassAnnouncementChannel) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    await Task.Delay(100);
                }

                await Wait();
                float volume = GetVolume(Convert.ToSingle(await _settingsRepository.GetAmbianceVolume()), profileItem.FlightStatus.IsEngineRun);
                bassAnnouncementChannel = await PlayAudioFileAsync(file.Path, bassAnnouncementChannel, profileItem.FlightStatus.IsDoorOpen, volume);
            }
        }

        public async Task StartMusic(ProfileItem profileItem)
        {
            var mediaFiles = profileItem.MediaFile.Where(m => m.Type == MediaType.Music).ToList();
            if (mediaFiles != null && mediaFiles.Count > 0)
            {
                int randomNumber = _random.Next(0, mediaFiles.Count);
                var mediaFile = mediaFiles.Skip(randomNumber).Take(1).FirstOrDefault();
                var status = Bass.BASS_ChannelIsActive(bassMusicChannel);
                if (Bass.BASS_ChannelIsActive(bassMusicChannel) == BASSActive.BASS_ACTIVE_STOPPED)
                {
                    float volume = GetVolume(Convert.ToSingle(await _settingsRepository.GetMusicVolume()), profileItem.FlightStatus.IsEngineRun);
                    bassMusicChannel = await PlayAudioFileAsync(mediaFile.Path, bassMusicChannel, profileItem.FlightStatus.IsDoorOpen, volume);
                }
            }
        }

        public void StopAll()
        {
            StopSound(bassMusicChannel);
            StopSound(bassAmbianceChannel);
            StopSound(bassAnnouncementChannel);
        }

        #endregion Public Methods

        #region Private Methods

        private static float GetVolume(float volume, bool isEngineRun) => isEngineRun ? (volume / 50) : (volume / 100);

        private async void AudioCheck_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _audioCheck.Stop();
            await StartAmbiance(_profileItem);
            await StartMusic(_profileItem);
            _audioCheck.Start();
        }

        private async Task<int> PlayAudioFileAsync(string audioFile, int audioChannel, bool IsDoorOpen, float volume)
        {
            if (File.Exists(audioFile))
            {
                _logger.LogDebug($@"Playing ambiance {audioFile}");
                if (Bass.BASS_ChannelIsActive(audioChannel) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    Bass.BASS_ChannelSlideAttribute(0, BASSAttribute.BASS_ATTRIB_VOL, 0f, 1000);
                }

                audioChannel = Bass.BASS_StreamCreateFile($@"{audioFile}", 0L, 0L, BASSFlag.BASS_MUSIC_AUTOFREE);

                if (!IsDoorOpen && await _settingsRepository.GetDoorEffect())
                {
                    _logger.LogDebug("Setting lowpass filter.");
                    filter = Bass.BASS_ChannelSetFX(audioChannel, BASSFXType.BASS_FX_BFX_BQF, 0);

                    BASS_BFX_BQF filterSettings = new();
                    filterSettings.lFilter = BASSBFXBQF.BASS_BFX_BQF_LOWPASS;
                    filterSettings.fCenter = await _settingsRepository.GetSoundLowPass().ConfigureAwait(false);
                    filterSettings.fGain = await _settingsRepository.GetSoundLowPassGain().ConfigureAwait(false);
                    filterSettings.lChannel = BASSFXChan.BASS_BFX_CHANALL;

                    var result = Bass.BASS_FXSetParameters(filter, filterSettings);
                    if (!result)
                    {
                        _logger.LogError($"BASS Error {Bass.BASS_ErrorGetCode()}");
                    }

                    volume -= 5;
                }

                Bass.BASS_ChannelSetAttribute(audioChannel, BASSAttribute.BASS_ATTRIB_VOL, volume);

                if (Bass.BASS_ChannelIsActive(audioChannel) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    Bass.BASS_ChannelSlideAttribute(audioChannel, BASSAttribute.BASS_ATTRIB_VOL, volume, 1000);
                    if (!Bass.BASS_ChannelPlay(audioChannel, false))
                    {
                        _logger.LogError($"Error playing file: {Bass.BASS_ErrorGetCode()}");
                    }
                }
                else
                {
                    if (!Bass.BASS_ChannelPlay(audioChannel, false))
                    {
                        _logger.LogError($"Error playing file: {Bass.BASS_ErrorGetCode()}");
                    }
                }
            }
            else
            {
                _logger.LogError($@"Error file doesn't exists. {audioFile}");
            }

            return audioChannel;
        }

        private void StopSound(int channel)
        {
            try
            {
                Bass.BASS_ChannelSlideAttribute(channel, BASSAttribute.BASS_ATTRIB_VOL, 0f, 1000);
            }
            catch (Exception)
            {
                _logger.LogError($"Error stopping channel.");
            }
        }

        private async Task Wait()
        {
            int randomNumber = _random.Next(35, 100);
            for (int i = 0; i < randomNumber; i++)
            {
                await Task.Delay(100);
            }
        }

        #endregion Private Methods
    }
}