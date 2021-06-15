
namespace Org.Strausshome.FS.CrewSoundsNG
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.LoadingDialog = new System.Windows.Forms.Panel();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.OpenSettings = new System.Windows.Forms.Button();
            this.StartSim = new System.Windows.Forms.Button();
            this.OpenDebug = new System.Windows.Forms.Button();
            this.ProfileSelect = new System.Windows.Forms.ComboBox();
            this.GroundServiceRequest = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.AudioTest = new System.Windows.Forms.Button();
            this.LoadingDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadingDialog
            // 
            this.LoadingDialog.BackColor = System.Drawing.Color.Silver;
            this.LoadingDialog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoadingDialog.Controls.Add(this.LoadingLabel);
            this.LoadingDialog.Location = new System.Drawing.Point(26, 22);
            this.LoadingDialog.Name = "LoadingDialog";
            this.LoadingDialog.Size = new System.Drawing.Size(200, 82);
            this.LoadingDialog.TabIndex = 0;
            this.LoadingDialog.Visible = false;
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoadingLabel.Location = new System.Drawing.Point(44, 27);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(105, 25);
            this.LoadingLabel.TabIndex = 0;
            this.LoadingLabel.Text = "Loading ...";
            // 
            // OpenSettings
            // 
            this.OpenSettings.Location = new System.Drawing.Point(13, 96);
            this.OpenSettings.Name = "OpenSettings";
            this.OpenSettings.Size = new System.Drawing.Size(75, 23);
            this.OpenSettings.TabIndex = 1;
            this.OpenSettings.Text = "Settings";
            this.OpenSettings.UseVisualStyleBackColor = true;
            this.OpenSettings.Click += new System.EventHandler(this.OpenSettings_Click);
            // 
            // StartSim
            // 
            this.StartSim.Location = new System.Drawing.Point(151, 13);
            this.StartSim.Name = "StartSim";
            this.StartSim.Size = new System.Drawing.Size(75, 23);
            this.StartSim.TabIndex = 3;
            this.StartSim.Text = "Start";
            this.StartSim.UseVisualStyleBackColor = true;
            this.StartSim.Click += new System.EventHandler(this.StartSim_Click);
            // 
            // OpenDebug
            // 
            this.OpenDebug.Location = new System.Drawing.Point(102, 96);
            this.OpenDebug.Name = "OpenDebug";
            this.OpenDebug.Size = new System.Drawing.Size(90, 23);
            this.OpenDebug.TabIndex = 4;
            this.OpenDebug.Text = "Debug Infos";
            this.OpenDebug.UseVisualStyleBackColor = true;
            this.OpenDebug.Click += new System.EventHandler(this.OpenDebug_Click);
            // 
            // ProfileSelect
            // 
            this.ProfileSelect.FormattingEnabled = true;
            this.ProfileSelect.Location = new System.Drawing.Point(13, 12);
            this.ProfileSelect.Name = "ProfileSelect";
            this.ProfileSelect.Size = new System.Drawing.Size(132, 23);
            this.ProfileSelect.TabIndex = 5;
            // 
            // GroundServiceRequest
            // 
            this.GroundServiceRequest.AutoSize = true;
            this.GroundServiceRequest.Location = new System.Drawing.Point(13, 42);
            this.GroundServiceRequest.Name = "GroundServiceRequest";
            this.GroundServiceRequest.Size = new System.Drawing.Size(147, 19);
            this.GroundServiceRequest.TabIndex = 6;
            this.GroundServiceRequest.Text = "Need Ground Services?";
            this.GroundServiceRequest.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(183, 67);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 23);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(13, 71);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(160, 19);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Boarding time in minutes";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // AudioTest
            // 
            this.AudioTest.Location = new System.Drawing.Point(223, 96);
            this.AudioTest.Name = "AudioTest";
            this.AudioTest.Size = new System.Drawing.Size(75, 23);
            this.AudioTest.TabIndex = 9;
            this.AudioTest.Text = "Audio Test";
            this.AudioTest.UseVisualStyleBackColor = true;
            this.AudioTest.Click += new System.EventHandler(this.AudioTest_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 135);
            this.Controls.Add(this.LoadingDialog);
            this.Controls.Add(this.AudioTest);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.GroundServiceRequest);
            this.Controls.Add(this.ProfileSelect);
            this.Controls.Add(this.OpenDebug);
            this.Controls.Add(this.StartSim);
            this.Controls.Add(this.OpenSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "Flight Ambiance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.Shown += new System.EventHandler(this.MainView_ShownAsync);
            this.LoadingDialog.ResumeLayout(false);
            this.LoadingDialog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LoadingDialog;
        private System.Windows.Forms.Label LoadingLabel;
        private System.Windows.Forms.Button OpenSettings;
        private System.Windows.Forms.Button StartSim;
        private System.Windows.Forms.Button OpenDebug;
        private System.Windows.Forms.ComboBox ProfileSelect;
        private System.Windows.Forms.CheckBox GroundServiceRequest;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button AudioTest;
    }
}

