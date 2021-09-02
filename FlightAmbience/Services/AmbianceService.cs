using Org.Strausshome.FS.CrewSoundsNG.Models;

namespace Org.Strausshome.FS.CrewSoundsNG.Services
{
    public class AmbianceService
    {
        #region Public Methods

        public static bool CheckForNextItem(FlightSimInfo flightSimInfo, FlightStatus flightStatus)
        {
            if (flightStatus.IsDoorOpen != BoolExt.NotRequired)
            {
                if (flightStatus.IsDoorOpen == BoolExt.True && !flightSimInfo.IsDoorOpen)
                {
                    return false;
                }
                else if (flightStatus.IsDoorOpen == BoolExt.False && flightSimInfo.IsDoorOpen)
                {
                    return false;
                }
            }

            if (flightStatus.IsOnGround != BoolExt.NotRequired)
            {
                if (flightStatus.IsOnGround == BoolExt.True && !flightSimInfo.IsOnGround)
                {
                    return false;
                }
                else if (flightStatus.IsOnGround == BoolExt.False && flightSimInfo.IsOnGround)
                {
                    return false;
                }
            }

            if (flightStatus.IsEngineRun != BoolExt.NotRequired)
            {
                if (flightStatus.IsEngineRun == BoolExt.True && !flightSimInfo.IsEngineRunning)
                {
                    return false;
                }
                else if (flightStatus.IsEngineRun == BoolExt.False && flightSimInfo.IsEngineRunning)
                {
                    return false;
                }
            }

            if (flightStatus.IsParkingBrakeSet != BoolExt.NotRequired)
            {
                if (flightStatus.IsParkingBrakeSet == BoolExt.True && !flightSimInfo.IsParkingBrakeOn)
                {
                    return false;
                }
                else if (flightStatus.IsParkingBrakeSet == BoolExt.False && flightSimInfo.IsParkingBrakeOn)
                {
                    return false;
                }
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