using System.Runtime.InteropServices;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FlightSimInfo
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double AltitudeAboveGround { get; set; }
        public double GroundSpeed { get; set; }
        public double IndicatedAirSpeed { get; set; }
        public double VerticalSpeed { get; set; }
        public bool IsOnGround { get; set; }
        public bool IsEngineRunning { get; set; }
        public bool IsGearDown { get; set; }

        public bool IsDoorOpen { get; set; }

        public bool IsParkingBrakeOn { get; set; }
    }
}