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
            this.iComboBoxVirtualMonitors = new System.Windows.Forms.ComboBox();
            this.iLabelVirtualMonitors = new System.Windows.Forms.Label();
            this.iLabelPhysicalMonitors = new System.Windows.Forms.Label();
            this.iComboBoxPhysicalMonitors = new System.Windows.Forms.ComboBox();
            this.iButtonRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // iComboBoxVirtualMonitors
            // 
            this.iComboBoxVirtualMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iComboBoxVirtualMonitors.FormattingEnabled = true;
            this.iComboBoxVirtualMonitors.Location = new System.Drawing.Point(142, 44);
            this.iComboBoxVirtualMonitors.Name = "iComboBoxVirtualMonitors";
            this.iComboBoxVirtualMonitors.Size = new System.Drawing.Size(203, 21);
            this.iComboBoxVirtualMonitors.TabIndex = 0;
            this.iComboBoxVirtualMonitors.SelectedIndexChanged += new System.EventHandler(this.iComboBoxVirtualMonitors_SelectedIndexChanged);
            // 
            // iLabelVirtualMonitors
            // 
            this.iLabelVirtualMonitors.AutoSize = true;
            this.iLabelVirtualMonitors.Location = new System.Drawing.Point(12, 47);
            this.iLabelVirtualMonitors.Name = "iLabelVirtualMonitors";
            this.iLabelVirtualMonitors.Size = new System.Drawing.Size(82, 13);
            this.iLabelVirtualMonitors.TabIndex = 1;
            this.iLabelVirtualMonitors.Text = "Virtual Monitors:";
            // 
            // iLabelPhysicalMonitors
            // 
            this.iLabelPhysicalMonitors.AutoSize = true;
            this.iLabelPhysicalMonitors.Location = new System.Drawing.Point(12, 101);
            this.iLabelPhysicalMonitors.Name = "iLabelPhysicalMonitors";
            this.iLabelPhysicalMonitors.Size = new System.Drawing.Size(92, 13);
            this.iLabelPhysicalMonitors.TabIndex = 2;
            this.iLabelPhysicalMonitors.Text = "Physical Monitors:";
            // 
            // iComboBoxPhysicalMonitors
            // 
            this.iComboBoxPhysicalMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iComboBoxPhysicalMonitors.FormattingEnabled = true;
            this.iComboBoxPhysicalMonitors.Location = new System.Drawing.Point(142, 98);
            this.iComboBoxPhysicalMonitors.Name = "iComboBoxPhysicalMonitors";
            this.iComboBoxPhysicalMonitors.Size = new System.Drawing.Size(203, 21);
            this.iComboBoxPhysicalMonitors.TabIndex = 3;
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.iButtonRefresh);
            this.Controls.Add(this.iComboBoxPhysicalMonitors);
            this.Controls.Add(this.iLabelPhysicalMonitors);
            this.Controls.Add(this.iLabelVirtualMonitors);
            this.Controls.Add(this.iComboBoxVirtualMonitors);
            this.Name = "FormMain";
            this.Text = "Monitor Configuration Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox iComboBoxVirtualMonitors;
        private System.Windows.Forms.Label iLabelVirtualMonitors;
        private System.Windows.Forms.Label iLabelPhysicalMonitors;
        private System.Windows.Forms.ComboBox iComboBoxPhysicalMonitors;
        private System.Windows.Forms.Button iButtonRefresh;
    }
}

