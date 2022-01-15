using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Models;
using Org.Strausshome.FS.CrewSoundsNG.Repositories;

namespace Org.Strausshome.FS.CrewSoundsNG.Data
{
    public class DataSeeder
    {
        #region Private Fields

        private readonly FlightStatusRepository _flightStatusRepository;
        private readonly ILogger<DataSeeder> _logger;
        private readonly MediaFileRepository _mediaFileRepository;
        private readonly ProfileRepository _profileRepository;
        private readonly SettingsRepository _settingsRepository;

        #endregion Private Fields

        #region Public Constructors

        public DataSeeder(ILogger<DataSeeder> logger,
            SettingsRepository settingsRepository,
            FlightStatusRepository flightStatusRepository,
            ProfileRepository profileRepository,
            MediaFileRepository mediaFileRepository)
        {
            _logger = logger;
            _settingsRepository = settingsRepository;
            _flightStatusRepository = flightStatusRepository;
            _profileRepository = profileRepository;
            _mediaFileRepository = mediaFileRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<FlightStatusProfile> AddDefaultFlightStatusAsync()
        {
            var profile = await _flightStatusRepository.GetFlightStatusProfileAsync("Default").ConfigureAwait(false);
            if (profile == null)
            {
                profile = new()
                {
                    Name = "Default"
                };

                //profile = await _flightStatusRepository.AddFlightStatusProfileAsync(profile).ConfigureAwait(false);
                profile.FlightStatus = new List<FlightStatus>();
            }

            FlightStatus flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Boarding,
                Ignore = false,
                IsDoorOpen = BoolExt.True,
                IsEngineRun = BoolExt.False,
                IsOnGround = BoolExt.True,
                IsGearDown = BoolExt.True,
                RadioAltitude = 30,
                RadioOperator = Operator.Less,
                GroundSpeed = 0,
                SpeedOperator = Operator.Equal,
                VerticalSpeed = 10,
                VerticalOperator = Operator.Less,
                Altitude = 10000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = true,
                Name = "Boarding",
                Sequence = 1,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.PostBoarding,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.False,
                IsOnGround = BoolExt.True,
                IsGearDown = BoolExt.True,
                RadioAltitude = 30,
                RadioOperator = Operator.Less,
                GroundSpeed = 0,
                SpeedOperator = Operator.Equal,
                VerticalSpeed = 0,
                VerticalOperator = Operator.Equal,
                Altitude = 10000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Name = "Welcome on board",
                Sequence = 2,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.EngineStart,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.True,
                IsGearDown = BoolExt.True,
                RadioAltitude = 30,
                RadioOperator = Operator.Less,
                GroundSpeed = 0,
                SpeedOperator = Operator.Equal,
                VerticalSpeed = 0,
                VerticalOperator = Operator.Equal,
                Altitude = 10000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Name = "After engine 1 start",
                Sequence = 3,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Taxi,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.True,
                IsGearDown = BoolExt.True,
                RadioAltitude = 30,
                RadioOperator = Operator.Less,
                GroundSpeed = 5,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = 10,
                VerticalOperator = Operator.Less,
                Altitude = 10000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                Name = "Taxi to departure",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 4,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.AfterTakeoff,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.False,
                IsGearDown = BoolExt.False,
                RadioAltitude = 100,
                RadioOperator = Operator.Greater,
                GroundSpeed = 60,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = 100,
                VerticalOperator = Operator.Greater,
                Altitude = 10000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                Name = "After Take-Off",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 5,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.PassingTenUp,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.False,
                IsGearDown = BoolExt.False,
                RadioAltitude = 10000,
                RadioOperator = Operator.Greater,
                GroundSpeed = 150,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = 100,
                VerticalOperator = Operator.Greater,
                Altitude = 10100,
                AltitudeOperator = Operator.Greater,
                SeatbeltsSignOn = true,
                Name = "Passing 10.000ft climbing",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 6,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Climbing,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.False,
                IsGearDown = BoolExt.False,
                RadioAltitude = 12000,
                RadioOperator = Operator.Greater,
                GroundSpeed = 150,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = 100,
                VerticalOperator = Operator.Greater,
                Altitude = 10000,
                AltitudeOperator = Operator.Greater,
                SeatbeltsSignOn = false,
                Name = "Climbing",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 7,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Cruise,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.False,
                IsGearDown = BoolExt.False,
                RadioAltitude = 12000,
                RadioOperator = Operator.Greater,
                GroundSpeed = 150,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = 100,
                VerticalOperator = Operator.Less,
                Altitude = 10000,
                AltitudeOperator = Operator.Greater,
                SeatbeltsSignOn = false,
                Name = "Cruising",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 8,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Descent,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.False,
                IsGearDown = BoolExt.False,
                RadioAltitude = 12000,
                RadioOperator = Operator.Greater,
                GroundSpeed = 150,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = -200,
                VerticalOperator = Operator.Less,
                Altitude = 10000,
                AltitudeOperator = Operator.Greater,
                SeatbeltsSignOn = true,
                Name = "Descending",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 9,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.PassingTenDown,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.False,
                IsGearDown = BoolExt.False,
                RadioAltitude = 12000,
                RadioOperator = Operator.Less,
                GroundSpeed = 150,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = -200,
                VerticalOperator = Operator.Less,
                Altitude = 10100,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                Name = "Passing 10.000ft descending",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 10,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Approach,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.False,
                IsGearDown = BoolExt.False,
                RadioAltitude = 6000,
                RadioOperator = Operator.Less,
                GroundSpeed = 150,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = -100,
                VerticalOperator = Operator.Less,
                Altitude = 6000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                Name = "Approach",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 11,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Landing,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.False,
                IsGearDown = BoolExt.True,
                RadioAltitude = 3000,
                RadioOperator = Operator.Less,
                GroundSpeed = 150,
                SpeedOperator = Operator.Greater,
                VerticalSpeed = -100,
                VerticalOperator = Operator.Less,
                Altitude = 6000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                Name = "Landing",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 12,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.AfterLanding,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.True,
                IsOnGround = BoolExt.True,
                IsGearDown = BoolExt.True,
                RadioAltitude = 100,
                RadioOperator = Operator.Less,
                GroundSpeed = 60,
                SpeedOperator = Operator.Less,
                VerticalSpeed = 100,
                VerticalOperator = Operator.Less,
                Altitude = 6000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                Name = "After Landing",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 13,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Parking,
                Ignore = false,
                IsDoorOpen = BoolExt.False,
                IsEngineRun = BoolExt.False,
                IsOnGround = BoolExt.True,
                IsGearDown = BoolExt.True,
                RadioAltitude = 100,
                RadioOperator = Operator.Less,
                GroundSpeed = 0,
                SpeedOperator = Operator.Equal,
                VerticalSpeed = 100,
                VerticalOperator = Operator.Less,
                Altitude = 6000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = false,
                Name = "Parking",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = false,
                Sequence = 14,
            };

            profile.FlightStatus.Add(flightStatus);

            flightStatus = new()
            {
                FlightStatusName = FlightStatusName.Deboarding,
                Ignore = false,
                IsDoorOpen = BoolExt.True,
                IsEngineRun = BoolExt.False,
                IsOnGround = BoolExt.True,
                IsGearDown = BoolExt.True,
                RadioAltitude = 100,
                RadioOperator = Operator.Less,
                GroundSpeed = 0,
                SpeedOperator = Operator.Equal,
                VerticalSpeed = 100,
                VerticalOperator = Operator.Less,
                Altitude = 6000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = false,
                Name = "Deboarding",
                IsParkingBrakeSet = BoolExt.NotRequired,
                CallGroundServices = true,
                Sequence = 15,
            };

            profile.FlightStatus.Add(flightStatus);

            profile = await _flightStatusRepository.AddFlightStatusProfileAsync(profile).ConfigureAwait(false);

            return profile;
        }

        public async Task CheckNecessaryDataAsync()
        {
            await CheckSettingsAsync();
            var status = await _flightStatusRepository.GetFlightStatusAsync().ConfigureAwait(false);
            if (!status.Any())
            {
                var profile = await AddDefaultFlightStatusAsync();
                await CreateBasicProfileAsync(profile).ConfigureAwait(false);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private async Task CheckSettingsAsync()
        {
            _logger.LogDebug("Check the necessary settings.");

            _logger.LogDebug($"Device: {await _settingsRepository.GetDevice().ConfigureAwait(false)}");
            _logger.LogDebug($"Door effect: {await _settingsRepository.GetDoorEffect().ConfigureAwait(false)}");
            _logger.LogDebug($"Music volume: {await _settingsRepository.GetMusicVolume().ConfigureAwait(false)}");
            _logger.LogDebug($"Seatbelt auto off: {await _settingsRepository.GetSeatbeltsAutoOffAltitude().ConfigureAwait(false)}");
            _logger.LogDebug($"Seatbelt auto on: {await _settingsRepository.GetSeatbeltsAutoOnAltitude().ConfigureAwait(false)}");
            _logger.LogDebug($"Ambiance Volume: {await _settingsRepository.GetAmbianceVolume().ConfigureAwait(false)}");
            _logger.LogDebug($"Autoseatbelt: {await _settingsRepository.GetAutoSeatbelt().ConfigureAwait(false)}");
            _logger.LogDebug($"Sound low pass: {await _settingsRepository.GetSoundLowPass().ConfigureAwait(false)}");
            _logger.LogDebug($"Sound high pass: {await _settingsRepository.GetSoundHighPass().ConfigureAwait(false)}");
            _logger.LogDebug($"Sound low pass gain: {await _settingsRepository.GetSoundLowPassGain().ConfigureAwait(false)}");
            _logger.LogDebug($"Sound high pass gain: {await _settingsRepository.GetSoundHighPassGain().ConfigureAwait(false)}");
            _logger.LogDebug($"Sound announcement: {await _settingsRepository.GetAnnouncementVolume().ConfigureAwait(false)}");
        }

        private async Task CreateBasicProfileAsync(FlightStatusProfile flightProfile)
        {
            var profile = await _profileRepository.GetProfileByNameAsync("Default").ConfigureAwait(false);
            if (profile == null)
            {
                profile = new()
                {
                    Name = "Default",
                    ProfileItems = new()
                };

                profile = await _profileRepository.AddProfileAsync(profile).ConfigureAwait(false);

                List<MediaFile> mediaFiles = new()
                {
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Boarding 1", Path = $@"\Profiles\Default\21_ground_ambiance_1.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Boarding 2", Path = $@"\Profiles\Default\22_ground_ambiance_2.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Boarding 3", Path = $@"\Profiles\Default\23_ground_ambiance_3.ogg" },
                };

                ProfileItem item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.Boarding).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 1,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() {Type = MediaType.Announcement, Name ="Boarding completed", Path = $@"\Profiles\Default\11_boarding_complete.ogg"},
                    new MediaFile() {Type = MediaType.Announcement, Name ="Doors in flight", Path = $@"\Profiles\Default\12_doors_flight.ogg"},
                    new MediaFile() {Type =  MediaType.Announcement, Name = "Welcome on board Cpt", Path = $@"\Profiles\Default\01_announcement_cpt_eng.ogg" }
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.PostBoarding).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 2,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() {Type =  MediaType.Announcement, Name = "Welcome on board and security", Path = $@"\Profiles\Default\02_cabin_welcome.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.EngineStart).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 3,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() {Type =  MediaType.Announcement, Name = "After Takeoff", Path = $@"\Profiles\Default\03_cabin_announcement_inflight.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 1", Path = $@"\Profiles\Default\33_flight_ambiance_11.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 2", Path = $@"\Profiles\Default\34_flight_ambiance_12.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 3", Path = $@"\Profiles\Default\35_flight_ambiance_13.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.AfterTakeoff).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 4,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 1", Path = $@"\Profiles\Default\33_flight_ambiance_11.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 2", Path = $@"\Profiles\Default\34_flight_ambiance_12.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 3", Path = $@"\Profiles\Default\35_flight_ambiance_13.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 4", Path = $@"\Profiles\Default\36_flight_ambiance_14.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.Climbing).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 5,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 1", Path = $@"\Profiles\Default\33_flight_ambiance_11.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 2", Path = $@"\Profiles\Default\34_flight_ambiance_12.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 3", Path = $@"\Profiles\Default\35_flight_ambiance_13.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 4", Path = $@"\Profiles\Default\36_flight_ambiance_14.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.Cruise).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 6,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                   new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 1", Path = $@"\Profiles\Default\33_flight_ambiance_11.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 2", Path = $@"\Profiles\Default\34_flight_ambiance_12.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 3", Path = $@"\Profiles\Default\35_flight_ambiance_13.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 4", Path = $@"\Profiles\Default\36_flight_ambiance_14.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.Descent).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 7,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 1", Path = $@"\Profiles\Default\33_flight_ambiance_11.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 2", Path = $@"\Profiles\Default\34_flight_ambiance_12.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 3", Path = $@"\Profiles\Default\35_flight_ambiance_13.ogg" },
                    new MediaFile() { Type = MediaType.Announcement, Name = "Approach", Path = $@"\Profiles\Default\13_cabin_prepare_landing.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.Approach).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 8,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() { Type = MediaType.Announcement, Name = "After Landing", Path = $@"\Profiles\Default\05_welcome_dest_eng.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.AfterLanding).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 9,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() { Type = MediaType.Announcement, Name = "Parking", Path = $@"\Profiles\Default\14_doors_park.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.Parking).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 10,
                };

                profile.ProfileItems.Add(item);

                mediaFiles = new List<MediaFile>()
                {
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Boarding 1", Path = $@"\Profiles\Default\21_ground_ambiance_1.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Boarding 2", Path = $@"\Profiles\Default\22_ground_ambiance_2.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Boarding 3", Path = $@"\Profiles\Default\23_ground_ambiance_3.ogg" },
                    new MediaFile() { Type = MediaType.Ambiance, Name = "Climbing 1", Path = $@"\Profiles\Default\33_flight_ambiance_11.ogg" },
                };

                item = new()
                {
                    FlightStatus = flightProfile.FlightStatus.Where(c => c.FlightStatusName == FlightStatusName.Deboarding).FirstOrDefault(),
                    MediaFile = mediaFiles,
                    Sequence = 11,
                };

                profile.ProfileItems.Add(item);
            }
        }

        #endregion Private Methods
    }
}