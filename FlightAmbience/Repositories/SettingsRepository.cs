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
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return 30;
            }
        }

        public async Task<int> GetAnnouncementVolume()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return 15;
            }
        }

        public async Task<bool> GetAutoSeatbelt()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return false;
            }
        }

        public async Task<int> GetDevice()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return 0;
            }
        }

        public async Task<bool> GetDoorEffect()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return true;
            }
        }

        public async Task<int> GetMusicVolume()
        {
            try
            {
                var setting = await _csContext.Settings.Where(setting => setting.Setting == SettingType.Music).FirstOrDefaultAsync().ConfigureAwait(false);
                if (setting == null)
                {
                    await SetMusicVolume(15);
                    return 15;
                }
                else
                {
                    return Convert.ToInt32(setting.Value);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return 15;
            }
        }

        public async Task<int> GetSeatbeltsAutoOffAltitude()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return 12100;
            }
        }

        public async Task<int> GetSeatbeltsAutoOnAltitude()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return 12000;
            }
        }

        public async Task<float> GetSoundHighPass()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return 1000f;
            }
        }

        public async Task<float> GetSoundHighPassGain()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return -15f;
            }
        }

        public async Task<float> GetSoundLowPass()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return 600f;
            }
        }

        public async Task<float> GetSoundLowPassGain()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading setting");
                return -15f;
            }
        }

        public async Task SetAmbianceVolume(int volume)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetAnnouncementVolume(int volume)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetAutoSeatbelt(bool seatbelt)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetDevice(int device)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetDoorEffect(bool dooreffect)
        {
            try
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
            catch (Exception ex) { _logger.LogError(ex, "Error writing setting"); }
        }

        public async Task SetMusicVolume(int volume)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetSeatbeltsAutoOffAltitude(int altitude)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetSeatbeltsAutoOnAltitude(int altitude)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetSoundHighPass(float freq)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetSoundHighPassGain(float freq)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetSoundLowPass(float freq)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        public async Task SetSoundLowPassGain(float freq)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing setting");
            }
        }

        #endregion Public Methods
    }
}