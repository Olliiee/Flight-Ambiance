using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Data;
using Org.Strausshome.FS.CrewSoundsNG.Models;
using Org.Strausshome.FS.CrewSoundsNG.Repositories;
using Org.Strausshome.FS.CrewSoundsNG.Services;

namespace Org.Strausshome.FS.CrewSoundsNG
{
    public partial class MainView : Form
    {
        #region Private Fields

        private readonly DataSeeder _dataSeeder;
        private readonly FlightSimService _flightSimService;
        private readonly ILogger<MainView> _logger;
        private readonly ManagerService _managerService;
        private readonly MediaService _mediaService;
        private readonly ProfileRepository _profileRepository;
        private readonly TextContent _textContent;

        #endregion Private Fields

        #region Public Constructors

        public MainView(ILogger<MainView> logger,
            DataSeeder dataSeeder,
            TextContent textContent,
            FlightSimService flightSimService,
            ManagerService managerService,
            ProfileRepository profileRepository,
            MediaService mediaService)
        {
            InitializeComponent();

            _logger = logger;
            _dataSeeder = dataSeeder;
            _textContent = textContent;
            _flightSimService = flightSimService;
            _managerService = managerService;
            _profileRepository = profileRepository;
            _mediaService = mediaService;
            _mediaService.SetHandle(Handle);
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == 0x402)
            {
                _logger.LogTrace("Message from Simconnect.");
                _flightSimService.TriggerReceive();
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void FlightSimConnect_Closed(object sender, EventArgs e)
        {
            _logger.LogDebug("SimConnect is closed.");
        }

        private async Task InitializeSimConnectAsync(FlightSimService simConnect)
        {
            while (true)
            {
                try
                {
                    simConnect.Initialize(Handle);
                    _logger.LogInformation("Connected to Sim");
                    break;
                }
                catch (COMException ex)
                {
                    _logger.LogError(ex, "SimConnect error.");
                    await Task.Delay(5000).ConfigureAwait(true);
                }
            }
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _flightSimService.CloseConnection();
        }

        private async void MainView_ShownAsync(object sender, EventArgs e)
        {
            if (Directory.Exists("import"))
            {
                Directory.Delete("import", true);
            }

            if (Directory.Exists("export"))
            {
                Directory.Delete("export", true);
            }

            LoadingLabel.Text = _textContent.Loading;
            LoadingDialog.Visible = true;
            Application.DoEvents();

            await _dataSeeder.CheckNecessaryDataAsync();
            var profiles = await _profileRepository.GetAllProfiles();
            foreach (var profile in profiles)
            {
                ProfileSelect.Items.Add(profile.Name);
            }

            LoadingDialog.Visible = false;

            _flightSimService.Closed += FlightSimConnect_Closed;
            await InitializeSimConnectAsync(_flightSimService);
        }

        private void OpenDebug_Click(object sender, EventArgs e)
        {
            var debug = (Form)Program.ServiceProvider.GetService((typeof(DebugView)));
            debug.ShowDialog();
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            var settings = (Form)Program.ServiceProvider.GetService((typeof(SettingsView)));
            settings.ShowDialog();
        }

        private async void StartSim_Click(object sender, EventArgs e)
        {
            if (StartSim.Text == "Start")
            {
                StartSim.Text = "Stop";
                var profile = await _profileRepository.GetProfileByNameAsync(ProfileSelect.GetItemText(ProfileSelect.SelectedItem)).ConfigureAwait(false);
                bool groundService = GroundServiceRequest.Checked;
                _managerService.StartSimConnection(profile, groundService, EndBoardingCheck.Checked, (int)(BoardingMinutes.Value * 60));
            }
            else
            {
                StartSim.Text = "Start";
                _managerService.StopAmbiance();
            }
        }

        private void ToggleJetway_Click(object sender, EventArgs e)
        {
            _flightSimService.ToggleGroundService();
        }

        #endregion Private Methods
    }
}