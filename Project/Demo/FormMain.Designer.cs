namespace MonitorConfigDemo
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.iComboBoxVirtualMonitors = new System.Windows.Forms.ComboBox();
            this.iButtonRefresh = new System.Windows.Forms.Button();
            this.iLabelVirtualMonitors = new System.Windows.Forms.Label();
            this.iComboBoxPhysicalMonitors = new System.Windows.Forms.ComboBox();
            this.iLabelPhysicalMonitors = new System.Windows.Forms.Label();
            this.iLabelBrightness = new System.Windows.Forms.Label();
            this.iTrackBarBrightness = new System.Windows.Forms.TrackBar();
            this.iToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.iLabelBrightnessPercent = new System.Windows.Forms.Label();
            this.iLabelContrastPercent = new System.Windows.Forms.Label();
            this.iTrackBarContrast = new System.Windows.Forms.TrackBar();
            this.iLabelContrast = new System.Windows.Forms.Label();
            this.iButtonColorReset = new System.Windows.Forms.Button();
            this.iButtonFactoryReset = new System.Windows.Forms.Button();
            this.iLabelMonitorTech = new System.Windows.Forms.Label();
            this.iGroupBoxGain = new System.Windows.Forms.GroupBox();
            this.iLabelGainBluePercent = new System.Windows.Forms.Label();
            this.iLabelGainGreenPercent = new System.Windows.Forms.Label();
            this.iLabelGainRedPercent = new System.Windows.Forms.Label();
            this.iTrackBarGainBlue = new System.Windows.Forms.TrackBar();
            this.iLabelGainBlue = new System.Windows.Forms.Label();
            this.iTrackBarGainGreen = new System.Windows.Forms.TrackBar();
            this.iLabelGainGreen = new System.Windows.Forms.Label();
            this.iTrackBarGainRed = new System.Windows.Forms.TrackBar();
            this.iLabelGainRed = new System.Windows.Forms.Label();
            this.iLabelColorTemperature = new System.Windows.Forms.Label();
            this.iComboBoxColorTemperature = new System.Windows.Forms.ComboBox();
            this.iCheckBoxColorTemperatureUnlock = new System.Windows.Forms.CheckBox();
            this.iLabelDeviceName = new System.Windows.Forms.Label();
            this.iGroupBoxDrive = new System.Windows.Forms.GroupBox();
            this.iLabelDriveBluePercent = new System.Windows.Forms.Label();
            this.iLabelDriveGreenPercent = new System.Windows.Forms.Label();
            this.iLabelDriveRedPercent = new System.Windows.Forms.Label();
            this.iTrackBarDriveBlue = new System.Windows.Forms.TrackBar();
            this.iLabelDriveBlue = new System.Windows.Forms.Label();
            this.iTrackBarDriveGreen = new System.Windows.Forms.TrackBar();
            this.iLabelDriveGreen = new System.Windows.Forms.Label();
            this.iTrackBarDriveRed = new System.Windows.Forms.TrackBar();
            this.iLabelDriveRed = new System.Windows.Forms.Label();
            this.iMenuStrip = new System.Windows.Forms.MenuStrip();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarContrast)).BeginInit();
            this.iGroupBoxGain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarGainBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarGainGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarGainRed)).BeginInit();
            this.iGroupBoxDrive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarDriveBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarDriveGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarDriveRed)).BeginInit();
            this.iMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // iComboBoxVirtualMonitors
            // 
            this.iComboBoxVirtualMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iComboBoxVirtualMonitors.FormattingEnabled = true;
            this.iComboBoxVirtualMonitors.Location = new System.Drawing.Point(143, 37);
            this.iComboBoxVirtualMonitors.Name = "iComboBoxVirtualMonitors";
            this.iComboBoxVirtualMonitors.Size = new System.Drawing.Size(203, 21);
            this.iComboBoxVirtualMonitors.TabIndex = 0;
            this.iComboBoxVirtualMonitors.SelectedIndexChanged += new System.EventHandler(this.iComboBoxVirtualMonitors_SelectedIndexChanged);
            // 
            // iButtonRefresh
            // 
            this.iButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iButtonRefresh.Location = new System.Drawing.Point(372, 633);
            this.iButtonRefresh.Name = "iButtonRefresh";
            this.iButtonRefresh.Size = new System.Drawing.Size(75, 23);
            this.iButtonRefresh.TabIndex = 4;
            this.iButtonRefresh.Text = "Refresh";
            this.iButtonRefresh.UseVisualStyleBackColor = true;
            this.iButtonRefresh.Click += new System.EventHandler(this.iButtonRefresh_Click);
            // 
            // iLabelVirtualMonitors
            // 
            this.iLabelVirtualMonitors.AutoSize = true;
            this.iLabelVirtualMonitors.Location = new System.Drawing.Point(13, 40);
            this.iLabelVirtualMonitors.Name = "iLabelVirtualMonitors";
            this.iLabelVirtualMonitors.Size = new System.Drawing.Size(82, 13);
            this.iLabelVirtualMonitors.TabIndex = 1;
            this.iLabelVirtualMonitors.Text = "Virtual Monitors:";
            // 
            // iComboBoxPhysicalMonitors
            // 
            this.iComboBoxPhysicalMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iComboBoxPhysicalMonitors.FormattingEnabled = true;
            this.iComboBoxPhysicalMonitors.Location = new System.Drawing.Point(143, 64);
            this.iComboBoxPhysicalMonitors.Name = "iComboBoxPhysicalMonitors";
            this.iComboBoxPhysicalMonitors.Size = new System.Drawing.Size(203, 21);
            this.iComboBoxPhysicalMonitors.TabIndex = 3;
            this.iComboBoxPhysicalMonitors.SelectedIndexChanged += new System.EventHandler(this.iComboBoxPhysicalMonitors_SelectedIndexChanged);
            // 
            // iLabelPhysicalMonitors
            // 
            this.iLabelPhysicalMonitors.AutoSize = true;
            this.iLabelPhysicalMonitors.Location = new System.Drawing.Point(13, 67);
            this.iLabelPhysicalMonitors.Name = "iLabelPhysicalMonitors";
            this.iLabelPhysicalMonitors.Size = new System.Drawing.Size(92, 13);
            this.iLabelPhysicalMonitors.TabIndex = 2;
            this.iLabelPhysicalMonitors.Text = "Physical Monitors:";
            // 
            // iLabelBrightness
            // 
            this.iLabelBrightness.AutoSize = true;
            this.iLabelBrightness.Location = new System.Drawing.Point(13, 102);
            this.iLabelBrightness.Name = "iLabelBrightness";
            this.iLabelBrightness.Size = new System.Drawing.Size(59, 13);
            this.iLabelBrightness.TabIndex = 5;
            this.iLabelBrightness.Text = "Brightness:";
            // 
            // iTrackBarBrightness
            // 
            this.iTrackBarBrightness.Location = new System.Drawing.Point(143, 91);
            this.iTrackBarBrightness.Name = "iTrackBarBrightness";
            this.iTrackBarBrightness.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarBrightness.TabIndex = 6;
            this.iTrackBarBrightness.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarBrightness.Scroll += new System.EventHandler(this.iTrackBarBrightness_Scroll);
            this.iTrackBarBrightness.ValueChanged += new System.EventHandler(this.iTrackBarBrightness_ValueChanged);
            this.iTrackBarBrightness.MouseCaptureChanged += new System.EventHandler(this.iTrackBarBrightness_MouseCaptureChanged);
            // 
            // iLabelBrightnessPercent
            // 
            this.iLabelBrightnessPercent.AutoSize = true;
            this.iLabelBrightnessPercent.Location = new System.Drawing.Point(352, 102);
            this.iLabelBrightnessPercent.Name = "iLabelBrightnessPercent";
            this.iLabelBrightnessPercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelBrightnessPercent.TabIndex = 7;
            this.iLabelBrightnessPercent.Text = "0%";
            // 
            // iLabelContrastPercent
            // 
            this.iLabelContrastPercent.AutoSize = true;
            this.iLabelContrastPercent.Location = new System.Drawing.Point(352, 153);
            this.iLabelContrastPercent.Name = "iLabelContrastPercent";
            this.iLabelContrastPercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelContrastPercent.TabIndex = 10;
            this.iLabelContrastPercent.Text = "0%";
            // 
            // iTrackBarContrast
            // 
            this.iTrackBarContrast.Location = new System.Drawing.Point(143, 142);
            this.iTrackBarContrast.Name = "iTrackBarContrast";
            this.iTrackBarContrast.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarContrast.TabIndex = 9;
            this.iTrackBarContrast.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarContrast.Scroll += new System.EventHandler(this.iTrackBarContrast_Scroll);
            this.iTrackBarContrast.ValueChanged += new System.EventHandler(this.iTrackBarContrast_ValueChanged);
            this.iTrackBarContrast.MouseCaptureChanged += new System.EventHandler(this.iTrackBarContrast_MouseCaptureChanged);
            // 
            // iLabelContrast
            // 
            this.iLabelContrast.AutoSize = true;
            this.iLabelContrast.Location = new System.Drawing.Point(13, 153);
            this.iLabelContrast.Name = "iLabelContrast";
            this.iLabelContrast.Size = new System.Drawing.Size(49, 13);
            this.iLabelContrast.TabIndex = 8;
            this.iLabelContrast.Text = "Contrast:";
            // 
            // iButtonColorReset
            // 
            this.iButtonColorReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iButtonColorReset.Location = new System.Drawing.Point(100, 633);
            this.iButtonColorReset.Name = "iButtonColorReset";
            this.iButtonColorReset.Size = new System.Drawing.Size(75, 23);
            this.iButtonColorReset.TabIndex = 11;
            this.iButtonColorReset.Text = "Color Reset";
            this.iButtonColorReset.UseVisualStyleBackColor = true;
            this.iButtonColorReset.Click += new System.EventHandler(this.iButtonColorReset_Click);
            // 
            // iButtonFactoryReset
            // 
            this.iButtonFactoryReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iButtonFactoryReset.Location = new System.Drawing.Point(10, 633);
            this.iButtonFactoryReset.Name = "iButtonFactoryReset";
            this.iButtonFactoryReset.Size = new System.Drawing.Size(84, 23);
            this.iButtonFactoryReset.TabIndex = 12;
            this.iButtonFactoryReset.Text = "Factory Reset";
            this.iButtonFactoryReset.UseVisualStyleBackColor = true;
            this.iButtonFactoryReset.Click += new System.EventHandler(this.iButtonFactoryReset_Click);
            // 
            // iLabelMonitorTech
            // 
            this.iLabelMonitorTech.AutoSize = true;
            this.iLabelMonitorTech.Location = new System.Drawing.Point(358, 67);
            this.iLabelMonitorTech.Name = "iLabelMonitorTech";
            this.iLabelMonitorTech.Size = new System.Drawing.Size(53, 13);
            this.iLabelMonitorTech.TabIndex = 13;
            this.iLabelMonitorTech.Text = "Unknown";
            // 
            // iGroupBoxGain
            // 
            this.iGroupBoxGain.Controls.Add(this.iLabelGainBluePercent);
            this.iGroupBoxGain.Controls.Add(this.iLabelGainGreenPercent);
            this.iGroupBoxGain.Controls.Add(this.iLabelGainRedPercent);
            this.iGroupBoxGain.Controls.Add(this.iTrackBarGainBlue);
            this.iGroupBoxGain.Controls.Add(this.iLabelGainBlue);
            this.iGroupBoxGain.Controls.Add(this.iTrackBarGainGreen);
            this.iGroupBoxGain.Controls.Add(this.iLabelGainGreen);
            this.iGroupBoxGain.Controls.Add(this.iTrackBarGainRed);
            this.iGroupBoxGain.Controls.Add(this.iLabelGainRed);
            this.iGroupBoxGain.Location = new System.Drawing.Point(13, 238);
            this.iGroupBoxGain.Name = "iGroupBoxGain";
            this.iGroupBoxGain.Size = new System.Drawing.Size(413, 176);
            this.iGroupBoxGain.TabIndex = 14;
            this.iGroupBoxGain.TabStop = false;
            this.iGroupBoxGain.Text = "Gain";
            // 
            // iLabelGainBluePercent
            // 
            this.iLabelGainBluePercent.AutoSize = true;
            this.iLabelGainBluePercent.Location = new System.Drawing.Point(339, 132);
            this.iLabelGainBluePercent.Name = "iLabelGainBluePercent";
            this.iLabelGainBluePercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelGainBluePercent.TabIndex = 15;
            this.iLabelGainBluePercent.Text = "0%";
            // 
            // iLabelGainGreenPercent
            // 
            this.iLabelGainGreenPercent.AutoSize = true;
            this.iLabelGainGreenPercent.Location = new System.Drawing.Point(339, 81);
            this.iLabelGainGreenPercent.Name = "iLabelGainGreenPercent";
            this.iLabelGainGreenPercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelGainGreenPercent.TabIndex = 14;
            this.iLabelGainGreenPercent.Text = "0%";
            // 
            // iLabelGainRedPercent
            // 
            this.iLabelGainRedPercent.AutoSize = true;
            this.iLabelGainRedPercent.Location = new System.Drawing.Point(339, 32);
            this.iLabelGainRedPercent.Name = "iLabelGainRedPercent";
            this.iLabelGainRedPercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelGainRedPercent.TabIndex = 13;
            this.iLabelGainRedPercent.Text = "0%";
            // 
            // iTrackBarGainBlue
            // 
            this.iTrackBarGainBlue.Location = new System.Drawing.Point(130, 121);
            this.iTrackBarGainBlue.Name = "iTrackBarGainBlue";
            this.iTrackBarGainBlue.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarGainBlue.TabIndex = 12;
            this.iTrackBarGainBlue.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarGainBlue.Scroll += new System.EventHandler(this.iTrackBarGainBlue_Scroll);
            this.iTrackBarGainBlue.ValueChanged += new System.EventHandler(this.iTrackBarGainBlue_ValueChanged);
            this.iTrackBarGainBlue.MouseCaptureChanged += new System.EventHandler(this.iTrackBarGainBlue_MouseCaptureChanged);
            // 
            // iLabelGainBlue
            // 
            this.iLabelGainBlue.AutoSize = true;
            this.iLabelGainBlue.Location = new System.Drawing.Point(41, 132);
            this.iLabelGainBlue.Name = "iLabelGainBlue";
            this.iLabelGainBlue.Size = new System.Drawing.Size(31, 13);
            this.iLabelGainBlue.TabIndex = 11;
            this.iLabelGainBlue.Text = "Blue:";
            // 
            // iTrackBarGainGreen
            // 
            this.iTrackBarGainGreen.Location = new System.Drawing.Point(130, 70);
            this.iTrackBarGainGreen.Name = "iTrackBarGainGreen";
            this.iTrackBarGainGreen.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarGainGreen.TabIndex = 10;
            this.iTrackBarGainGreen.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarGainGreen.Scroll += new System.EventHandler(this.iTrackBarGainGreen_Scroll);
            this.iTrackBarGainGreen.ValueChanged += new System.EventHandler(this.iTrackBarGainGreen_ValueChanged);
            this.iTrackBarGainGreen.MouseCaptureChanged += new System.EventHandler(this.iTrackBarGainGreen_MouseCaptureChanged);
            // 
            // iLabelGainGreen
            // 
            this.iLabelGainGreen.AutoSize = true;
            this.iLabelGainGreen.Location = new System.Drawing.Point(41, 81);
            this.iLabelGainGreen.Name = "iLabelGainGreen";
            this.iLabelGainGreen.Size = new System.Drawing.Size(39, 13);
            this.iLabelGainGreen.TabIndex = 9;
            this.iLabelGainGreen.Text = "Green:";
            // 
            // iTrackBarGainRed
            // 
            this.iTrackBarGainRed.Location = new System.Drawing.Point(130, 19);
            this.iTrackBarGainRed.Name = "iTrackBarGainRed";
            this.iTrackBarGainRed.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarGainRed.TabIndex = 8;
            this.iTrackBarGainRed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarGainRed.Scroll += new System.EventHandler(this.iTrackBarGainRed_Scroll);
            this.iTrackBarGainRed.ValueChanged += new System.EventHandler(this.iTrackBarGainRed_ValueChanged);
            this.iTrackBarGainRed.MouseCaptureChanged += new System.EventHandler(this.iTrackBarGainRed_MouseCaptureChanged);
            // 
            // iLabelGainRed
            // 
            this.iLabelGainRed.AutoSize = true;
            this.iLabelGainRed.Location = new System.Drawing.Point(41, 32);
            this.iLabelGainRed.Name = "iLabelGainRed";
            this.iLabelGainRed.Size = new System.Drawing.Size(30, 13);
            this.iLabelGainRed.TabIndex = 7;
            this.iLabelGainRed.Text = "Red:";
            // 
            // iLabelColorTemperature
            // 
            this.iLabelColorTemperature.AutoSize = true;
            this.iLabelColorTemperature.Location = new System.Drawing.Point(13, 196);
            this.iLabelColorTemperature.Name = "iLabelColorTemperature";
            this.iLabelColorTemperature.Size = new System.Drawing.Size(97, 13);
            this.iLabelColorTemperature.TabIndex = 16;
            this.iLabelColorTemperature.Text = "Color Temperature:";
            // 
            // iComboBoxColorTemperature
            // 
            this.iComboBoxColorTemperature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iComboBoxColorTemperature.FormattingEnabled = true;
            this.iComboBoxColorTemperature.Location = new System.Drawing.Point(143, 193);
            this.iComboBoxColorTemperature.Name = "iComboBoxColorTemperature";
            this.iComboBoxColorTemperature.Size = new System.Drawing.Size(203, 21);
            this.iComboBoxColorTemperature.TabIndex = 15;
            this.iComboBoxColorTemperature.SelectionChangeCommitted += new System.EventHandler(this.iComboBoxColorTemperature_SelectionChangeCommitted);
            // 
            // iCheckBoxColorTemperatureUnlock
            // 
            this.iCheckBoxColorTemperatureUnlock.AutoSize = true;
            this.iCheckBoxColorTemperatureUnlock.Location = new System.Drawing.Point(376, 196);
            this.iCheckBoxColorTemperatureUnlock.Name = "iCheckBoxColorTemperatureUnlock";
            this.iCheckBoxColorTemperatureUnlock.Size = new System.Drawing.Size(60, 17);
            this.iCheckBoxColorTemperatureUnlock.TabIndex = 17;
            this.iCheckBoxColorTemperatureUnlock.Text = "Unlock";
            this.iCheckBoxColorTemperatureUnlock.UseVisualStyleBackColor = true;
            this.iCheckBoxColorTemperatureUnlock.CheckedChanged += new System.EventHandler(this.iCheckBoxColorTemperatureUnlock_CheckedChanged);
            // 
            // iLabelDeviceName
            // 
            this.iLabelDeviceName.AutoSize = true;
            this.iLabelDeviceName.Location = new System.Drawing.Point(358, 40);
            this.iLabelDeviceName.Name = "iLabelDeviceName";
            this.iLabelDeviceName.Size = new System.Drawing.Size(53, 13);
            this.iLabelDeviceName.TabIndex = 18;
            this.iLabelDeviceName.Text = "Unknown";
            // 
            // iGroupBoxDrive
            // 
            this.iGroupBoxDrive.Controls.Add(this.iLabelDriveBluePercent);
            this.iGroupBoxDrive.Controls.Add(this.iLabelDriveGreenPercent);
            this.iGroupBoxDrive.Controls.Add(this.iLabelDriveRedPercent);
            this.iGroupBoxDrive.Controls.Add(this.iTrackBarDriveBlue);
            this.iGroupBoxDrive.Controls.Add(this.iLabelDriveBlue);
            this.iGroupBoxDrive.Controls.Add(this.iTrackBarDriveGreen);
            this.iGroupBoxDrive.Controls.Add(this.iLabelDriveGreen);
            this.iGroupBoxDrive.Controls.Add(this.iTrackBarDriveRed);
            this.iGroupBoxDrive.Controls.Add(this.iLabelDriveRed);
            this.iGroupBoxDrive.Location = new System.Drawing.Point(13, 429);
            this.iGroupBoxDrive.Name = "iGroupBoxDrive";
            this.iGroupBoxDrive.Size = new System.Drawing.Size(413, 176);
            this.iGroupBoxDrive.TabIndex = 19;
            this.iGroupBoxDrive.TabStop = false;
            this.iGroupBoxDrive.Text = "Drive";
            // 
            // iLabelDriveBluePercent
            // 
            this.iLabelDriveBluePercent.AutoSize = true;
            this.iLabelDriveBluePercent.Location = new System.Drawing.Point(339, 132);
            this.iLabelDriveBluePercent.Name = "iLabelDriveBluePercent";
            this.iLabelDriveBluePercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelDriveBluePercent.TabIndex = 15;
            this.iLabelDriveBluePercent.Text = "0%";
            // 
            // iLabelDriveGreenPercent
            // 
            this.iLabelDriveGreenPercent.AutoSize = true;
            this.iLabelDriveGreenPercent.Location = new System.Drawing.Point(339, 81);
            this.iLabelDriveGreenPercent.Name = "iLabelDriveGreenPercent";
            this.iLabelDriveGreenPercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelDriveGreenPercent.TabIndex = 14;
            this.iLabelDriveGreenPercent.Text = "0%";
            // 
            // iLabelDriveRedPercent
            // 
            this.iLabelDriveRedPercent.AutoSize = true;
            this.iLabelDriveRedPercent.Location = new System.Drawing.Point(339, 32);
            this.iLabelDriveRedPercent.Name = "iLabelDriveRedPercent";
            this.iLabelDriveRedPercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelDriveRedPercent.TabIndex = 13;
            this.iLabelDriveRedPercent.Text = "0%";
            // 
            // iTrackBarDriveBlue
            // 
            this.iTrackBarDriveBlue.Location = new System.Drawing.Point(130, 121);
            this.iTrackBarDriveBlue.Name = "iTrackBarDriveBlue";
            this.iTrackBarDriveBlue.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarDriveBlue.TabIndex = 12;
            this.iTrackBarDriveBlue.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarDriveBlue.Scroll += new System.EventHandler(this.iTrackBarDriveBlue_Scroll);
            this.iTrackBarDriveBlue.ValueChanged += new System.EventHandler(this.iTrackBarDriveBlue_ValueChanged);
            this.iTrackBarDriveBlue.MouseCaptureChanged += new System.EventHandler(this.iTrackBarDriveBlue_MouseCaptureChanged);
            // 
            // iLabelDriveBlue
            // 
            this.iLabelDriveBlue.AutoSize = true;
            this.iLabelDriveBlue.Location = new System.Drawing.Point(41, 132);
            this.iLabelDriveBlue.Name = "iLabelDriveBlue";
            this.iLabelDriveBlue.Size = new System.Drawing.Size(31, 13);
            this.iLabelDriveBlue.TabIndex = 11;
            this.iLabelDriveBlue.Text = "Blue:";
            // 
            // iTrackBarDriveGreen
            // 
            this.iTrackBarDriveGreen.Location = new System.Drawing.Point(130, 70);
            this.iTrackBarDriveGreen.Name = "iTrackBarDriveGreen";
            this.iTrackBarDriveGreen.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarDriveGreen.TabIndex = 10;
            this.iTrackBarDriveGreen.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarDriveGreen.Scroll += new System.EventHandler(this.iTrackBarDriveGreen_Scroll);
            this.iTrackBarDriveGreen.ValueChanged += new System.EventHandler(this.iTrackBarDriveGreen_ValueChanged);
            this.iTrackBarDriveGreen.MouseCaptureChanged += new System.EventHandler(this.iTrackBarDriveGreen_MouseCaptureChanged);
            // 
            // iLabelDriveGreen
            // 
            this.iLabelDriveGreen.AutoSize = true;
            this.iLabelDriveGreen.Location = new System.Drawing.Point(41, 81);
            this.iLabelDriveGreen.Name = "iLabelDriveGreen";
            this.iLabelDriveGreen.Size = new System.Drawing.Size(39, 13);
            this.iLabelDriveGreen.TabIndex = 9;
            this.iLabelDriveGreen.Text = "Green:";
            // 
            // iTrackBarDriveRed
            // 
            this.iTrackBarDriveRed.Location = new System.Drawing.Point(130, 19);
            this.iTrackBarDriveRed.Name = "iTrackBarDriveRed";
            this.iTrackBarDriveRed.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarDriveRed.TabIndex = 8;
            this.iTrackBarDriveRed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarDriveRed.Scroll += new System.EventHandler(this.iTrackBarDriveRed_Scroll);
            this.iTrackBarDriveRed.ValueChanged += new System.EventHandler(this.iTrackBarDriveRed_ValueChanged);
            this.iTrackBarDriveRed.MouseCaptureChanged += new System.EventHandler(this.iTrackBarDriveRed_MouseCaptureChanged);
            // 
            // iLabelDriveRed
            // 
            this.iLabelDriveRed.AutoSize = true;
            this.iLabelDriveRed.Location = new System.Drawing.Point(41, 32);
            this.iLabelDriveRed.Name = "iLabelDriveRed";
            this.iLabelDriveRed.Size = new System.Drawing.Size(30, 13);
            this.iLabelDriveRed.TabIndex = 7;
            this.iLabelDriveRed.Text = "Red:";
            // 
            // iMenuStrip
            // 
            this.iMenuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.iMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.iMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.iMenuStrip.Name = "iMenuStrip";
            this.iMenuStrip.Size = new System.Drawing.Size(459, 24);
            this.iMenuStrip.TabIndex = 20;
            this.iMenuStrip.Text = "Menu";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(459, 668);
            this.Controls.Add(this.iMenuStrip);
            this.Controls.Add(this.iGroupBoxDrive);
            this.Controls.Add(this.iLabelDeviceName);
            this.Controls.Add(this.iCheckBoxColorTemperatureUnlock);
            this.Controls.Add(this.iLabelColorTemperature);
            this.Controls.Add(this.iComboBoxColorTemperature);
            this.Controls.Add(this.iGroupBoxGain);
            this.Controls.Add(this.iLabelMonitorTech);
            this.Controls.Add(this.iButtonFactoryReset);
            this.Controls.Add(this.iButtonColorReset);
            this.Controls.Add(this.iLabelContrastPercent);
            this.Controls.Add(this.iTrackBarContrast);
            this.Controls.Add(this.iLabelContrast);
            this.Controls.Add(this.iLabelBrightnessPercent);
            this.Controls.Add(this.iTrackBarBrightness);
            this.Controls.Add(this.iLabelBrightness);
            this.Controls.Add(this.iButtonRefresh);
            this.Controls.Add(this.iComboBoxPhysicalMonitors);
            this.Controls.Add(this.iLabelPhysicalMonitors);
            this.Controls.Add(this.iLabelVirtualMonitors);
            this.Controls.Add(this.iComboBoxVirtualMonitors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Monitor Configuration Demo";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarContrast)).EndInit();
            this.iGroupBoxGain.ResumeLayout(false);
            this.iGroupBoxGain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarGainBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarGainGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarGainRed)).EndInit();
            this.iGroupBoxDrive.ResumeLayout(false);
            this.iGroupBoxDrive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarDriveBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarDriveGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarDriveRed)).EndInit();
            this.iMenuStrip.ResumeLayout(false);
            this.iMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox iComboBoxVirtualMonitors;
        private System.Windows.Forms.Button iButtonRefresh;
        private System.Windows.Forms.Label iLabelVirtualMonitors;
        private System.Windows.Forms.ComboBox iComboBoxPhysicalMonitors;
        private System.Windows.Forms.Label iLabelPhysicalMonitors;
        private System.Windows.Forms.Label iLabelBrightness;
        private System.Windows.Forms.TrackBar iTrackBarBrightness;
        private System.Windows.Forms.ToolTip iToolTip;
        private System.Windows.Forms.Label iLabelBrightnessPercent;
        private System.Windows.Forms.Label iLabelContrastPercent;
        private System.Windows.Forms.TrackBar iTrackBarContrast;
        private System.Windows.Forms.Label iLabelContrast;
        private System.Windows.Forms.Button iButtonColorReset;
        private System.Windows.Forms.Button iButtonFactoryReset;
        private System.Windows.Forms.Label iLabelMonitorTech;
        private System.Windows.Forms.GroupBox iGroupBoxGain;
        private System.Windows.Forms.TrackBar iTrackBarGainGreen;
        private System.Windows.Forms.Label iLabelGainGreen;
        private System.Windows.Forms.TrackBar iTrackBarGainRed;
        private System.Windows.Forms.Label iLabelGainRed;
        private System.Windows.Forms.TrackBar iTrackBarGainBlue;
        private System.Windows.Forms.Label iLabelGainBlue;
        private System.Windows.Forms.Label iLabelGainBluePercent;
        private System.Windows.Forms.Label iLabelGainGreenPercent;
        private System.Windows.Forms.Label iLabelGainRedPercent;
        private System.Windows.Forms.Label iLabelColorTemperature;
        private System.Windows.Forms.ComboBox iComboBoxColorTemperature;
        private System.Windows.Forms.CheckBox iCheckBoxColorTemperatureUnlock;
        private System.Windows.Forms.Label iLabelDeviceName;
        private System.Windows.Forms.GroupBox iGroupBoxDrive;
        private System.Windows.Forms.Label iLabelDriveBluePercent;
        private System.Windows.Forms.Label iLabelDriveGreenPercent;
        private System.Windows.Forms.Label iLabelDriveRedPercent;
        private System.Windows.Forms.TrackBar iTrackBarDriveBlue;
        private System.Windows.Forms.Label iLabelDriveBlue;
        private System.Windows.Forms.TrackBar iTrackBarDriveGreen;
        private System.Windows.Forms.Label iLabelDriveGreen;
        private System.Windows.Forms.TrackBar iTrackBarDriveRed;
        private System.Windows.Forms.Label iLabelDriveRed;
        private System.Windows.Forms.MenuStrip iMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

