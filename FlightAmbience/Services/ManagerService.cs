using System;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

using Microsoft.Extensions.Logging;
using Microsoft.FlightSimulator.SimConnect;

using Org.Strausshome.FS.CrewSoundsNG.Models;

namespace Org.Strausshome.FS.CrewSoundsNG.Services
{
    public class ManagerService
    {
        #region Private Fields

        private static System.Timers.Timer eventTimer;
        private readonly FlightSimService _flightSimService;
        private readonly ILogger<ManagerService> _logger;
        private readonly MediaService _mediaService;

        private bool connectionInit;
        private int currentSequence;

        #region groundservices

        private bool groundServices;
        private bool callGroundServices;
        private int secondsToStop;
        private TimerTrigger trigger;

        #endregion groundservices

        private Profile profile;

        #endregion Private Fields

        #region Public Constructors

        public ManagerService(FlightSimService flightSimService,
            ILogger<ManagerService> logger,
            MediaService mediaService)
        {
            _logger = logger;
            _flightSimService = flightSimService;
            _flightSimService.DataRxEvent += FlightSimService_DataRxEvent;
            _mediaService = mediaService;
            connectionInit = false;
            eventTimer = new System.Timers.Timer(1000);
            eventTimer.Elapsed += TimerEvent;
            eventTimer.AutoReset = true;
        }

        private void MainView_SetButton(string text)
        {
            throw new NotImplementedException();
        }

        #endregion Public Constructors

        #region Public Delegates

        public delegate void GetFlightSimInfos(FlightSimInfo flightSimInfo);

        public delegate void GetProfileInfos(ProfileItem item);

        public delegate void UpdateText(string name);

        #endregion Public Delegates

        #region Public Events

        public event GetProfileInfos FlightItem;

        public event GetFlightSimInfos FlightSimInfos;

        public event UpdateText TextUpdater;

        #endregion Public Events

        #region Public Properties

        public FlightSimInfo CurrentFlightSimInfo { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void RemoveJetway(bool remove)
        {
            _flightSimService.RemoveJetway(remove);
        }

        public void StartSimConnection(Profile selectedProfile,
                                       bool callGroundService,
                                       bool autoRemove,
                                       int groundServiceSeconds)
        {
            if (!connectionInit)
            {
                _flightSimService.RegisterFlightStatusDefinition();
                connectionInit = true;
            }

            profile = selectedProfile;
            currentSequence = 1;
            groundServices = false;
            callGroundServices = callGroundService;

            secondsToStop = groundServiceSeconds;
            eventTimer.Enabled = autoRemove;
            trigger = TimerTrigger.GroundService;
        }

        public void StopAmbiance()
        {
            _logger.LogDebug($"Stopping ambiance");
            _mediaService.StopAll();
            _flightSimService.CloseConnection();
        }

        #endregion Public Methods

        #region Private Methods

        private async Task AmbianceProcess()
        {
            var item = profile.ProfileItems.Where(c => c.Sequence == currentSequence).FirstOrDefault();
            if (item != null)
            {
                var flightStatus = profile.FlightProfile.FlightStatus
                    .Where(f => f.FlightStatusName == item.FlightStatus.FlightStatusName)
                    .FirstOrDefault();

                FlightItem?.Invoke(item);
                TextUpdater?.Invoke($"{flightStatus.Name} - {currentSequence}");

                // Profile item is set to request the ground services.
                if (flightStatus.CallGroundServices && !groundServices && !CurrentFlightSimInfo.IsDoorOpen && callGroundServices)
                {
                    _logger.LogDebug($"Toogle Ground services {flightStatus.Name}: FlightStatus: {flightStatus.CallGroundServices}; NotCalled: {groundServices}; FlightSimInfo: {CurrentFlightSimInfo.IsDoorOpen}; UserRequest: {callGroundServices}");

                    // Sometime they need a bit longer, so waiting 20 seconds and try again.
                    int i = 0;
                    while (i < 5 && !CurrentFlightSimInfo.IsDoorOpen)
                    {
                        _logger.LogDebug($"Calling ground services");
                        groundServices = true;
                        _flightSimService.ToggleGroundService();
                        await Task.Delay(TimeSpan.FromSeconds(20));
                        i++;
                    }
                }

                if (AmbianceService.CheckForNextItem(CurrentFlightSimInfo, flightStatus))
                {
                    _logger.LogDebug($"<<<< Next profile item {currentSequence} >>>>");
                    _mediaService.SetProfileItem(item);

                    // This must be sync, don't add await. It plays over and over the media files.
                    _mediaService.StartAnnouncement(item);
                    TextUpdater?.Invoke($"{flightStatus.Name} - {currentSequence}");
                    currentSequence++;
                    groundServices = false;

                    // Last item? Stop the ambiance after 5 minutes.
                    if (currentSequence == profile.ProfileItems.Count)
                    {
                        _logger.LogDebug($"<<<< Last profile enable timer >>>>");
                        secondsToStop = 300;
                        trigger = TimerTrigger.EndDeboarding;
                        eventTimer.Enabled = true;
                    }
                }
            }
        }

        private async void FlightSimService_DataRxEvent(RequestsEnum request, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            try
            {
                if (request == RequestsEnum.RefreshDataRequest)
                {
                    FlightStatusStruct receivedData = (FlightStatusStruct)data.dwData[0];

                    try
                    {
                        // Reading the normal data.
                        FlightSimInfo flightSimInfo = new();
                        flightSimInfo.Altitude = Math.Round((receivedData.Altitude * 3.28084), 0);
                        flightSimInfo.Latitude = Math.Round(receivedData.Latitude, 5);
                        flightSimInfo.Longitude = Math.Round(receivedData.Longitude, 5);
                        flightSimInfo.AltitudeAboveGround = Math.Round(receivedData.AltitudeAboveGround, 0);
                        flightSimInfo.IsEngineRunning = receivedData.EngCombustion == 1;
                        flightSimInfo.GroundSpeed = Math.Round((receivedData.GroundSpeed * 1.94384), 0);
                        flightSimInfo.IndicatedAirSpeed = Math.Round((receivedData.IndicatedAirSpeed * 1.94384), 0);
                        flightSimInfo.IsOnGround = receivedData.SimOnGround != 0;
                        flightSimInfo.VerticalSpeed = Math.Round((receivedData.VerticalSpeed * 3.28084 * 60), 0);
                        flightSimInfo.IsGearDown = receivedData.GearPosition == GearPosition.Down;

                        // Checking the parking brake position.
                        flightSimInfo.IsParkingBrakeOn = receivedData.BrakeParkingPosition > 0;

                        // Main door open?
                        flightSimInfo.IsDoorOpen = receivedData.MainExit > .2;

                        FlightSimInfos?.Invoke(flightSimInfo);

                        CurrentFlightSimInfo = flightSimInfo;

                        await AmbianceProcess();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error while reading the sim data.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error, something bad happened while reading the data.");
            }
        }

        private void TimerEvent(object sender, ElapsedEventArgs e)
        {
            if (secondsToStop == 0)
            {
                switch (trigger)
                {
                    case TimerTrigger.GroundService:
                        RemoveJetway(true);
                        break;

                    case TimerTrigger.EndDeboarding:
                        StopAmbiance();
                        break;

                    case TimerTrigger.Nothing:
                        break;

                    default:
                        break;
                }

                eventTimer.Enabled = false;
                trigger = TimerTrigger.Nothing;
            }
            else
            {
                secondsToStop--;
            }
        }

        #endregion Private Methods
    }
}