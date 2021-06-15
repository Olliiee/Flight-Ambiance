using Org.Strausshome.FS.CrewSoundsNG.Models;

namespace Org.Strausshome.FS.CrewSoundsNG.Services
{
    public class AmbianceService
    {
        #region Public Methods

        public static bool CheckForNextItem(FlightSimInfo flightSimInfo, FlightStatus flightStatus)
        {
            if (flightStatus.IsDoorOpen != flightSimInfo.IsDoorOpen)
            {
                return false;
            }

            if (flightStatus.IsOnGround != flightSimInfo.IsOnGround)
            {
                return false;
            }

            if (flightStatus.IsEngineRun != flightSimInfo.EngineRunning)
            {
                return false;
            }

            if (!GetValueCheck(flightStatus.AltitudeOperator, flightStatus.Altitude, flightSimInfo.Altitude))
            {
                return false;
            }

            if (!GetValueCheck(flightStatus.RadioOperator, flightStatus.RadioAltitude, flightSimInfo.AltitudeAboveGround))
            {
                return false;
            }

            if (!GetValueCheck(flightStatus.SpeedOperator, flightStatus.GroundSpeed, flightSimInfo.GroundSpeed))
            {
                return false;
            }

            if (!GetValueCheck(flightStatus.VerticalOperator, flightStatus.VerticalSpeed, flightSimInfo.VerticalSpeed))
            {
                return false;
            }

            if (flightStatus.ParkingBrakeSet != flightSimInfo.ParkingBrakeOn)
            {
                return false;
            }

            // All conditions are ok, call next item.
            return true;
        }

        #endregion Public Methods

        #region Private Methods

        private static bool GetValueCheck(Operator valueOperator, int itemValue, double simValue)
        {
            return valueOperator switch
            {
                Operator.Less => simValue < itemValue,
                Operator.Equal => simValue == itemValue,
                Operator.Greater => simValue > itemValue,
                _ => false,
            };
        }

        #endregion Private Methods
    }
}