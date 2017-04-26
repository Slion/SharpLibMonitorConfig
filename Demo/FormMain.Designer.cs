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
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // iComboBoxVirtualMonitors
            // 
            this.iComboBoxVirtualMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iComboBoxVirtualMonitors.FormattingEnabled = true;
            this.iComboBoxVirtualMonitors.Location = new System.Drawing.Point(142, 12);
            this.iComboBoxVirtualMonitors.Name = "iComboBoxVirtualMonitors";
            this.iComboBoxVirtualMonitors.Size = new System.Drawing.Size(203, 21);
            this.iComboBoxVirtualMonitors.TabIndex = 0;
            this.iComboBoxVirtualMonitors.SelectedIndexChanged += new System.EventHandler(this.iComboBoxVirtualMonitors_SelectedIndexChanged);
            // 
            // iButtonRefresh
            // 
            this.iButtonRefresh.Location = new System.Drawing.Point(397, 227);
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
            this.iLabelVirtualMonitors.Location = new System.Drawing.Point(12, 15);
            this.iLabelVirtualMonitors.Name = "iLabelVirtualMonitors";
            this.iLabelVirtualMonitors.Size = new System.Drawing.Size(82, 13);
            this.iLabelVirtualMonitors.TabIndex = 1;
            this.iLabelVirtualMonitors.Text = "Virtual Monitors:";
            // 
            // iComboBoxPhysicalMonitors
            // 
            this.iComboBoxPhysicalMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iComboBoxPhysicalMonitors.FormattingEnabled = true;
            this.iComboBoxPhysicalMonitors.Location = new System.Drawing.Point(142, 39);
            this.iComboBoxPhysicalMonitors.Name = "iComboBoxPhysicalMonitors";
            this.iComboBoxPhysicalMonitors.Size = new System.Drawing.Size(203, 21);
            this.iComboBoxPhysicalMonitors.TabIndex = 3;
            this.iComboBoxPhysicalMonitors.SelectedIndexChanged += new System.EventHandler(this.iComboBoxPhysicalMonitors_SelectedIndexChanged);
            // 
            // iLabelPhysicalMonitors
            // 
            this.iLabelPhysicalMonitors.AutoSize = true;
            this.iLabelPhysicalMonitors.Location = new System.Drawing.Point(12, 42);
            this.iLabelPhysicalMonitors.Name = "iLabelPhysicalMonitors";
            this.iLabelPhysicalMonitors.Size = new System.Drawing.Size(92, 13);
            this.iLabelPhysicalMonitors.TabIndex = 2;
            this.iLabelPhysicalMonitors.Text = "Physical Monitors:";
            // 
            // iLabelBrightness
            // 
            this.iLabelBrightness.AutoSize = true;
            this.iLabelBrightness.Location = new System.Drawing.Point(12, 77);
            this.iLabelBrightness.Name = "iLabelBrightness";
            this.iLabelBrightness.Size = new System.Drawing.Size(59, 13);
            this.iLabelBrightness.TabIndex = 5;
            this.iLabelBrightness.Text = "Brightness:";
            // 
            // iTrackBarBrightness
            // 
            this.iTrackBarBrightness.Location = new System.Drawing.Point(142, 66);
            this.iTrackBarBrightness.Name = "iTrackBarBrightness";
            this.iTrackBarBrightness.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarBrightness.TabIndex = 6;
            this.iTrackBarBrightness.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarBrightness.Scroll += new System.EventHandler(this.iTrackBarBrightness_Scroll);
            this.iTrackBarBrightness.ValueChanged += new System.EventHandler(this.iTrackBarBrightness_ValueChanged);
            // 
            // iLabelBrightnessPercent
            // 
            this.iLabelBrightnessPercent.AutoSize = true;
            this.iLabelBrightnessPercent.Location = new System.Drawing.Point(351, 77);
            this.iLabelBrightnessPercent.Name = "iLabelBrightnessPercent";
            this.iLabelBrightnessPercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelBrightnessPercent.TabIndex = 7;
            this.iLabelBrightnessPercent.Text = "0%";
            // 
            // iLabelContrastPercent
            // 
            this.iLabelContrastPercent.AutoSize = true;
            this.iLabelContrastPercent.Location = new System.Drawing.Point(351, 128);
            this.iLabelContrastPercent.Name = "iLabelContrastPercent";
            this.iLabelContrastPercent.Size = new System.Drawing.Size(21, 13);
            this.iLabelContrastPercent.TabIndex = 10;
            this.iLabelContrastPercent.Text = "0%";
            // 
            // iTrackBarContrast
            // 
            this.iTrackBarContrast.Location = new System.Drawing.Point(142, 117);
            this.iTrackBarContrast.Name = "iTrackBarContrast";
            this.iTrackBarContrast.Size = new System.Drawing.Size(203, 45);
            this.iTrackBarContrast.TabIndex = 9;
            this.iTrackBarContrast.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.iTrackBarContrast.Scroll += new System.EventHandler(this.iTrackBarContrast_Scroll);
            this.iTrackBarContrast.ValueChanged += new System.EventHandler(this.iTrackBarContrast_ValueChanged);
            // 
            // iLabelContrast
            // 
            this.iLabelContrast.AutoSize = true;
            this.iLabelContrast.Location = new System.Drawing.Point(12, 128);
            this.iLabelContrast.Name = "iLabelContrast";
            this.iLabelContrast.Size = new System.Drawing.Size(49, 13);
            this.iLabelContrast.TabIndex = 8;
            this.iLabelContrast.Text = "Contrast:";
            // 
            // iButtonColorReset
            // 
            this.iButtonColorReset.Location = new System.Drawing.Point(102, 227);
            this.iButtonColorReset.Name = "iButtonColorReset";
            this.iButtonColorReset.Size = new System.Drawing.Size(75, 23);
            this.iButtonColorReset.TabIndex = 11;
            this.iButtonColorReset.Text = "Color Reset";
            this.iButtonColorReset.UseVisualStyleBackColor = true;
            this.iButtonColorReset.Click += new System.EventHandler(this.iButtonColorReset_Click);
            // 
            // iButtonFactoryReset
            // 
            this.iButtonFactoryReset.Location = new System.Drawing.Point(12, 227);
            this.iButtonFactoryReset.Name = "iButtonFactoryReset";
            this.iButtonFactoryReset.Size = new System.Drawing.Size(84, 23);
            this.iButtonFactoryReset.TabIndex = 12;
            this.iButtonFactoryReset.Text = "Factory Reset";
            this.iButtonFactoryReset.UseVisualStyleBackColor = true;
            this.iButtonFactoryReset.Click += new System.EventHandler(this.iButtonFactoryReset_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
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
            this.Name = "FormMain";
            this.Text = "Monitor Configuration Demo";
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrackBarContrast)).EndInit();
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
    }
}

