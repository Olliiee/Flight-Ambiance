using Org.Strausshome.FS.CrewSoundsNG.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Strausshome.FS.CrewSoundsNG.Services
{
    public class FlightStatusService
    {
        public FlightStatusService()
        {
        }

        public FlightStatusProfile GetDefaultFlightStatus()
        {
            FlightStatusProfile profile = new()
            {
                Name = "Default",
                FlightStatus = new()
            };

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

            return profile;
        }
    }
}