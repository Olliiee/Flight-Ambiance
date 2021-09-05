
namespace Org.Strausshome.FS.CrewSoundsNG
{
    partial class SettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.SeatbeldsAutoOnLabel = new System.Windows.Forms.Label();
            this.SeatbeltAutoOn = new System.Windows.Forms.NumericUpDown();
            this.SetingsLabel = new System.Windows.Forms.Label();
            this.SeatbeltAutoOff = new System.Windows.Forms.NumericUpDown();
            this.SeatbeltAtoOffLabel = new System.Windows.Forms.Label();
            this.MusicVolume = new System.Windows.Forms.NumericUpDown();
            this.AmbianceVolume = new System.Windows.Forms.NumericUpDown();
            this.MusicVolumeLabel = new System.Windows.Forms.Label();
            this.AmbianceVolumeLabel = new System.Windows.Forms.Label();
            this.UseDoorfEffect = new System.Windows.Forms.CheckBox();
            this.AutoSeatbelts = new System.Windows.Forms.CheckBox();
            this.LowPassFreq = new System.Windows.Forms.NumericUpDown();
            this.LowPassFreqLabel = new System.Windows.Forms.Label();
            this.OpenSoundProfiles = new System.Windows.Forms.Button();
            this.AnnouncementVolumeLabel = new System.Windows.Forms.Label();
            this.AnnouncementVolume = new System.Windows.Forms.NumericUpDown();
            this.HighPassFreqLabel = new System.Windows.Forms.Label();
            this.HighPassFreq = new System.Windows.Forms.NumericUpDown();
            this.LowPassGainLabel = new System.Windows.Forms.Label();
            this.LowPassGain = new System.Windows.Forms.NumericUpDown();
            this.HighPassGainLabel = new System.Windows.Forms.Label();
            this.HighPassGain = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SeatbeltAutoOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatbeltAutoOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbianceVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowPassFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnouncementVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighPassFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowPassGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighPassGain)).BeginInit();
            this.SuspendLayout();
            // 
            // SeatbeldsAutoOnLabel
            // 
            this.SeatbeldsAutoOnLabel.AutoSize = true;
            this.SeatbeldsAutoOnLabel.Location = new System.Drawing.Point(12, 69);
            this.SeatbeldsAutoOnLabel.Name = "SeatbeldsAutoOnLabel";
            this.SeatbeldsAutoOnLabel.Size = new System.Drawing.Size(105, 15);
            this.SeatbeldsAutoOnLabel.TabIndex = 1;
            this.SeatbeldsAutoOnLabel.Text = "Turn seatbelt on at";
            this.SeatbeldsAutoOnLabel.Visible = false;
            // 
            // SeatbeltAutoOn
            // 
            this.SeatbeltAutoOn.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SeatbeltAutoOn.Location = new System.Drawing.Point(150, 69);
            this.SeatbeltAutoOn.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.SeatbeltAutoOn.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SeatbeltAutoOn.Name = "SeatbeltAutoOn";
            this.SeatbeltAutoOn.Size = new System.Drawing.Size(93, 23);
            this.SeatbeltAutoOn.TabIndex = 2;
            this.SeatbeltAutoOn.ThousandsSeparator = true;
            this.SeatbeltAutoOn.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SeatbeltAutoOn.Visible = false;
            this.SeatbeltAutoOn.ValueChanged += new System.EventHandler(this.SeatbeltAutoOn_ValueChanged);
            // 
            // SetingsLabel
            // 
            this.SetingsLabel.AutoSize = true;
            this.SetingsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SetingsLabel.Location = new System.Drawing.Point(13, 13);
            this.SetingsLabel.Name = "SetingsLabel";
            this.SetingsLabel.Size = new System.Drawing.Size(124, 20);
            this.SetingsLabel.TabIndex = 3;
            this.SetingsLabel.Text = "General Settings";
            // 
            // SeatbeltAutoOff
            // 
            this.SeatbeltAutoOff.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SeatbeltAutoOff.Location = new System.Drawing.Point(150, 98);
            this.SeatbeltAutoOff.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.SeatbeltAutoOff.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SeatbeltAutoOff.Name = "SeatbeltAutoOff";
            this.SeatbeltAutoOff.Size = new System.Drawing.Size(93, 23);
            this.SeatbeltAutoOff.TabIndex = 5;
            this.SeatbeltAutoOff.ThousandsSeparator = true;
            this.SeatbeltAutoOff.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SeatbeltAutoOff.Visible = false;
            this.SeatbeltAutoOff.ValueChanged += new System.EventHandler(this.SeatbeltAutoOff_ValueChanged);
            // 
            // SeatbeltAtoOffLabel
            // 
            this.SeatbeltAtoOffLabel.AutoSize = true;
            this.SeatbeltAtoOffLabel.Location = new System.Drawing.Point(12, 100);
            this.SeatbeltAtoOffLabel.Name = "SeatbeltAtoOffLabel";
            this.SeatbeltAtoOffLabel.Size = new System.Drawing.Size(106, 15);
            this.SeatbeltAtoOffLabel.TabIndex = 4;
            this.SeatbeltAtoOffLabel.Text = "Turn seatbelt off at";
            this.SeatbeltAtoOffLabel.Visible = false;
            // 
            // MusicVolume
            // 
            this.MusicVolume.Location = new System.Drawing.Point(150, 127);
            this.MusicVolume.Name = "MusicVolume";
            this.MusicVolume.Size = new System.Drawing.Size(93, 23);
            this.MusicVolume.TabIndex = 6;
            this.MusicVolume.ValueChanged += new System.EventHandler(this.MusicVolume_ValueChanged);
            // 
            // AmbianceVolume
            // 
            this.AmbianceVolume.Location = new System.Drawing.Point(150, 156);
            this.AmbianceVolume.Name = "AmbianceVolume";
            this.AmbianceVolume.Size = new System.Drawing.Size(93, 23);
            this.AmbianceVolume.TabIndex = 7;
            this.AmbianceVolume.ValueChanged += new System.EventHandler(this.AmbianceVolume_ValueChanged);
            // 
            // MusicVolumeLabel
            // 
            this.MusicVolumeLabel.AutoSize = true;
            this.MusicVolumeLabel.Location = new System.Drawing.Point(12, 129);
            this.MusicVolumeLabel.Name = "MusicVolumeLabel";
            this.MusicVolumeLabel.Size = new System.Drawing.Size(82, 15);
            this.MusicVolumeLabel.TabIndex = 8;
            this.MusicVolumeLabel.Text = "Volume Music";
            // 
            // AmbianceVolumeLabel
            // 
            this.AmbianceVolumeLabel.AutoSize = true;
            this.AmbianceVolumeLabel.Location = new System.Drawing.Point(13, 158);
            this.AmbianceVolumeLabel.Name = "AmbianceVolumeLabel";
            this.AmbianceVolumeLabel.Size = new System.Drawing.Size(104, 15);
            this.AmbianceVolumeLabel.TabIndex = 9;
            this.AmbianceVolumeLabel.Text = "Volume Ambiance";
            // 
            // UseDoorfEffect
            // 
            this.UseDoorfEffect.AutoSize = true;
            this.UseDoorfEffect.Location = new System.Drawing.Point(266, 44);
            this.UseDoorfEffect.Name = "UseDoorfEffect";
            this.UseDoorfEffect.Size = new System.Drawing.Size(126, 19);
            this.UseDoorfEffect.TabIndex = 10;
            this.UseDoorfEffect.Text = "Use the door effect";
            this.UseDoorfEffect.UseVisualStyleBackColor = true;
            this.UseDoorfEffect.CheckedChanged += new System.EventHandler(this.UseDoorfEffect_CheckedChangedAsync);
            // 
            // AutoSeatbelts
            // 
            this.AutoSeatbelts.AutoSize = true;
            this.AutoSeatbelts.Location = new System.Drawing.Point(13, 44);
            this.AutoSeatbelts.Name = "AutoSeatbelts";
            this.AutoSeatbelts.Size = new System.Drawing.Size(134, 19);
            this.AutoSeatbelts.TabIndex = 11;
            this.AutoSeatbelts.Text = "Automatic seatbelts ";
            this.AutoSeatbelts.UseVisualStyleBackColor = true;
            this.AutoSeatbelts.Visible = false;
            this.AutoSeatbelts.CheckedChanged += new System.EventHandler(this.AutoSeatbelts_CheckedChanged);
            // 
            // LowPassFreq
            // 
            this.LowPassFreq.Location = new System.Drawing.Point(403, 67);
            this.LowPassFreq.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.LowPassFreq.Name = "LowPassFreq";
            this.LowPassFreq.Size = new System.Drawing.Size(93, 23);
            this.LowPassFreq.TabIndex = 12;
            this.LowPassFreq.ValueChanged += new System.EventHandler(this.LowPassFreq_ValueChanged);
            // 
            // LowPassFreqLabel
            // 
            this.LowPassFreqLabel.AutoSize = true;
            this.LowPassFreqLabel.Location = new System.Drawing.Point(266, 69);
            this.LowPassFreqLabel.Name = "LowPassFreqLabel";
            this.LowPassFreqLabel.Size = new System.Drawing.Size(113, 15);
            this.LowPassFreqLabel.TabIndex = 13;
            this.LowPassFreqLabel.Text = "Low Pass Frequency";
            // 
            // OpenSoundProfiles
            // 
            this.OpenSoundProfiles.Location = new System.Drawing.Point(13, 229);
            this.OpenSoundProfiles.Name = "OpenSoundProfiles";
            this.OpenSoundProfiles.Size = new System.Drawing.Size(75, 42);
            this.OpenSoundProfiles.TabIndex = 15;
            this.OpenSoundProfiles.Text = "Sound Profles";
            this.OpenSoundProfiles.UseVisualStyleBackColor = true;
            this.OpenSoundProfiles.Click += new System.EventHandler(this.OpenSoundProfiles_Click);
            // 
            // AnnouncementVolumeLabel
            // 
            this.AnnouncementVolumeLabel.AutoSize = true;
            this.AnnouncementVolumeLabel.Location = new System.Drawing.Point(13, 187);
            this.AnnouncementVolumeLabel.Name = "AnnouncementVolumeLabel";
            this.AnnouncementVolumeLabel.Size = new System.Drawing.Size(133, 15);
            this.AnnouncementVolumeLabel.TabIndex = 17;
            this.AnnouncementVolumeLabel.Text = "Volume Announcement";
            // 
            // AnnouncementVolume
            // 
            this.AnnouncementVolume.Location = new System.Drawing.Point(150, 185);
            this.AnnouncementVolume.Name = "AnnouncementVolume";
            this.AnnouncementVolume.Size = new System.Drawing.Size(93, 23);
            this.AnnouncementVolume.TabIndex = 16;
            this.AnnouncementVolume.ValueChanged += new System.EventHandler(this.AnnouncementVolume_ValueChanged);
            // 
            // HighPassFreqLabel
            // 
            this.HighPassFreqLabel.AutoSize = true;
            this.HighPassFreqLabel.Location = new System.Drawing.Point(266, 98);
            this.HighPassFreqLabel.Name = "HighPassFreqLabel";
            this.HighPassFreqLabel.Size = new System.Drawing.Size(117, 15);
            this.HighPassFreqLabel.TabIndex = 19;
            this.HighPassFreqLabel.Text = "High Pass Frequency";
            // 
            // HighPassFreq
            // 
            this.HighPassFreq.Location = new System.Drawing.Point(403, 96);
            this.HighPassFreq.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.HighPassFreq.Name = "HighPassFreq";
            this.HighPassFreq.Size = new System.Drawing.Size(93, 23);
            this.HighPassFreq.TabIndex = 18;
            this.HighPassFreq.ValueChanged += new System.EventHandler(this.HighPassFreq_ValueChanged);
            // 
            // LowPassGainLabel
            // 
            this.LowPassGainLabel.AutoSize = true;
            this.LowPassGainLabel.Location = new System.Drawing.Point(266, 127);
            this.LowPassGainLabel.Name = "LowPassGainLabel";
            this.LowPassGainLabel.Size = new System.Drawing.Size(86, 15);
            this.LowPassGainLabel.TabIndex = 21;
            this.LowPassGainLabel.Text = "Gain Level Low";
            // 
            // LowPassGain
            // 
            this.LowPassGain.Location = new System.Drawing.Point(403, 125);
            this.LowPassGain.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.LowPassGain.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
            this.LowPassGain.Name = "LowPassGain";
            this.LowPassGain.Size = new System.Drawing.Size(93, 23);
            this.LowPassGain.TabIndex = 20;
            this.LowPassGain.ValueChanged += new System.EventHandler(this.LowPassGain_ValueChanged);
            // 
            // HighPassGainLabel
            // 
            this.HighPassGainLabel.AutoSize = true;
            this.HighPassGainLabel.Location = new System.Drawing.Point(266, 156);
            this.HighPassGainLabel.Name = "HighPassGainLabel";
            this.HighPassGainLabel.Size = new System.Drawing.Size(90, 15);
            this.HighPassGainLabel.TabIndex = 23;
            this.HighPassGainLabel.Text = "Gain Level High";
            // 
            // HighPassGain
            // 
            this.HighPassGain.Location = new System.Drawing.Point(403, 154);
            this.HighPassGain.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.HighPassGain.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
            this.HighPassGain.Name = "HighPassGain";
            this.HighPassGain.Size = new System.Drawing.Size(93, 23);
            this.HighPassGain.TabIndex = 22;
            this.HighPassGain.ValueChanged += new System.EventHandler(this.HighPassGain_ValueChanged);
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 287);
            this.Controls.Add(this.HighPassGainLabel);
            this.Controls.Add(this.HighPassGain);
            this.Controls.Add(this.LowPassGainLabel);
            this.Controls.Add(this.LowPassGain);
            this.Controls.Add(this.HighPassFreqLabel);
            this.Controls.Add(this.HighPassFreq);
            this.Controls.Add(this.AnnouncementVolumeLabel);
            this.Controls.Add(this.AnnouncementVolume);
            this.Controls.Add(this.OpenSoundProfiles);
            this.Controls.Add(this.LowPassFreqLabel);
            this.Controls.Add(this.LowPassFreq);
            this.Controls.Add(this.AutoSeatbelts);
            this.Controls.Add(this.UseDoorfEffect);
            this.Controls.Add(this.AmbianceVolumeLabel);
            this.Controls.Add(this.MusicVolumeLabel);
            this.Controls.Add(this.AmbianceVolume);
            this.Controls.Add(this.MusicVolume);
            this.Controls.Add(this.SeatbeltAutoOff);
            this.Controls.Add(this.SeatbeltAtoOffLabel);
            this.Controls.Add(this.SetingsLabel);
            this.Controls.Add(this.SeatbeltAutoOn);
            this.Controls.Add(this.SeatbeldsAutoOnLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeatbeltAutoOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatbeltAutoOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbianceVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowPassFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnnouncementVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighPassFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowPassGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighPassGain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SeatbeldsAutoOnLabel;
        private System.Windows.Forms.NumericUpDown SeatbeltAutoOn;
        private System.Windows.Forms.Label SetingsLabel;
        private System.Windows.Forms.NumericUpDown SeatbeltAutoOff;
        private System.Windows.Forms.Label SeatbeltAtoOffLabel;
        private System.Windows.Forms.NumericUpDown MusicVolume;
        private System.Windows.Forms.NumericUpDown AmbianceVolume;
        private System.Windows.Forms.Label MusicVolumeLabel;
        private System.Windows.Forms.Label AmbianceVolumeLabel;
        private System.Windows.Forms.CheckBox UseDoorfEffect;
        private System.Windows.Forms.CheckBox AutoSeatbelts;
        private System.Windows.Forms.NumericUpDown LowPassFreq;
        private System.Windows.Forms.Label LowPassFreqLabel;
        private System.Windows.Forms.Button OpenSoundProfiles;
        private System.Windows.Forms.Label AnnouncementVolumeLabel;
        private System.Windows.Forms.NumericUpDown AnnouncementVolume;
        private System.Windows.Forms.Label HighPassFreqLabel;
        private System.Windows.Forms.NumericUpDown HighPassFreq;
        private System.Windows.Forms.Label LowPassGainLabel;
        private System.Windows.Forms.NumericUpDown LowPassGain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown HighPassGain;
        private System.Windows.Forms.Label HighPassGainLabel;
    }
}