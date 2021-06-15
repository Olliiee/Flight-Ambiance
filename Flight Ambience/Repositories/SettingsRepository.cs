using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Data;
using Org.Strausshome.FS.CrewSoundsNG.Models;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Org.Strausshome.FS.CrewSoundsNG.Repositories
{
    public class SettingsRepository
    {
        #region Private Fields

        private readonly CsContext _csContext;
        private readonly ILogger<FlightStatusRepository> _logger;

        #endregion Private Fields

        #region Public Constructors

        public SettingsRepository(ILogger<FlightStatusRepository> logger, CsContext csContext)
        {
            _logger = logger;
            _csContext = csContext;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> GetAmbianceVolume()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Ambiance).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting == null)
            {
                await SetAmbianceVolume(30);
                return 30;
            }
            else
            {
                return Convert.ToInt32(setting.Value);
            }
        }

        public async Task<int> GetAnnouncementVolume()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Announcement).FirstOrDefaultAsync().ConfigureAwait(false);

            if (setting == null)
            {
                await SetAnnouncementVolume(15);
                return 15;
            }
            else
            {
                return Convert.ToInt32(setting.Value);
            }
        }

        public async Task<bool> GetAutoSeatbelt()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Seatbelt).FirstOrDefaultAsync().ConfigureAwait(false);

            if (setting == null)
            {
                await SetAutoSeatbelt(false);
                return false;
            }
            else
            {
                if (setting.Value == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public async Task<int> GetDevice()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Device).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting == null)
            {
                await SetDevice(0);
                return 0;
            }
            else
            {
                return Convert.ToInt32(setting.Value);
            }
        }

        public async Task<bool> GetDoorEffect()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.DoorEffect).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting == null)
            {
                await SetDoorEffect(true);
                return true;
            }
            else
            {
                if (setting.Value == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public async Task<int> GetMusicVolume()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Music).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting == null)
            {
                await SetMusicVolume(5);
                return 5;
            }
            else
            {
                return Convert.ToInt32(setting.Value);
            }
        }

        public async Task<int> GetSeatbeltsAutoOffAltitude()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.SeatbeltsOff).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting == null)
            {
                await SetSeatbeltsAutoOffAltitude(12100);
                return 12100;
            }
            else
            {
                return Convert.ToInt32(setting.Value);
            }
        }

        public async Task<int> GetSeatbeltsAutoOnAltitude()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.SeatbeltsOn).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting == null)
            {
                await SetSeatbeltsAutoOnAltitude(12000);
                return 12000;
            }
            else
            {
                return Convert.ToInt32(setting.Value);
            }
        }

        public async Task<float> GetSoundHighPass()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Highpass).FirstOrDefaultAsync().ConfigureAwait(false);

            if (setting == null)
            {
                await SetSoundHighPass(1000);
                return 1000f;
            }
            else
            {
                return Convert.ToSingle(setting.Value);
            }
        }

        public async Task<float> GetSoundHighPassGain()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.GainHigh).FirstOrDefaultAsync().ConfigureAwait(false);

            if (setting == null)
            {
                await SetSoundHighPassGain(-15);
                return -15f;
            }
            else
            {
                return Convert.ToSingle(setting.Value);
            }
        }

        public async Task<float> GetSoundLowPass()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Lowpass).FirstOrDefaultAsync().ConfigureAwait(false);

            if (setting == null)
            {
                await SetSoundLowPass(600);
                return 600f;
            }
            else
            {
                return Convert.ToSingle(setting.Value);
            }
        }

        public async Task<float> GetSoundLowPassGain()
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.GainLow).FirstOrDefaultAsync().ConfigureAwait(false);

            if (setting == null)
            {
                await SetSoundLowPassGain(-15);
                return -15f;
            }
            else
            {
                return Convert.ToSingle(setting.Value);
            }
        }

        public async Task SetAmbianceVolume(int volume)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Ambiance).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = volume.ToString();
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.Ambiance,
                    Value = volume.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetAnnouncementVolume(int volume)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Announcement).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = volume.ToString();
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.Announcement,
                    Value = volume.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetAutoSeatbelt(bool seatbelt)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Seatbelt).FirstOrDefaultAsync().ConfigureAwait(false);
            string value = "0";

            if (seatbelt)
            {
                value = "1";
            }

            if (setting != null)
            {
                setting.Value = value;
                await _csContext.SaveChangesAsync();
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.Seatbelt,
                    Value = value
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetDevice(int device)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Device).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = device.ToString();
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.Device,
                    Value = device.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task SetDoorEffect(bool dooreffect)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.DoorEffect).FirstOrDefaultAsync().ConfigureAwait(false);
            string value = "0";

            if (dooreffect)
            {
                value = "1";
            }

            if (setting != null)
            {
                setting.Value = value;
                await _csContext.SaveChangesAsync();
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.DoorEffect,
                    Value = value
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetMusicVolume(int volume)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Music).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = volume.ToString();
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.Music,
                    Value = volume.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task SetSeatbeltsAutoOffAltitude(int altitude)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.SeatbeltsOff).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = altitude.ToString();
                await _csContext.SaveChangesAsync();
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.SeatbeltsOff,
                    Value = altitude.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetSeatbeltsAutoOnAltitude(int altitude)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.SeatbeltsOn).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = altitude.ToString();
                await _csContext.SaveChangesAsync();
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.SeatbeltsOn,
                    Value = altitude.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetSoundHighPass(float freq)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Highpass).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = freq.ToString();
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.Highpass,
                    Value = freq.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetSoundHighPassGain(float freq)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.GainHigh).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = freq.ToString();
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.GainHigh,
                    Value = freq.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetSoundLowPass(float freq)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Lowpass).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = freq.ToString();
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.Lowpass,
                    Value = freq.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        public async Task SetSoundLowPassGain(float freq)
        {
            var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.GainLow).FirstOrDefaultAsync().ConfigureAwait(false);
            if (setting != null)
            {
                setting.Value = freq.ToString();
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            {
                Settings settings = new()
                {
                    Setting = SettingType.GainLow,
                    Value = freq.ToString()
                };
                _csContext.Settings.Add(settings);
                await _csContext.SaveChangesAsync();
            }
        }

        #endregion Public Methods
    }
}