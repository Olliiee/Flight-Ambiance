
namespace Org.Strausshome.FS.CrewSoundsNG
{
    partial class SoundProfileView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundProfileView));
            this.ProfileList = new System.Windows.Forms.ComboBox();
            this.AddNewProfile = new System.Windows.Forms.Button();
            this.AvFlightStatusItems = new System.Windows.Forms.ListBox();
            this.ProfileBox = new System.Windows.Forms.GroupBox();
            this.ProfileItemDown = new System.Windows.Forms.Button();
            this.ProfileItemUp = new System.Windows.Forms.Button();
            this.UsedFlightStatusItemsView = new System.Windows.Forms.ListView();
            this.ProfileItemId = new System.Windows.Forms.ColumnHeader();
            this.ProfileFlightStatus = new System.Windows.Forms.ColumnHeader();
            this.ItemIsParkingBrakeSet = new System.Windows.Forms.CheckBox();
            this.ItemIsGearDown = new System.Windows.Forms.CheckBox();
            this.RemoveFlightStatus = new System.Windows.Forms.Button();
            this.ItemIsEngineRunning = new System.Windows.Forms.CheckBox();
            this.AddFlightStatus = new System.Windows.Forms.Button();
            this.ItemIsOnGround = new System.Windows.Forms.CheckBox();
            this.ItemExitOpen = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ItemGroundSpeed = new System.Windows.Forms.TextBox();
            this.ItemAltitude = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ItemRadioAltitude = new System.Windows.Forms.TextBox();
            this.ItemVerticalSpeed = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ProfileItemData = new System.Windows.Forms.GroupBox();
            this.PlayMedia = new System.Windows.Forms.Button();
            this.MediaFileViewer = new System.Windows.Forms.ListView();
            this.Id = new System.Windows.Forms.ColumnHeader();
            this.FileName = new System.Windows.Forms.ColumnHeader();
            this.FilePath = new System.Windows.Forms.ColumnHeader();
            this.DeleteMediaFile = new System.Windows.Forms.Button();
            this.AddNewMediaFile = new System.Windows.Forms.Button();
            this.AnnouncementMediaFile = new System.Windows.Forms.RadioButton();
            this.AmbianceMediaFile = new System.Windows.Forms.RadioButton();
            this.MusicMediaType = new System.Windows.Forms.RadioButton();
            this.AddMediaFile = new System.Windows.Forms.OpenFileDialog();
            this.NewProfileName = new System.Windows.Forms.TextBox();
            this.ImportProfile = new System.Windows.Forms.Button();
            this.ExportProfile = new System.Windows.Forms.Button();
            this.ImportProfileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProfileBox.SuspendLayout();
            this.ProfileItemData.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProfileList
            // 
            this.ProfileList.FormattingEnabled = true;
            this.ProfileList.Location = new System.Drawing.Point(13, 48);
            this.ProfileList.Name = "ProfileList";
            this.ProfileList.Size = new System.Drawing.Size(203, 23);
            this.ProfileList.TabIndex = 0;
            this.ProfileList.SelectedIndexChanged += new System.EventHandler(this.ProfileList_SelectedIndexChanged);
            // 
            // AddNewProfile
            // 
            this.AddNewProfile.Location = new System.Drawing.Point(445, 47);
            this.AddNewProfile.Name = "AddNewProfile";
            this.AddNewProfile.Size = new System.Drawing.Size(75, 24);
            this.AddNewProfile.TabIndex = 1;
            this.AddNewProfile.Text = "New";
            this.AddNewProfile.UseVisualStyleBackColor = true;
            this.AddNewProfile.Click += new System.EventHandler(this.AddNewProfile_Click);
            // 
            // AvFlightStatusItems
            // 
            this.AvFlightStatusItems.FormattingEnabled = true;
            this.AvFlightStatusItems.ItemHeight = 15;
            this.AvFlightStatusItems.Location = new System.Drawing.Point(6, 25);
            this.AvFlightStatusItems.Name = "AvFlightStatusItems";
            this.AvFlightStatusItems.Size = new System.Drawing.Size(196, 124);
            this.AvFlightStatusItems.TabIndex = 2;
            // 
            // ProfileBox
            // 
            this.ProfileBox.Controls.Add(this.ProfileItemDown);
            this.ProfileBox.Controls.Add(this.ProfileItemUp);
            this.ProfileBox.Controls.Add(this.UsedFlightStatusItemsView);
            this.ProfileBox.Controls.Add(this.ItemIsParkingBrakeSet);
            this.ProfileBox.Controls.Add(this.ItemIsGearDown);
            this.ProfileBox.Controls.Add(this.RemoveFlightStatus);
            this.ProfileBox.Controls.Add(this.ItemIsEngineRunning);
            this.ProfileBox.Controls.Add(this.AddFlightStatus);
            this.ProfileBox.Controls.Add(this.ItemIsOnGround);
            this.ProfileBox.Controls.Add(this.ItemExitOpen);
            this.ProfileBox.Controls.Add(this.AvFlightStatusItems);
            this.ProfileBox.Controls.Add(this.label12);
            this.ProfileBox.Controls.Add(this.label8);
            this.ProfileBox.Controls.Add(this.ItemGroundSpeed);
            this.ProfileBox.Controls.Add(this.ItemAltitude);
            this.ProfileBox.Controls.Add(this.label11);
            this.ProfileBox.Controls.Add(this.label9);
            this.ProfileBox.Controls.Add(this.ItemRadioAltitude);
            this.ProfileBox.Controls.Add(this.ItemVerticalSpeed);
            this.ProfileBox.Controls.Add(this.label10);
            this.ProfileBox.Location = new System.Drawing.Point(16, 77);
            this.ProfileBox.Name = "ProfileBox";
            this.ProfileBox.Size = new System.Drawing.Size(504, 320);
            this.ProfileBox.TabIndex = 3;
            this.ProfileBox.TabStop = false;
            this.ProfileBox.Text = "Profile";
            // 
            // ProfileItemDown
            // 
            this.ProfileItemDown.Location = new System.Drawing.Point(442, 126);
            this.ProfileItemDown.Name = "ProfileItemDown";
            this.ProfileItemDown.Size = new System.Drawing.Size(54, 23);
            this.ProfileItemDown.TabIndex = 53;
            this.ProfileItemDown.Text = "Down";
            this.ProfileItemDown.UseVisualStyleBackColor = true;
            this.ProfileItemDown.Click += new System.EventHandler(this.ProfileItemDown_Click);
            // 
            // ProfileItemUp
            // 
            this.ProfileItemUp.Location = new System.Drawing.Point(442, 25);
            this.ProfileItemUp.Name = "ProfileItemUp";
            this.ProfileItemUp.Size = new System.Drawing.Size(54, 23);
            this.ProfileItemUp.TabIndex = 52;
            this.ProfileItemUp.Text = "Up";
            this.ProfileItemUp.UseVisualStyleBackColor = true;
            this.ProfileItemUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProfileItemUp_MouseClick);
            // 
            // UsedFlightStatusItemsView
            // 
            this.UsedFlightStatusItemsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProfileItemId,
            this.ProfileFlightStatus});
            this.UsedFlightStatusItemsView.FullRowSelect = true;
            this.UsedFlightStatusItemsView.HideSelection = false;
            this.UsedFlightStatusItemsView.Location = new System.Drawing.Point(238, 25);
            this.UsedFlightStatusItemsView.MultiSelect = false;
            this.UsedFlightStatusItemsView.Name = "UsedFlightStatusItemsView";
            this.UsedFlightStatusItemsView.Size = new System.Drawing.Size(204, 124);
            this.UsedFlightStatusItemsView.TabIndex = 51;
            this.UsedFlightStatusItemsView.UseCompatibleStateImageBehavior = false;
            this.UsedFlightStatusItemsView.View = System.Windows.Forms.View.Details;
            this.UsedFlightStatusItemsView.SelectedIndexChanged += new System.EventHandler(this.UsedFlightStatusItemsView_SelectedIndexChanged);
            // 
            // ProfileItemId
            // 
            this.ProfileItemId.Text = "Id";
            this.ProfileItemId.Width = 0;
            // 
            // ProfileFlightStatus
            // 
            this.ProfileFlightStatus.Text = "Flight Status";
            this.ProfileFlightStatus.Width = 300;
            // 
            // ItemIsParkingBrakeSet
            // 
            this.ItemIsParkingBrakeSet.AutoSize = true;
            this.ItemIsParkingBrakeSet.Location = new System.Drawing.Point(240, 278);
            this.ItemIsParkingBrakeSet.Name = "ItemIsParkingBrakeSet";
            this.ItemIsParkingBrakeSet.Size = new System.Drawing.Size(109, 19);
            this.ItemIsParkingBrakeSet.TabIndex = 50;
            this.ItemIsParkingBrakeSet.Text = "Parkig brake set";
            this.ItemIsParkingBrakeSet.UseVisualStyleBackColor = true;
            this.ItemIsParkingBrakeSet.CheckedChanged += new System.EventHandler(this.ItemIsParkingBrakeSet_CheckedChanged);
            // 
            // ItemIsGearDown
            // 
            this.ItemIsGearDown.AutoSize = true;
            this.ItemIsGearDown.Location = new System.Drawing.Point(240, 249);
            this.ItemIsGearDown.Name = "ItemIsGearDown";
            this.ItemIsGearDown.Size = new System.Drawing.Size(83, 19);
            this.ItemIsGearDown.TabIndex = 49;
            this.ItemIsGearDown.Text = "Gear down";
            this.ItemIsGearDown.UseVisualStyleBackColor = true;
            this.ItemIsGearDown.CheckedChanged += new System.EventHandler(this.ItemIsGearDown_CheckedChanged);
            // 
            // RemoveFlightStatus
            // 
            this.RemoveFlightStatus.Location = new System.Drawing.Point(208, 126);
            this.RemoveFlightStatus.Name = "RemoveFlightStatus";
            this.RemoveFlightStatus.Size = new System.Drawing.Size(24, 23);
            this.RemoveFlightStatus.TabIndex = 5;
            this.RemoveFlightStatus.Text = "<";
            this.RemoveFlightStatus.UseVisualStyleBackColor = true;
            this.RemoveFlightStatus.Click += new System.EventHandler(this.RemoveFlightStatus_Click);
            // 
            // ItemIsEngineRunning
            // 
            this.ItemIsEngineRunning.AutoSize = true;
            this.ItemIsEngineRunning.Location = new System.Drawing.Point(240, 220);
            this.ItemIsEngineRunning.Name = "ItemIsEngineRunning";
            this.ItemIsEngineRunning.Size = new System.Drawing.Size(107, 19);
            this.ItemIsEngineRunning.TabIndex = 48;
            this.ItemIsEngineRunning.Text = "Engine running";
            this.ItemIsEngineRunning.UseVisualStyleBackColor = true;
            this.ItemIsEngineRunning.CheckedChanged += new System.EventHandler(this.ItemIsEngineRunning_CheckedChanged);
            // 
            // AddFlightStatus
            // 
            this.AddFlightStatus.Location = new System.Drawing.Point(208, 25);
            this.AddFlightStatus.Name = "AddFlightStatus";
            this.AddFlightStatus.Size = new System.Drawing.Size(24, 23);
            this.AddFlightStatus.TabIndex = 4;
            this.AddFlightStatus.Text = ">";
            this.AddFlightStatus.UseVisualStyleBackColor = true;
            this.AddFlightStatus.Click += new System.EventHandler(this.AddFlightStatus_Click);
            // 
            // ItemIsOnGround
            // 
            this.ItemIsOnGround.AutoSize = true;
            this.ItemIsOnGround.Location = new System.Drawing.Point(240, 191);
            this.ItemIsOnGround.Name = "ItemIsOnGround";
            this.ItemIsOnGround.Size = new System.Drawing.Size(93, 19);
            this.ItemIsOnGround.TabIndex = 47;
            this.ItemIsOnGround.Text = "Is on ground";
            this.ItemIsOnGround.UseVisualStyleBackColor = true;
            this.ItemIsOnGround.CheckedChanged += new System.EventHandler(this.ItemIsOnGround_CheckedChanged);
            // 
            // ItemExitOpen
            // 
            this.ItemExitOpen.AutoSize = true;
            this.ItemExitOpen.Location = new System.Drawing.Point(240, 162);
            this.ItemExitOpen.Name = "ItemExitOpen";
            this.ItemExitOpen.Size = new System.Drawing.Size(107, 19);
            this.ItemExitOpen.TabIndex = 46;
            this.ItemExitOpen.Text = "Main Exit Open";
            this.ItemExitOpen.UseVisualStyleBackColor = true;
            this.ItemExitOpen.CheckedChanged += new System.EventHandler(this.ItemExitOpen_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 279);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 15);
            this.label12.TabIndex = 45;
            this.label12.Text = "Ground Speed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "Necessary conditions for this item";
            // 
            // ItemGroundSpeed
            // 
            this.ItemGroundSpeed.Location = new System.Drawing.Point(92, 276);
            this.ItemGroundSpeed.Name = "ItemGroundSpeed";
            this.ItemGroundSpeed.Size = new System.Drawing.Size(134, 23);
            this.ItemGroundSpeed.TabIndex = 44;
            this.ItemGroundSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemGroundSpeed_KeyPress);
            // 
            // ItemAltitude
            // 
            this.ItemAltitude.Location = new System.Drawing.Point(92, 189);
            this.ItemAltitude.Name = "ItemAltitude";
            this.ItemAltitude.Size = new System.Drawing.Size(134, 23);
            this.ItemAltitude.TabIndex = 38;
            this.ItemAltitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemAltitude_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 43;
            this.label11.Text = "Radio Altitude";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 15);
            this.label9.TabIndex = 39;
            this.label9.Text = "Altitude";
            // 
            // ItemRadioAltitude
            // 
            this.ItemRadioAltitude.Location = new System.Drawing.Point(92, 247);
            this.ItemRadioAltitude.Name = "ItemRadioAltitude";
            this.ItemRadioAltitude.Size = new System.Drawing.Size(134, 23);
            this.ItemRadioAltitude.TabIndex = 42;
            this.ItemRadioAltitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemRadioAltitude_KeyPress);
            // 
            // ItemVerticalSpeed
            // 
            this.ItemVerticalSpeed.Location = new System.Drawing.Point(92, 218);
            this.ItemVerticalSpeed.Name = "ItemVerticalSpeed";
            this.ItemVerticalSpeed.Size = new System.Drawing.Size(134, 23);
            this.ItemVerticalSpeed.TabIndex = 40;
            this.ItemVerticalSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemVerticalSpeed_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 15);
            this.label10.TabIndex = 41;
            this.label10.Text = "Vertical Speed";
            // 
            // ProfileItemData
            // 
            this.ProfileItemData.Controls.Add(this.PlayMedia);
            this.ProfileItemData.Controls.Add(this.MediaFileViewer);
            this.ProfileItemData.Controls.Add(this.DeleteMediaFile);
            this.ProfileItemData.Controls.Add(this.AddNewMediaFile);
            this.ProfileItemData.Controls.Add(this.AnnouncementMediaFile);
            this.ProfileItemData.Controls.Add(this.AmbianceMediaFile);
            this.ProfileItemData.Controls.Add(this.MusicMediaType);
            this.ProfileItemData.Location = new System.Drawing.Point(16, 403);
            this.ProfileItemData.Name = "ProfileItemData";
            this.ProfileItemData.Size = new System.Drawing.Size(504, 162);
            this.ProfileItemData.TabIndex = 4;
            this.ProfileItemData.TabStop = false;
            this.ProfileItemData.Text = "Media";
            // 
            // PlayMedia
            // 
            this.PlayMedia.Location = new System.Drawing.Point(129, 124);
            this.PlayMedia.Name = "PlayMedia";
            this.PlayMedia.Size = new System.Drawing.Size(43, 23);
            this.PlayMedia.TabIndex = 7;
            this.PlayMedia.Text = "Play";
            this.PlayMedia.UseVisualStyleBackColor = true;
            this.PlayMedia.Click += new System.EventHandler(this.PlayMedia_Click);
            // 
            // MediaFileViewer
            // 
            this.MediaFileViewer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.FileName,
            this.FilePath});
            this.MediaFileViewer.FullRowSelect = true;
            this.MediaFileViewer.HideSelection = false;
            this.MediaFileViewer.Location = new System.Drawing.Point(7, 21);
            this.MediaFileViewer.MultiSelect = false;
            this.MediaFileViewer.Name = "MediaFileViewer";
            this.MediaFileViewer.Size = new System.Drawing.Size(309, 97);
            this.MediaFileViewer.TabIndex = 6;
            this.MediaFileViewer.UseCompatibleStateImageBehavior = false;
            this.MediaFileViewer.View = System.Windows.Forms.View.Details;
            this.MediaFileViewer.SelectedIndexChanged += new System.EventHandler(this.MediaFileViewer_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 0;
            // 
            // FileName
            // 
            this.FileName.DisplayIndex = 2;
            this.FileName.Text = "file name";
            this.FileName.Width = 300;
            // 
            // FilePath
            // 
            this.FilePath.DisplayIndex = 1;
            this.FilePath.Text = "file path";
            this.FilePath.Width = 120;
            // 
            // DeleteMediaFile
            // 
            this.DeleteMediaFile.Location = new System.Drawing.Point(218, 124);
            this.DeleteMediaFile.Name = "DeleteMediaFile";
            this.DeleteMediaFile.Size = new System.Drawing.Size(75, 23);
            this.DeleteMediaFile.TabIndex = 5;
            this.DeleteMediaFile.Text = "Delete";
            this.DeleteMediaFile.UseVisualStyleBackColor = true;
            this.DeleteMediaFile.Click += new System.EventHandler(this.DeleteMediaFile_Click);
            // 
            // AddNewMediaFile
            // 
            this.AddNewMediaFile.Location = new System.Drawing.Point(7, 124);
            this.AddNewMediaFile.Name = "AddNewMediaFile";
            this.AddNewMediaFile.Size = new System.Drawing.Size(75, 23);
            this.AddNewMediaFile.TabIndex = 4;
            this.AddNewMediaFile.Text = "Add";
            this.AddNewMediaFile.UseVisualStyleBackColor = true;
            this.AddNewMediaFile.Click += new System.EventHandler(this.AddNewMediaFile_Click);
            // 
            // AnnouncementMediaFile
            // 
            this.AnnouncementMediaFile.AutoSize = true;
            this.AnnouncementMediaFile.Location = new System.Drawing.Point(322, 73);
            this.AnnouncementMediaFile.Name = "AnnouncementMediaFile";
            this.AnnouncementMediaFile.Size = new System.Drawing.Size(152, 19);
            this.AnnouncementMediaFile.TabIndex = 3;
            this.AnnouncementMediaFile.TabStop = true;
            this.AnnouncementMediaFile.Text = "Is an announcement file";
            this.AnnouncementMediaFile.UseVisualStyleBackColor = true;
            this.AnnouncementMediaFile.CheckedChanged += new System.EventHandler(this.AnnouncementMediaFile_CheckedChanged);
            // 
            // AmbianceMediaFile
            // 
            this.AmbianceMediaFile.AutoSize = true;
            this.AmbianceMediaFile.Location = new System.Drawing.Point(322, 48);
            this.AmbianceMediaFile.Name = "AmbianceMediaFile";
            this.AmbianceMediaFile.Size = new System.Drawing.Size(123, 19);
            this.AmbianceMediaFile.TabIndex = 2;
            this.AmbianceMediaFile.TabStop = true;
            this.AmbianceMediaFile.Text = "Is an ambiance file";
            this.AmbianceMediaFile.UseVisualStyleBackColor = true;
            this.AmbianceMediaFile.CheckedChanged += new System.EventHandler(this.AmbianceMediaFile_CheckedChanged);
            // 
            // MusicMediaType
            // 
            this.MusicMediaType.AutoSize = true;
            this.MusicMediaType.Location = new System.Drawing.Point(322, 23);
            this.MusicMediaType.Name = "MusicMediaType";
            this.MusicMediaType.Size = new System.Drawing.Size(96, 19);
            this.MusicMediaType.TabIndex = 1;
            this.MusicMediaType.TabStop = true;
            this.MusicMediaType.Text = "Is a music file";
            this.MusicMediaType.UseVisualStyleBackColor = true;
            this.MusicMediaType.CheckedChanged += new System.EventHandler(this.MusicMediaType_CheckedChanged);
            // 
            // AddMediaFile
            // 
            this.AddMediaFile.Filter = "MP3|*.mp3|Wave|*.wav|OGG Vorbis|*.ogg|All|*.*";
            this.AddMediaFile.Multiselect = true;
            this.AddMediaFile.Title = "Add new file";
            // 
            // NewProfileName
            // 
            this.NewProfileName.Location = new System.Drawing.Point(295, 47);
            this.NewProfileName.Name = "NewProfileName";
            this.NewProfileName.Size = new System.Drawing.Size(144, 23);
            this.NewProfileName.TabIndex = 5;
            // 
            // ImportProfile
            // 
            this.ImportProfile.Location = new System.Drawing.Point(13, 13);
            this.ImportProfile.Name = "ImportProfile";
            this.ImportProfile.Size = new System.Drawing.Size(75, 23);
            this.ImportProfile.TabIndex = 6;
            this.ImportProfile.Text = "Import";
            this.ImportProfile.UseVisualStyleBackColor = true;
            this.ImportProfile.Click += new System.EventHandler(this.ImportProfile_Click);
            // 
            // ExportProfile
            // 
            this.ExportProfile.Location = new System.Drawing.Point(141, 13);
            this.ExportProfile.Name = "ExportProfile";
            this.ExportProfile.Size = new System.Drawing.Size(75, 23);
            this.ExportProfile.TabIndex = 7;
            this.ExportProfile.Text = "Export";
            this.ExportProfile.UseVisualStyleBackColor = true;
            this.ExportProfile.Click += new System.EventHandler(this.ExportProfile_ClickAsync);
            // 
            // ImportProfileDialog
            // 
            this.ImportProfileDialog.Filter = "Profile|*.zip";
            this.ImportProfileDialog.Title = "Import Profile";
            // 
            // SoundProfileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 583);
            this.Controls.Add(this.ExportProfile);
            this.Controls.Add(this.ImportProfile);
            this.Controls.Add(this.NewProfileName);
            this.Controls.Add(this.ProfileItemData);
            this.Controls.Add(this.ProfileBox);
            this.Controls.Add(this.AddNewProfile);
            this.Controls.Add(this.ProfileList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoundProfileView";
            this.Text = "Audio Pfrofiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SoundProfileView_FormClosing);
            this.Load += new System.EventHandler(this.SoundProfileView_LoadAsync);
            this.ProfileBox.ResumeLayout(false);
            this.ProfileBox.PerformLayout();
            this.ProfileItemData.ResumeLayout(false);
            this.ProfileItemData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProfileList;
        private System.Windows.Forms.Button AddNewProfile;
        private System.Windows.Forms.ListBox AvFlightStatusItems;
        private System.Windows.Forms.GroupBox ProfileBox;
        private System.Windows.Forms.Button RemoveFlightStatus;
        private System.Windows.Forms.Button AddFlightStatus;
        private System.Windows.Forms.GroupBox ProfileItemData;
        private System.Windows.Forms.CheckBox ItemIsParkingBrakeSet;
        private System.Windows.Forms.CheckBox ItemIsGearDown;
        private System.Windows.Forms.CheckBox ItemIsEngineRunning;
        private System.Windows.Forms.CheckBox ItemIsOnGround;
        private System.Windows.Forms.CheckBox ItemExitOpen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ItemGroundSpeed;
        private System.Windows.Forms.TextBox ItemAltitude;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ItemRadioAltitude;
        private System.Windows.Forms.TextBox ItemVerticalSpeed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton AmbianceMediaFile;
        private System.Windows.Forms.RadioButton MusicMediaType;
        private System.Windows.Forms.RadioButton AnnouncementMediaFile;
        private System.Windows.Forms.Button DeleteMediaFile;
        private System.Windows.Forms.Button AddNewMediaFile;
        private System.Windows.Forms.OpenFileDialog AddMediaFile;
        private System.Windows.Forms.ListView MediaFileViewer;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader FilePath;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ListView UsedFlightStatusItemsView;
        private System.Windows.Forms.ColumnHeader ProfileItemId;
        private System.Windows.Forms.ColumnHeader ProfileFlightStatus;
        private System.Windows.Forms.Button ProfileItemDown;
        private System.Windows.Forms.Button ProfileItemUp;
        private System.Windows.Forms.TextBox NewProfileName;
        private System.Windows.Forms.Button PlayMedia;
        private System.Windows.Forms.Button ImportProfile;
        private System.Windows.Forms.Button ExportProfile;
        private System.Windows.Forms.OpenFileDialog ImportProfileDialog;
    }
}