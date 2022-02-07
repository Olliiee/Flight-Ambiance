using Org.Strausshome.FS.CrewSoundsNG.Models;

namespace Org.Strausshome.FS.CrewSoundsNG.Services
{
    public class ImportExportService
    {
        #region Public Methods

        public ExportProfile CreateExport(Profile profile)
        {
            ExportProfile exportProfile = new()
            {
                Name = profile.Name,
                ProfileItems = new()
            };

            foreach (var item in profile.ProfileItems)
            {
                ExportProfileItem exportProfileItem = new()
                {
                    Sequence = item.Sequence,
                    MediaFiles = new()
                };

                exportProfileItem.FlightStatus = new()
                {
                    Altitude = item.FlightStatus.Altitude,
                    AltitudeOperator = item.FlightStatus.AltitudeOperator,
                    CallGroundServices = item.FlightStatus.CallGroundServices,
                    FlightStatusName = item.FlightStatus.FlightStatusName,
                    GroundSpeed = item.FlightStatus.GroundSpeed,
                    Ignore = item.FlightStatus.Ignore,
                    IsDoorOpen = item.FlightStatus.IsDoorOpen,
                    IsEngineRun = item.FlightStatus.IsEngineRun,
                    IsGearDown = item.FlightStatus.IsGearDown,
                    IsOnGround = item.FlightStatus.IsOnGround,
                    IsParkingBrakeSet = item.FlightStatus.IsParkingBrakeSet,
                    Name = item.FlightStatus.Name,
                    RadioAltitude = item.FlightStatus.RadioAltitude,
                    RadioOperator = item.FlightStatus.RadioOperator,
                    SeatbeltsSignOn = item.FlightStatus.SeatbeltsSignOn,
                    Sequence = item.FlightStatus.Sequence,
                    SpeedOperator = item.FlightStatus.SpeedOperator,
                    VerticalOperator = item.FlightStatus.VerticalOperator,
                    VerticalSpeed = item.FlightStatus.VerticalSpeed
                };

                foreach (var file in item.MediaFile)
                {
                    ExportMediaFile exportMediaFile = new()
                    {
                        Name = file.Name,
                        Path = file.Path,
                        Type = file.Type
                    };

                    exportProfileItem.MediaFiles.Add(exportMediaFile);
                }

                exportProfile.ProfileItems.Add(exportProfileItem);
            }

            return exportProfile;
        }

        public Profile CreateImport(ExportProfile exportProfile)
        {
            Profile profile = new()
            {
                Name = exportProfile.Name,
                ProfileItems = new()
            };

            foreach (var item in exportProfile.ProfileItems)
            {
                ProfileItem importProfileItem = new()
                {
                    Sequence = item.Sequence,
                    MediaFile = new()
                };

                importProfileItem.FlightStatus = new()
                {
                    Altitude = item.FlightStatus.Altitude,
                    AltitudeOperator = item.FlightStatus.AltitudeOperator,
                    CallGroundServices = item.FlightStatus.CallGroundServices,
                    FlightStatusName = item.FlightStatus.FlightStatusName,
                    GroundSpeed = item.FlightStatus.GroundSpeed,
                    Ignore = item.FlightStatus.Ignore,
                    IsDoorOpen = item.FlightStatus.IsDoorOpen,
                    IsEngineRun = item.FlightStatus.IsEngineRun,
                    IsGearDown = item.FlightStatus.IsGearDown,
                    IsOnGround = item.FlightStatus.IsOnGround,
                    IsParkingBrakeSet = item.FlightStatus.IsParkingBrakeSet,
                    Name = item.FlightStatus.Name,
                    RadioAltitude = item.FlightStatus.RadioAltitude,
                    RadioOperator = item.FlightStatus.RadioOperator,
                    SeatbeltsSignOn = item.FlightStatus.SeatbeltsSignOn,
                    Sequence = item.FlightStatus.Sequence,
                    SpeedOperator = item.FlightStatus.SpeedOperator,
                    VerticalOperator = item.FlightStatus.VerticalOperator,
                    VerticalSpeed = item.FlightStatus.VerticalSpeed
                };

                foreach (var file in item.MediaFiles)
                {
                    MediaFile importMediaFile = new()
                    {
                        Name = file.Name,
                        Path = file.Path,
                        Type = file.Type
                    };

                    importProfileItem.MediaFile.Add(importMediaFile);
                }

                profile.ProfileItems.Add(importProfileItem);
            }

            return profile;
        }

        #endregion Public Methods
    }
}