using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Repositories;
using Org.Strausshome.FS.CrewSoundsNG.Services;

using System;
using System.Windows.Forms;

namespace Org.Strausshome.FS.CrewSoundsNG
{
    public partial class SettingsView : Form
    {
        #region Private Fields

        private readonly ILogger<SettingsView> _logger;
        private readonly MediaService _mediaService;
        private readonly SettingsRepository _settingsRepository;
        private bool _loader;

        #endregion Private Fields

        #region Public Constructors

        public SettingsView(ILogger<SettingsView> logger, SettingsRepository settingsRepository, MediaService mediaService)
        {
            InitializeComponent();

            _logger = logger;
            _settingsRepository = settingsRepository;
            _mediaService = mediaService;
        }

        #endregion Public Constructors

        #region Private Methods

        private async void AmbianceVolume_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetAmbianceVolume(Convert.ToInt32(AmbianceVolume.Value)).ConfigureAwait(false);
                _mediaService.SetVolume(Convert.ToSingle(AmbianceVolume.Value), AudioType.Ambiance);
            }
        }

        private async void AnnouncementVolume_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetAnnouncementVolume(Convert.ToInt32(AnnouncementVolume.Value)).ConfigureAwait(false);
                _mediaService.SetVolume(Convert.ToSingle(AnnouncementVolume.Value), AudioType.Announcement);
            }
        }

        private async void AutoSeatbelts_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSeatbelts.Checked)
            {
                SeatbeltAutoOff.Enabled = true;
                SeatbeltAutoOn.Enabled = true;
            }
            else
            {
                SeatbeltAutoOff.Enabled = false;
                SeatbeltAutoOn.Enabled = false;
            }

            await _settingsRepository.SetAutoSeatbelt(AutoSeatbelts.Checked);
        }

        private async void HighPassFreq_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetSoundHighPass(Convert.ToSingle(HighPassFreq.Value)).ConfigureAwait(false);
            }
        }

        private async void HighPassGain_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetSoundHighPassGain(Convert.ToSingle(HighPassGain.Value)).ConfigureAwait(false);
            }
        }

        private async void LowPassFreq_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetSoundLowPass(Convert.ToSingle(LowPassFreq.Value)).ConfigureAwait(false);
            }
        }

        private async void LowPassGain_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetSoundLowPassGain(Convert.ToSingle(LowPassGain.Value)).ConfigureAwait(false);
            }
        }

        private async void MusicVolume_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetMusicVolume(Convert.ToInt32(MusicVolume.Value)).ConfigureAwait(false);
                _mediaService.SetVolume(Convert.ToSingle(MusicVolume.Value), AudioType.Music);
            }
        }

        private void OpenSoundProfiles_Click(object sender, EventArgs e)
        {
            var sound = (Form)Program.ServiceProvider.GetService((typeof(SoundProfileView)));
            sound.ShowDialog();
        }

        private async void SeatbeltAutoOff_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetSeatbeltsAutoOffAltitude(Convert.ToInt32(SeatbeltAutoOff.Value)).ConfigureAwait(false);
            }
        }

        private async void SeatbeltAutoOn_ValueChanged(object sender, EventArgs e)
        {
            if (!_loader)
            {
                await _settingsRepository.SetSeatbeltsAutoOnAltitude(Convert.ToInt32(SeatbeltAutoOn.Value)).ConfigureAwait(false);
            }
        }

        private async void SettingsView_Load(object sender, EventArgs e)
        {
            _loader = true;
            SeatbeltAutoOff.Value = await _settingsRepository.GetSeatbeltsAutoOffAltitude().ConfigureAwait(false);
            SeatbeltAutoOn.Value = await _settingsRepository.GetSeatbeltsAutoOnAltitude().ConfigureAwait(false);
            AmbianceVolume.Value = await _settingsRepository.GetAmbianceVolume().ConfigureAwait(false);
            MusicVolume.Value = await _settingsRepository.GetMusicVolume().ConfigureAwait(false);
            UseDoorfEffect.Checked = await _settingsRepository.GetDoorEffect().ConfigureAwait(false);
            LowPassFreq.Value = (decimal)await _settingsRepository.GetSoundLowPass().ConfigureAwait(false);
            HighPassFreq.Value = (decimal)await _settingsRepository.GetSoundHighPass().ConfigureAwait(false);
            LowPassGain.Value = (decimal)await _settingsRepository.GetSoundLowPassGain().ConfigureAwait(false);
            HighPassGain.Value = (decimal)await _settingsRepository.GetSoundHighPassGain().ConfigureAwait(false);
            AnnouncementVolume.Value = await _settingsRepository.GetAnnouncementVolume().ConfigureAwait(false);

            AutoSeatbelts.Checked = await _settingsRepository.GetAutoSeatbelt().ConfigureAwait(false);
            if (AutoSeatbelts.Checked)
            {
                SeatbeltAutoOff.Enabled = true;
                SeatbeltAutoOn.Enabled = true;
            }
            else
            {
                SeatbeltAutoOff.Enabled = false;
                SeatbeltAutoOn.Enabled = false;
            }

            _loader = false;
        }

        private async void UseDoorfEffect_CheckedChangedAsync(object sender, EventArgs e)
        {
            if (UseDoorfEffect.Checked)
            {
                LowPassFreq.Enabled = true;
                LowPassGain.Enabled = true;
                HighPassFreq.Enabled = true;
                HighPassGain.Enabled = true;
                await _settingsRepository.SetDoorEffect(true);
            }
            else
            {
                LowPassFreq.Enabled = false;
                LowPassGain.Enabled = false;
                HighPassFreq.Enabled = false;
                HighPassGain.Enabled = false;
                await _settingsRepository.SetDoorEffect(false);
            }
        }

        #endregion Private Methods
    }
}