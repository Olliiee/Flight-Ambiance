using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Models;
using Org.Strausshome.FS.CrewSoundsNG.Repositories;
using Org.Strausshome.FS.CrewSoundsNG.Services;

using File = System.IO.File;

namespace Org.Strausshome.FS.CrewSoundsNG
{
    public partial class SoundProfileView : Form
    {
        #region Private Fields

        private readonly FlightStatusRepository _flightStatusRepository;
        private readonly ILogger<SoundProfileView> _logger;
        private readonly MediaFileRepository _mediaFileRepository;
        private readonly MediaService _mediaService;
        private readonly ProfileRepository _profileRepository;
        private readonly SettingsRepository _settingsRepository;
        private int soundChanel = 1;

        #endregion Private Fields

        #region Public Constructors

        public SoundProfileView(ILogger<SoundProfileView> logger,
            SettingsRepository settingsRepository,
            FlightStatusRepository flightStatusRepository,
            ProfileRepository profileRepository,
            MediaFileRepository mediaFileRepository,
            MediaService mediaService)
        {
            InitializeComponent();

            _logger = logger;
            _settingsRepository = settingsRepository;
            _flightStatusRepository = flightStatusRepository;
            _profileRepository = profileRepository;
            _mediaFileRepository = mediaFileRepository;
            _mediaService = mediaService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task AddFlightStatusAsync(string name)
        {
            FlightStatusProfile flightProfile = new()
            {
                Name = name
            };

            flightProfile = await _flightStatusRepository.AddFlightStatusProfileAsync(flightProfile).ConfigureAwait(false);

            Profile profile = new()
            {
                Name = name,
                FlightProfile = flightProfile
            };

            profile = await _profileRepository.AddProfileAsync(profile).ConfigureAwait(false);

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
                VerticalSpeed = 0,
                VerticalOperator = Operator.Equal,
                Altitude = 10000,
                AltitudeOperator = Operator.Less,
                SeatbeltsSignOn = true,
                IsParkingBrakeSet = BoolExt.True,
                CallGroundServices = true,
                Name = "Boarding",
                Sequence = 1,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.True,
                CallGroundServices = false,
                Name = "Welcome on board",
                Sequence = 2,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Name = "After engine 1 start",
                Sequence = 3,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 4,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 5,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 6,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 7,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 8,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 9,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 10,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 11,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 12,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.False,
                CallGroundServices = false,
                Sequence = 13,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.True,
                CallGroundServices = false,
                Sequence = 14,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);

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
                IsParkingBrakeSet = BoolExt.True,
                CallGroundServices = true,
                Sequence = 15,
                Profile = flightProfile
            };

            await _flightStatusRepository.AddFlightStatus(flightStatus);
        }

        #endregion Public Methods

        #region Private Methods

        private static Operator GetOperator(string value)
        {
            if (value.Contains(">"))
            {
                return Operator.Greater;
            }
            else if (value.Contains("<"))
            {
                return Operator.Less;
            }
            else
            {
                return Operator.Equal;
            }
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

        private async void AddFlightStatus_Click(object sender, EventArgs e)
        {
            if (AvFlightStatusItems.SelectedItem == null)
            {
                return;
            }

            var profile = await _profileRepository.GetProfileByNameAsync(ProfileList.GetItemText(ProfileList.SelectedItem)).ConfigureAwait(false);
            var flightProfile = await _flightStatusRepository.GetFlightStatusProfileAsync(profile.FlightProfile.Name).ConfigureAwait(false);

            var status = flightProfile.FlightStatus.Where(c => c.Name == AvFlightStatusItems.GetItemText(AvFlightStatusItems.SelectedItem)).FirstOrDefault();

            ProfileItem profileItem = new()
            {
                FlightStatusId = status.FlightStatusId,
                MediaFile = new System.Collections.Generic.List<MediaFile>(),
                Sequence = profile.ProfileItems.Count + 1,
                Profile = profile
            };

            await _profileRepository.AddProfileItemAsync(profileItem).ConfigureAwait(false);

            UsedFlightStatusItemsView.Items.Clear();
            foreach (var item in profile.ProfileItems.OrderBy(c => c.Sequence))
            {
                ListViewItem profileItemUpdated = new(item.ProfileItemId.ToString());
                profileItemUpdated.SubItems.Add(item.FlightStatus.Name);
                UsedFlightStatusItemsView.Items.Add(profileItemUpdated);
            }

            AvFlightStatusItems.Items.Clear();
            foreach (var item in flightProfile.FlightStatus)
            {
                if (profile.ProfileItems.Where(c => c.FlightStatus == item).FirstOrDefault() == null)
                {
                    AvFlightStatusItems.Items.Add(item.Name);
                }
            }
        }

        private async void AddNewMediaFile_Click(object sender, EventArgs e)
        {
            var profile = await _profileRepository.GetProfileByNameAsync(ProfileList.GetItemText(ProfileList.SelectedItem)).ConfigureAwait(false);

            var result = AddMediaFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileNames = AddMediaFile.SafeFileNames;
                var paths = AddMediaFile.FileNames;

                for (int i = 0; i < paths.Length; i++)
                {
                    try
                    {
                        File.Copy(paths[i], $@"{Directory.GetCurrentDirectory()}\Profiles\{ProfileList.GetItemText(ProfileList.SelectedItem)}\{fileNames[i]}", true);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unable to copy the new file");
                        MessageBox.Show("Unable to copy the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    var newFile = new MediaFile()
                    {
                        Name = fileNames[i],
                        Path = $@"Profiles\{ProfileList.GetItemText(ProfileList.SelectedItem)}\{fileNames[i]}"
                    };

                    var isMusic = MessageBox.Show($"Is this a music file? {fileNames[i]}", "Question 1", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (isMusic == DialogResult.Yes)
                    {
                        newFile.Type = MediaType.Music;
                    }
                    else
                    {
                        var isAnnouncement = MessageBox.Show($"Is this an announcement file? {fileNames[i]}", "Question 2", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (isAnnouncement == DialogResult.Yes)
                        {
                            newFile.Type = MediaType.Announcement;
                        }
                        else
                        {
                            newFile.Type = MediaType.Ambiance;
                        }
                    }

                    newFile = await _mediaFileRepository.AddAsync(newFile).ConfigureAwait(false);
                    var itemId = UsedFlightStatusItemsView.SelectedItems[0].Text;
                    var profileItem = profile.ProfileItems.Where(c => c.ProfileItemId == Convert.ToInt32(itemId)).FirstOrDefault();
                    profileItem.MediaFile.Add(newFile);

                    ListViewItem mediaFile = new(newFile.MediaFileId.ToString());
                    mediaFile.SubItems.Add(newFile.Name);
                    mediaFile.SubItems.Add(newFile.Path);
                    MediaFileViewer.Items.Add(mediaFile);
                }
            }
        }

        private async void AddNewProfile_Click(object sender, EventArgs e)
        {
            var profile = await _profileRepository.GetProfileByNameAsync(NewProfileName.Text).ConfigureAwait(false);
            if (profile != null)
            {
                MessageBox.Show("Profile already exists, please choose another name.", "Profile exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ResetFields();
                AvFlightStatusItems.Items.Clear();
                UsedFlightStatusItemsView.Items.Clear();
                await AddFlightStatusAsync(NewProfileName.Text).ConfigureAwait(false);
                var profiles = await _profileRepository.GetAllProfiles().ConfigureAwait(false);
                ProfileList.Items.Clear();
                ProfileList.Items.AddRange(profiles.Select(c => c.Name).ToArray());
                Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\Profiles\{NewProfileName.Text}");
                NewProfileName.Text = string.Empty;
                ProfileList.Focus();
            }
        }

        private async void AmbianceMediaFile_CheckedChanged(object sender, EventArgs e)
        {
            if (MediaFileViewer.SelectedItems.Count != 1)
            {
                return;
            }

            string mediaId = MediaFileViewer.SelectedItems[0].Text;
            await _profileRepository.UpdateMediaType(Convert.ToInt32(mediaId), MediaType.Ambiance).ConfigureAwait(false);
        }

        private async void AnnouncementMediaFile_CheckedChanged(object sender, EventArgs e)
        {
            if (MediaFileViewer.SelectedItems.Count != 1)
            {
                return;
            }

            string mediaId = MediaFileViewer.SelectedItems[0].Text;
            await _profileRepository.UpdateMediaType(Convert.ToInt32(mediaId), MediaType.Announcement).ConfigureAwait(false);
        }

        private async void DeleteMediaFile_Click(object sender, EventArgs e)
        {
            if (MediaFileViewer.SelectedItems.Count != 1)
            {
                return;
            }

            string mediaId = MediaFileViewer.SelectedItems[0].Text;
            var result = await _profileRepository.RemoveMediaFileAsync(Convert.ToInt32(mediaId)).ConfigureAwait(false);
            if (result)
            {
                MediaFileViewer.Items.Remove(MediaFileViewer.SelectedItems[0]);
            }
        }

        private async void ItemAltitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter != 0 && (ItemAltitude.Text.Contains(" < ") || ItemAltitude.Text.Contains("=") || ItemAltitude.Text.Contains(">")))
            {
                if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
                {
                    return;
                }
                var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
                var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);

                profileItem.FlightStatus.AltitudeOperator = GetOperator(ItemAltitude.Text);
                string resultString = Regex.Match(ItemAltitude.Text, @"\d+").Value;
                profileItem.FlightStatus.Altitude = Convert.ToInt32(resultString);

                var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
                if (!result)
                {
                    MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ItemExitOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }
            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
            var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);
            profileItem.FlightStatus.IsDoorOpen = ItemExitOpen.Checked ? BoolExt.True : BoolExt.False;
            var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
            if (!result)
            {
                MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ItemGroundSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter != 0 && (ItemGroundSpeed.Text.Contains("<") || ItemGroundSpeed.Text.Contains("=") || ItemGroundSpeed.Text.Contains(">")))
            {
                if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
                {
                    return;
                }
                var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
                var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);

                profileItem.FlightStatus.SpeedOperator = GetOperator(ItemGroundSpeed.Text);
                string resultString = Regex.Match(ItemGroundSpeed.Text, @"\d+").Value;
                profileItem.FlightStatus.GroundSpeed = Convert.ToInt32(resultString);

                var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
                if (!result)
                {
                    MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ItemIsEngineRunning_CheckedChanged(object sender, EventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }
            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
            var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);
            profileItem.FlightStatus.IsEngineRun = ItemIsEngineRunning.Checked ? BoolExt.True : BoolExt.False;
            var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
            if (!result)
            {
                MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ItemIsGearDown_CheckedChanged(object sender, EventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }
            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
            var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);
            profileItem.FlightStatus.IsGearDown = ItemIsGearDown.Checked ? BoolExt.True : BoolExt.False;
            var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
            if (!result)
            {
                MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ItemIsOnGround_CheckedChanged(object sender, EventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }
            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
            var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);
            profileItem.FlightStatus.IsOnGround = ItemIsOnGround.Checked ? BoolExt.True : BoolExt.False;
            var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
            if (!result)
            {
                MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ItemIsParkingBrakeSet_CheckedChanged(object sender, EventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }
            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
            var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);
            profileItem.FlightStatus.IsParkingBrakeSet = ItemIsParkingBrakeSet.Checked ? BoolExt.True : BoolExt.False;
            var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
            if (!result)
            {
                MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ItemRadioAltitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter != 0 && (ItemRadioAltitude.Text.Contains("<") || ItemRadioAltitude.Text.Contains("=") || ItemRadioAltitude.Text.Contains(">")))
            {
                if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
                {
                    return;
                }
                var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
                var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);

                profileItem.FlightStatus.RadioOperator = GetOperator(ItemRadioAltitude.Text);
                string resultString = Regex.Match(ItemRadioAltitude.Text, @"\d+").Value;
                profileItem.FlightStatus.RadioAltitude = Convert.ToInt32(resultString);

                var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
                if (!result)
                {
                    MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ItemVerticalSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter != 0 && (ItemVerticalSpeed.Text.Contains("<") || ItemVerticalSpeed.Text.Contains("=") || ItemVerticalSpeed.Text.Contains(">")))
            {
                if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
                {
                    return;
                }
                var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
                var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);

                profileItem.FlightStatus.VerticalOperator = GetOperator(ItemVerticalSpeed.Text);
                string resultString = Regex.Match(ItemVerticalSpeed.Text, @"\d+").Value;
                profileItem.FlightStatus.VerticalSpeed = Convert.ToInt32(resultString);

                var result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
                if (!result)
                {
                    MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void MediaFileViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MediaFileViewer.SelectedItems.Count != 1)
            {
                return;
            }
            string mediaId = MediaFileViewer.SelectedItems[0].Text;
            var mediafileDetails = await _profileRepository.GetMediaDetails(Convert.ToInt32(mediaId)).ConfigureAwait(false);
            switch (mediafileDetails.Type)
            {
                case MediaType.Music:
                    MusicMediaType.Checked = true;
                    break;

                case MediaType.Announcement:
                    AnnouncementMediaFile.Checked = true;
                    break;

                case MediaType.Ambiance:
                    AmbianceMediaFile.Checked = true;
                    break;

                default:
                    break;
            }
        }

        private async void MusicMediaType_CheckedChanged(object sender, EventArgs e)
        {
            if (MediaFileViewer.SelectedItems.Count != 1)
            {
                return;
            }

            string mediaId = MediaFileViewer.SelectedItems[0].Text;
            await _profileRepository.UpdateMediaType(Convert.ToInt32(mediaId), MediaType.Music).ConfigureAwait(false);
        }

        private async void ProfileItemDown_Click(object sender, EventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }

            var profile = await _profileRepository.GetProfileByNameAsync(ProfileList.GetItemText(ProfileList.SelectedItem)).ConfigureAwait(false);
            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
            var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);

            if (profileItem.Sequence > 0 && profileItem.Sequence <= profile.ProfileItems.Count)
            {
                var nextItem = await _profileRepository.GetNextItem(profileItem, profileItem.Sequence + 1).ConfigureAwait(false);
                if (nextItem != null)
                {
                    nextItem.Sequence--;

                    var result = await _profileRepository.UpdateProfileItemAsync(nextItem).ConfigureAwait(false);
                    if (!result)
                    {
                        MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    profileItem.Sequence++;

                    result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
                    if (!result)
                    {
                        MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ProfileList_SelectedIndexChanged(sender, e);

                    UsedFlightStatusItemsView.Items.Clear();
                    foreach (var item in profile.ProfileItems.OrderBy(c => c.Sequence))
                    {
                        ListViewItem profileItemUpdated = new(item.ProfileItemId.ToString());
                        profileItemUpdated.SubItems.Add(item.FlightStatus.Name);
                        UsedFlightStatusItemsView.Items.Add(profileItemUpdated);
                    }

                    UsedFlightStatusItemsView.Items[profileItem.Sequence + 1].Selected = true;
                }
            }
        }

        private async void ProfileItemUp_MouseClick(object sender, MouseEventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }

            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
            var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);
            if (profileItem.Sequence > 1)
            {
                var nextItem = await _profileRepository.GetNextItem(profileItem, profileItem.Sequence - 1).ConfigureAwait(false);
                if (nextItem != null)
                {
                    nextItem.Sequence++;

                    var result = await _profileRepository.UpdateProfileItemAsync(nextItem).ConfigureAwait(false);
                    if (!result)
                    {
                        MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    profileItem.Sequence--;

                    result = await _profileRepository.UpdateProfileItemAsync(profileItem).ConfigureAwait(false);
                    if (!result)
                    {
                        MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ProfileList_SelectedIndexChanged(sender, e);

                    var profile = await _profileRepository.GetProfileByNameAsync(ProfileList.GetItemText(ProfileList.SelectedItem)).ConfigureAwait(false);

                    UsedFlightStatusItemsView.Items.Clear();
                    foreach (var item in profile.ProfileItems.OrderBy(c => c.Sequence))
                    {
                        ListViewItem profileItemUpdated = new(item.ProfileItemId.ToString());
                        profileItemUpdated.SubItems.Add(item.FlightStatus.Name);
                        UsedFlightStatusItemsView.Items.Add(profileItemUpdated);
                    }

                    UsedFlightStatusItemsView.Items[profileItem.Sequence - 1].Selected = true;
                }
            }
        }

        private async void ProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = await _profileRepository.GetProfileByNameAsync(ProfileList.GetItemText(ProfileList.SelectedItem)).ConfigureAwait(false);
            var flightProfile = await _flightStatusRepository.GetFlightStatusProfileAsync(profile.FlightProfile.Name).ConfigureAwait(false);

            UsedFlightStatusItemsView.Items.Clear();
            foreach (var item in profile.ProfileItems.OrderBy(c => c.Sequence))
            {
                ListViewItem profileItem = new(item.ProfileItemId.ToString());
                profileItem.SubItems.Add(item.FlightStatus.Name);
                UsedFlightStatusItemsView.Items.Add(profileItem);
            }

            AvFlightStatusItems.Items.Clear();
            foreach (var item in flightProfile.FlightStatus)
            {
                if (profile.ProfileItems.Where(c => c.FlightStatus == item).FirstOrDefault() == null)
                {
                    AvFlightStatusItems.Items.Add(item.Name);
                }
            }
        }

        private async void RemoveFlightStatus_Click(object sender, EventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }

            var profile = await _profileRepository.GetProfileByNameAsync(ProfileList.GetItemText(ProfileList.SelectedItem)).ConfigureAwait(false);
            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);

            if (!await _profileRepository.RemoveItemAsync(itemId).ConfigureAwait(false))
            {
                MessageBox.Show("Unable to update the profile item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UsedFlightStatusItemsView.Items.Clear();
                foreach (var item in profile.ProfileItems.OrderBy(c => c.Sequence))
                {
                    ListViewItem profileItemUpdated = new(item.ProfileItemId.ToString());
                    profileItemUpdated.SubItems.Add(item.FlightStatus.Name);
                    UsedFlightStatusItemsView.Items.Add(profileItemUpdated);
                }

                var flightProfile = await _flightStatusRepository.GetFlightStatusProfileAsync(profile.FlightProfile.Name).ConfigureAwait(false);
                AvFlightStatusItems.Items.Clear();
                foreach (var item in flightProfile.FlightStatus)
                {
                    if (profile.ProfileItems.Where(c => c.FlightStatus == item).FirstOrDefault() == null)
                    {
                        AvFlightStatusItems.Items.Add(item.Name);
                    }
                }
            }
        }

        private void ResetFields()
        {
            ItemAltitude.Text = string.Empty;
            ItemVerticalSpeed.Text = string.Empty;
            ItemRadioAltitude.Text = string.Empty;
            ItemGroundSpeed.Text = string.Empty;
            ItemExitOpen.Checked = false;
            ItemIsEngineRunning.Checked = false;
            ItemIsGearDown.Checked = false;
            ItemIsParkingBrakeSet.Checked = false;
            ItemIsOnGround.Checked = false;

            MusicMediaType.Checked = false;
            AnnouncementMediaFile.Checked = false;
            AmbianceMediaFile.Checked = false;

            MediaFileViewer.Items.Clear();
        }

        private async void SoundProfileView_LoadAsync(object sender, EventArgs e)
        {
            var profiles = await _profileRepository.GetAllProfiles().ConfigureAwait(false);
            ProfileList.Items.Clear();
            ProfileList.Items.AddRange(profiles.Select(c => c.Name).ToArray());
        }

        private async void UsedFlightStatusItemsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UsedFlightStatusItemsView.SelectedItems.Count != 1)
            {
                return;
            }
            var itemId = Convert.ToInt32(UsedFlightStatusItemsView.SelectedItems[0].Text);
            var profileItem = await _profileRepository.GetProfileItemByIdAsync(itemId).ConfigureAwait(false);

            string profileName = ProfileList.GetItemText(ProfileList.SelectedItem);

            var mediafiles = await _profileRepository.GetMediaFilesByItemNameAsync(profileName, itemId).ConfigureAwait(false);

            MediaFileViewer.Items.Clear();
            foreach (var file in mediafiles)
            {
                ListViewItem mediaFile = new(file.MediaFileId.ToString());
                mediaFile.SubItems.Add(file.Name);
                mediaFile.SubItems.Add(file.Path);
                MediaFileViewer.Items.Add(mediaFile);
            }

            ItemAltitude.Text = GetText(profileItem.FlightStatus.Altitude, profileItem.FlightStatus.AltitudeOperator);
            ItemVerticalSpeed.Text = GetText(profileItem.FlightStatus.VerticalSpeed, profileItem.FlightStatus.VerticalOperator);
            ItemRadioAltitude.Text = GetText(profileItem.FlightStatus.RadioAltitude, profileItem.FlightStatus.RadioOperator);
            ItemGroundSpeed.Text = GetText(profileItem.FlightStatus.GroundSpeed, profileItem.FlightStatus.SpeedOperator);
            ItemExitOpen.Checked = profileItem.FlightStatus.IsDoorOpen == BoolExt.True ? true : false;
            ItemIsEngineRunning.Checked = profileItem.FlightStatus.IsEngineRun == BoolExt.True ? true : false;
            ItemIsGearDown.Checked = profileItem.FlightStatus.IsGearDown == BoolExt.True ? true : false;
            ItemIsParkingBrakeSet.Checked = profileItem.FlightStatus.IsParkingBrakeSet == BoolExt.True ? true : false;
            ItemIsOnGround.Checked = profileItem.FlightStatus.IsOnGround == BoolExt.True ? true : false;

            MusicMediaType.Checked = false;
            AnnouncementMediaFile.Checked = false;
            AmbianceMediaFile.Checked = false;
        }

        #endregion Private Methods

        private async void PlayMedia_Click(object sender, EventArgs e)
        {
            if (MediaFileViewer.SelectedItems.Count != 1)
            {
                return;
            }

            if (PlayMedia.Text == "Play")
            {
                string mediaId = MediaFileViewer.SelectedItems[0].Text;
                var mediafileDetails = await _profileRepository.GetMediaDetails(Convert.ToInt32(mediaId)).ConfigureAwait(false);
                float volume = Convert.ToSingle(await _settingsRepository.GetAmbianceVolume());

                soundChanel = await _mediaService.PlayAudioFileAsync(@mediafileDetails.Path, 1, BoolExt.NotRequired, volume);

                PlayMedia.Text = "Stop";
            }
            else
            {
                _mediaService.StopSound(soundChanel);
                PlayMedia.Text = "Play";
            }
        }
    }
}