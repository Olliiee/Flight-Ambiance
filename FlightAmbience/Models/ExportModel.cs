using System.Collections.Generic;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    public class ExportFlightStatus
    {
        #region Public Properties

        public int Altitude { get; set; }
        public Operator AltitudeOperator { get; set; }
        public bool CallGroundServices { get; set; }
        public FlightStatusName FlightStatusName { get; set; }
        public int GroundSpeed { get; set; }
        public bool Ignore { get; set; }
        public BoolExt IsDoorOpen { get; set; }
        public BoolExt IsEngineRun { get; set; }
        public BoolExt IsGearDown { get; set; }
        public BoolExt IsOnGround { get; set; }
        public BoolExt IsParkingBrakeSet { get; set; }
        public string Name { get; set; }
        public int RadioAltitude { get; set; }
        public Operator RadioOperator { get; set; }
        public bool SeatbeltsSignOn { get; set; }
        public int Sequence { get; set; }
        public Operator SpeedOperator { get; set; }
        public Operator VerticalOperator { get; set; }
        public int VerticalSpeed { get; set; }

        #endregion Public Properties
    }

    public class ExportMediaFile
    {
        #region Public Properties

        public string Name { get; set; }
        public string Path { get; set; }
        public MediaType Type { get; set; }

        #endregion Public Properties
    }

    public class ExportProfile
    {
        #region Public Properties

        public string Name { get; set; }

        public List<ExportProfileItem> ProfileItems { get; set; }

        #endregion Public Properties
    }

    public class ExportProfileItem
    {
        #region Public Properties

        public ExportFlightStatus FlightStatus { get; set; }
        public List<ExportMediaFile> MediaFiles { get; set; }
        public int Sequence { get; set; }

        #endregion Public Properties
    }
}