using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.FlightSimulator.SimConnect;

using Org.Strausshome.FS.CrewSoundsNG.Models;

namespace Org.Strausshome.FS.CrewSoundsNG.Services
{
    public class FlightSimService
    {
        #region Private Fields

        private const int StatusDelayMilliseconds = 100;
        private const int WM_USER_SIMCONNECT = 0x0402;
        private readonly ILogger<FlightSimService> _logger;
        private readonly SemaphoreSlim smGeneric = new(1);
        private bool connected;
        private CancellationTokenSource cts;
        private SimConnect simconnect = null;

        #endregion Private Fields

        #region Public Constructors

        public FlightSimService(ILogger<FlightSimService> logger)
        {
            _logger = logger;
            connected = false;
        }

        #endregion Public Constructors

        #region Public Delegates

        public delegate void DataReceived(RequestsEnum request, SIMCONNECT_RECV_SIMOBJECT_DATA data);

        #endregion Public Delegates

        #region Public Events

        public event EventHandler Closed;

        public event DataReceived DataRxEvent;

        #endregion Public Events

        #region Public Methods

        public void CloseConnection()
        {
            if (connected)
            {
                try
                {
                    _logger.LogDebug("Trying to cancel request loop");
                    cts?.Cancel();
                    cts = null;
                    connected = false;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, $"Cannot cancel request loop! Error: {ex.Message}");
                }
                try
                {
                    // Dispose serves the same purpose as SimConnect_Close()
                    simconnect?.Dispose();
                    simconnect = null;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, $"Cannot unsubscribe events! Error: {ex.Message}");
                }
            }
        }

        // Set up the SimConnect event handlers
        public void Initialize(IntPtr Handle)
        {
            if (simconnect != null)
            {
                _logger.LogWarning("Initialization is already done. Cancelled this request.");
                return;
            }

            simconnect = new SimConnect("Flight Ambiance", Handle, WM_USER_SIMCONNECT, null, 0);

            // listen to connect and quit msgs
            simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(Simconnect_OnRecvOpen);
            simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(Simconnect_OnRecvQuit);

            // listen to exceptions
            simconnect.OnRecvException += Simconnect_OnRecvException;

            simconnect.OnRecvSimobjectDataBytype += Simconnect_OnRecvSimobjectDataBytype;

            simconnect.OnRecvSimobjectData += SimConnect_OnRecvSimobjectData;
        }

        public void RegisterFlightStatusDefinition()
        {
            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "PLANE LONGITUDE",
                "degrees",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "PLANE LATITUDE",
                "degrees",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "PLANE ALTITUDE",
                "Meter",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "PLANE ALT ABOVE GROUND",
                "Feet",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "GPS GROUND SPEED",
                "number",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "AIRSPEED INDICATED",
                "number",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "VERTICAL SPEED",
                "number",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "SIM ON GROUND",
                "number",
                SIMCONNECT_DATATYPE.INT32,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "ENG COMBUSTION:1",
                "number",
                SIMCONNECT_DATATYPE.INT32,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "GEAR POSITION",
                "number",
                SIMCONNECT_DATATYPE.INT32,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "BRAKE PARKING POSITION",
                "number",
                SIMCONNECT_DATATYPE.INT32,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "Exit Open:0",
                "percent over 100",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.VelocityZ,
                "Velocity Body Z",
                "feet per second",
                SIMCONNECT_DATATYPE.FLOAT64,
                0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.PushbackWait,
                "Pushback Wait",
                "Bool",
                SIMCONNECT_DATATYPE.INT32, 0.0f,
                SimConnect.SIMCONNECT_UNUSED);

            simconnect.AddToDataDefinition(DEFINITIONS.FlightStatus,
                "Pushback State",
                "Enum",
                SIMCONNECT_DATATYPE.INT32,
                0.0f, SimConnect.
                SIMCONNECT_UNUSED);

            simconnect.RegisterDataDefineStruct<FlightStatusStruct>(DEFINITIONS.FlightStatus);
            simconnect.RegisterDataDefineStruct<double>(DEFINITIONS.VelocityZ);
            simconnect.RegisterDataDefineStruct<int>(DEFINITIONS.PushbackWait);
            simconnect.RequestDataOnSimObject(RequestsEnum.RefreshDataRequest,
                                              DEFINITIONS.FlightStatus,
                                              0,
                                              SIMCONNECT_PERIOD.SECOND,
                                              SIMCONNECT_DATA_REQUEST_FLAG.CHANGED,
                                              0,
                                              0,
                                              0);

            simconnect.MapClientEventToSimEvent(EventsEnum.TOGGLE_JETWAY, "TOGGLE_JETWAY");
            simconnect.MapClientEventToSimEvent(EventsEnum.REQUEST_LUGGAGE, "REQUEST_LUGGAGE");
            simconnect.MapClientEventToSimEvent(EventsEnum.REQUEST_CATERING, "REQUEST_CATERING");
            simconnect.MapClientEventToSimEvent(EventsEnum.TOGGLE_PUSHBACK, "TOGGLE_PUSHBACK");
            simconnect.MapClientEventToSimEvent(EventsEnum.TOGGLE_RAMPTRUCK, "TOGGLE_RAMPTRUCK");
        }

        public void RemoveJetwayAsync(bool requestPushBack)
        {
            _logger.LogDebug("Toggle Jetway");
            TransmitEvent(EventsEnum.TOGGLE_JETWAY, 1);

            if (requestPushBack)
            {
                _logger.LogDebug("Calling Tug and set speed to 0.");
                TransmitEvent(EventsEnum.TOGGLE_PUSHBACK, 1);
                SetData(DEFINITIONS.PushbackWait, 1);
                SetData(DEFINITIONS.VelocityZ, 0);

                for (int i = 0; i < 30; i++)
                {
                    SetData(DEFINITIONS.VelocityZ, 0);
                    _logger.LogDebug("Set speed to 0.");
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                }
            }
        }

        public void SetData(DEFINITIONS definition, object data)
        {
            simconnect.SetDataOnSimObject(definition, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, data);
        }

        public void ToggleGroundService()
        {
            _logger.LogDebug("Toggle Groundservices");
            TransmitEvent(EventsEnum.TOGGLE_JETWAY, 1);
            TransmitEvent(EventsEnum.REQUEST_LUGGAGE, 1);
            TransmitEvent(EventsEnum.REQUEST_CATERING, 1);
            TransmitEvent(EventsEnum.TOGGLE_RAMPTRUCK, 1);
        }

        public void TransmitEvent(EventsEnum simEvent, uint data)
        {
            _logger.LogTrace("Transmit Event");
            simconnect.TransmitClientEvent(0U, simEvent, data, NotificationGroupsEnum.Group0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        public void TriggerReceive()
        {
            try
            {
                simconnect.ReceiveMessage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading simulator data.");
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void Simconnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            connected = false;
        }

        private void Simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            _logger.LogInformation("Connected to Flight Simulator");

            cts?.Cancel();
            cts = new CancellationTokenSource();
            Task.Run(async () =>
            {
                try
                {
                    connected = true;
                    while (true)
                    {
                        await Task.Delay(StatusDelayMilliseconds);
                        await smGeneric.WaitAsync();
                        try
                        {
                            cts?.Token.ThrowIfCancellationRequested();
                            simconnect?.RequestDataOnSimObjectType(DATA_REQUESTS.FLIGHT_STATUS,
                                                                   DEFINITIONS.FlightStatus,
                                                                   0,
                                                                   SIMCONNECT_SIMOBJECT_TYPE.USER);
                        }
                        finally
                        {
                            smGeneric.Release();
                        }
                    }
                }
                catch (TaskCanceledException) { }
            });
        }

        private void Simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            _logger.LogInformation("Flight Simulator has exited");
            CloseConnection();
            Closed?.Invoke(this, new EventArgs());
            connected = false;
        }

        private void SimConnect_OnRecvSimobjectData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            try
            {
                DataRxEvent?.Invoke((RequestsEnum)data.dwRequestID, data);
            }
            catch (Exception) { }
        }

        private void Simconnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            try
            {
                DataRxEvent?.Invoke((RequestsEnum)data.dwRequestID, data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on receiving");
            }
        }

        #endregion Private Methods
    }
}