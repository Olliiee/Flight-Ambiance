using System.Windows.Forms;

using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Models;
using Org.Strausshome.FS.CrewSoundsNG.Services;

namespace Org.Strausshome.FS.CrewSoundsNG
{
    public partial class DebugView : Form
    {
        private readonly ILogger<DebugView> _logger;
        private readonly ManagerService _managerService;

        public DebugView(ILogger<DebugView> logger, ManagerService managerService)
        {
            InitializeComponent();

            _logger = logger;
            _managerService = managerService;
            _managerService.TextUpdater += Manager_TextUpdater;
            _managerService.FlightSimInfos += Manager_FlightSimInfos;
            _managerService.FlightItem += Manager_Item;
        }

        private void Manager_TextUpdater(string name)
        {
            ProfileText.Text = name;
        }

        private void Manager_Item(ProfileItem item)
        {
            ItemAltitude.Text = GetText(item.FlightStatus.Altitude, item.FlightStatus.AltitudeOperator);
            ItemVerticalSpeed.Text = GetText(item.FlightStatus.VerticalSpeed, item.FlightStatus.VerticalOperator);
            ItemRadioAltitude.Text = GetText(item.FlightStatus.RadioAltitude, item.FlightStatus.RadioOperator);
            ItemGroundSpeed.Text = GetText(item.FlightStatus.GroundSpeed, item.FlightStatus.SpeedOperator);
            ItemExitOpen.Checked = item.FlightStatus.IsDoorOpen == BoolExt.True;
            ItemIsEngineRunning.Checked = item.FlightStatus.IsEngineRun == BoolExt.True;
            ItemIsParkingBrakeSet.Checked = item.FlightStatus.IsParkingBrakeSet == BoolExt.True;
            ItemIsOnGround.Checked = item.FlightStatus.IsOnGround == BoolExt.True;
            ItemIsGearDown.Checked = item.FlightStatus.IsGearDown == BoolExt.True;
        }

        private static string GetText(int value, Operator valueOperator)
        {
            return valueOperator switch
            {
                Operator.Less => $"< {value}",
                Operator.Equal => $"= {value}",
                Operator.Greater => $"> {value}",
                _ => string.Empty,
            };
        }

        private void Manager_FlightSimInfos(FlightSimInfo flightSimInfo)
        {
            AltitudeBox.Text = flightSimInfo.Altitude.ToString();
            LatitudeBox.Text = flightSimInfo.Latitude.ToString();
            LongitudeBox.Text = flightSimInfo.Longitude.ToString();
            AltitudeAboveGround.Text = flightSimInfo.AltitudeAboveGround.ToString();
            EngineRunning.Checked = flightSimInfo.IsEngineRunning;
            GroundSpeedBox.Text = flightSimInfo.GroundSpeed.ToString();
            IndicatedAirspeedBox.Text = flightSimInfo.IndicatedAirSpeed.ToString();
            IsOnGround.Checked = flightSimInfo.IsOnGround;
            VerticalSpeedBox.Text = flightSimInfo.VerticalSpeed.ToString();

            GearPosition.Checked = flightSimInfo.IsGearDown;
            ParkingBrake.Checked = flightSimInfo.IsParkingBrakeOn;
            MainExitCheck.Checked = flightSimInfo.IsDoorOpen;
        }
    }
}