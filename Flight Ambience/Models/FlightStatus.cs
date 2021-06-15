﻿using System.ComponentModel.DataAnnotations;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    public enum FlightStatusName
    {
        Boarding = 1,
        PostBoarding = 2,
        EngineStart = 3,
        Taxi = 4,
        AfterTakeoff = 5,
        PassingTenUp = 6,
        Climbing = 7,
        Cruise = 8,
        CruiseSound = 9,
        Descent = 10,
        PassingTenDown = 11,
        Approach = 12,
        Landing = 13,
        AfterLanding = 14,
        Parking = 15,
        Deboarding = 16,
        Own = 17
    }

    public class FlightStatus
    {
        [Key]
        public int FlightStatusId { get; set; }

        public string Name { get; set; }
        public FlightStatusName FlightStatusName { get; set; }
        public FlightStatusProfile Profile { get; set; }
        public bool Ignore { get; set; }
        public bool IsDoorOpen { get; set; }
        public bool IsEngineRun { get; set; }
        public bool IsOnGround { get; set; }
        public bool IsGearDown { get; set; }
        public bool ParkingBrakeSet { get; set; }
        public bool CallGroundServices { get; set; }
        public int Altitude { get; set; }
        public Operator AltitudeOperator { get; set; }
        public int VerticalSpeed { get; set; }
        public Operator VerticalOperator { get; set; }
        public int RadioAltitude { get; set; }
        public Operator RadioOperator { get; set; }
        public int GroundSpeed { get; set; }
        public Operator SpeedOperator { get; set; }
        public int Sequence { get; set; }
        public bool SeatbeltsSignOn { get; set; }
    }

    public enum Operator
    {
        Less = 1,
        Equal = 2,
        Greater = 3
    }
}