using System.Runtime.InteropServices;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    public enum DEFINITIONS
    {
        AircraftData,
        FlightStatus,
        GenericData,
        ExitTypeStruct,
        ExitStruct,
    }

    public enum EventsEnum
    {
        TOGGLE_PUSHBACK,
        TOGGLE_JETWAY,
        TOGGLE_AIRCRAFT_EXIT,
        TOGGLE_PARKING_BRAKES,
        TOGGLE_RAMPTRUCK,
        REQUEST_LUGGAGE,
        REQUEST_CATERING
    }

    public enum GearPosition
    {
        Down = 1,
        Up = 0
    }

    public enum NotificationGroupsEnum
    {
        Group0
    }

    public enum RequestsEnum
    {
        RefreshDataRequest,
        ExitRequest
    }

    internal enum DATA_REQUESTS
    {
        NONE,
        SUBSCRIBE_GENERIC,
        AIRCRAFT_DATA,
        FLIGHT_STATUS,
        ENVIRONMENT_DATA,
        FLIGHT_PLAN,
        TOGGLE_VALUE_DATA
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    internal struct FlightStatusStruct
    {
        public double Longitude;
        public double Latitude;
        public double Altitude;
        public double AltitudeAboveGround;
        public double GroundSpeed;
        public double IndicatedAirSpeed;
        public double VerticalSpeed;
        public int SimOnGround;
        public int EngCombustion;
        public GearPosition GearPosition;
        public int BrakeParkingPosition;
        public double MainExit;
    }
}