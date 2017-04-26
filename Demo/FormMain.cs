using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using SharpLib.MonitorConfig;
using System.Threading;

namespace MonitorConfigDemo
{
    public partial class FormMain : Form
    {
        Monitors iMonitors;

        public FormMain()
        {
            InitializeComponent();

            UpdateMonitors();           
        }

        /// <summary>
        /// Our virtual monitor was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iComboBoxVirtualMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePhysicalMonitors();
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateVirtualMonitors()
        {
            iComboBoxVirtualMonitors.Items.Clear();
            // Populate virtual monitor list
            foreach (VirtualMonitor m in iMonitors.VirtualMonitors)
            {
                String itemText = m.Name + " ( " + m.Rect.Size.Width + " x " + m.Rect.Size.Height + " )";
                if (m.IsPrimary())
                {
                    // Mark primary display
                    itemText += " *";
                }
                iComboBoxVirtualMonitors.Items.Add(itemText);
            }

            if (iComboBoxVirtualMonitors.Items.Count > 0) //Defensive
            {
                // Select first monitor
                iComboBoxVirtualMonitors.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void PopulatePhysicalMonitors()
        {
            iComboBoxPhysicalMonitors.Items.Clear();
            // Populate our physical monitor accordingly
            VirtualMonitor vm = iMonitors.VirtualMonitors[iComboBoxVirtualMonitors.SelectedIndex];
            foreach (PhysicalMonitor pm in vm.PhysicalMonitors)
            {
                iComboBoxPhysicalMonitors.Items.Add(pm.Description);
            }

            if (iComboBoxPhysicalMonitors.Items.Count > 0) //Defensive
            {
                // Select first monitor
                iComboBoxPhysicalMonitors.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateMonitors()
        {
            //if (iMonitors!=null)
            //{
            //    iMonitors.Dispose();
            //    iMonitors = null;
            //}
            if (iMonitors == null)
            {
                iMonitors = new Monitors();
            }
            iMonitors.Scan();
            PopulateVirtualMonitors();
        }

        /// <summary>
        /// Update control according to currently selected physical monitor.
        /// </summary>
        private void UpdatePhysicalMonitor()
        {
            // Get our physical monitor
            PhysicalMonitor pm = CurrentPhysicalMonitor();

            // Reset buttons
            iButtonFactoryReset.Enabled = pm.SupportsRestoreFactoryDefaults;
            iButtonColorReset.Enabled = pm.SupportsRestoreFactoryColorDefaults;

            // Monitor Technology Type
            iLabelMonitorTech.Visible = pm.SupportsTechnologyType;
            iLabelMonitorTech.Text = pm.TechnologyTypeName;

            // Brightness update
            iTrackBarBrightness.Enabled = 
                iLabelBrightness.Enabled = 
                iLabelBrightnessPercent.Visible = pm.SupportsBrightness;
            SetupTrackBar(iTrackBarBrightness, pm.Brightness);
            
            // Contrast update
            iTrackBarContrast.Enabled =
                iLabelContrast.Enabled =
                iLabelContrastPercent.Visible = pm.SupportsContrast;
            SetupTrackBar(iTrackBarContrast, pm.Contrast);

            // Gain
            iGroupBoxGain.Enabled = pm.SupportsRgbGain;
            SetupTrackBar(iTrackBarGainRed, pm.GainRed);
            SetupTrackBar(iTrackBarGainGreen, pm.GainGreen);
            SetupTrackBar(iTrackBarGainBlue, pm.GainBlue);

        }

        /// <summary>
        /// Setup a trackbar from the provided setting.
        /// </summary>
        /// <param name="aTrackBar"></param>
        /// <param name="aSetting"></param>
        static void SetupTrackBar(TrackBar aTrackBar, Setting aSetting)
        {
            aTrackBar.Minimum = (int)aSetting.Min;
            aTrackBar.Maximum = (int)aSetting.Max;
            aTrackBar.Value = (int)aSetting.Current;
            if (aTrackBar.Maximum % 10 == 0)
            {
                aTrackBar.TickFrequency = (aTrackBar.Maximum - aTrackBar.Minimum) / 20;
            }
            else // Assume mod 2
            {
                aTrackBar.TickFrequency = 8;
            }

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aTrackBar"></param>
        /// <param name="aLabel"></param>
        /// <param name="aToolTip"></param>
        static void UpdateTrackBar(TrackBar aTrackBar, Label aLabel, ToolTip aToolTip)
        {
            aToolTip.SetToolTip(aTrackBar, aTrackBar.Value.ToString());
            float max = aTrackBar.Maximum - aTrackBar.Minimum;
            float current = aTrackBar.Value - aTrackBar.Minimum;
            int percent = (int)(current / (max / 100));
            aLabel.Text = percent.ToString() + "%";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private PhysicalMonitor CurrentPhysicalMonitor()
        {
            PhysicalMonitor pm = iMonitors.VirtualMonitors[iComboBoxVirtualMonitors.SelectedIndex].PhysicalMonitors[iComboBoxPhysicalMonitors.SelectedIndex];
            return pm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iButtonRefresh_Click(object sender, EventArgs e)
        {
            UpdateMonitors();
        }

        private void iComboBoxPhysicalMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePhysicalMonitor();
        }

        private void iTrackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(iTrackBarBrightness, iLabelBrightnessPercent, iToolTip);
        }

        private void iTrackBarBrightness_Scroll(object sender, EventArgs e)
        {
            // Set brighness
            Setting brightness = new Setting((uint)iTrackBarBrightness.Minimum, (uint)iTrackBarBrightness.Value, (uint)iTrackBarBrightness.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.Brightness = brightness;
        }

        private void iTrackBarContrast_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(iTrackBarContrast, iLabelContrastPercent, iToolTip);
        }

        private void iTrackBarContrast_Scroll(object sender, EventArgs e)
        {
            // Set contrast
            Setting contrast = new Setting((uint)iTrackBarContrast.Minimum, (uint)iTrackBarContrast.Value, (uint)iTrackBarContrast.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.Contrast = contrast;
        }

        private void iButtonFactoryReset_Click(object sender, EventArgs e)
        {
            // Initiate reset
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.RestoreFactoryDefaults();
            // Wait for the monitor to come back online
            int max = 10;
            while (!pm.Construct() && max >= 0)
            {
                max--;
                Thread.Sleep(1000); // Added that delay as Dell P2312H is not responsive immediately after reset                
            }
            // Update our UI
            UpdatePhysicalMonitor();
        }

        private void iButtonColorReset_Click(object sender, EventArgs e)
        {
            // Initiate reset
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.RestoreFactoryColorDefault();
            // Wait for the monitor to come back online
            int max = 10;
            while (!pm.Construct() && max>=0)
            {
                max--;
                Thread.Sleep(1000); // Added that delay as Dell P2312H is not responsive immediately after reset                
            }
            // Update our UI
            UpdatePhysicalMonitor();
        }

        private void iTrackBarGainRed_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(iTrackBarGainRed, iLabelGainRedPercent, iToolTip);
        }

        private void iTrackBarGainRed_Scroll(object sender, EventArgs e)
        {
            // Set gain red
            Setting red = new Setting((uint)iTrackBarGainRed.Minimum, (uint)iTrackBarGainRed.Value, (uint)iTrackBarGainRed.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.GainRed = red;
        }

        private void iTrackBarGainGreen_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(iTrackBarGainGreen, iLabelGainGreenPercent, iToolTip);
        }

        private void iTrackBarGainGreen_Scroll(object sender, EventArgs e)
        {
            // Set gain green
            Setting green = new Setting((uint)iTrackBarGainGreen.Minimum, (uint)iTrackBarGainGreen.Value, (uint)iTrackBarGainGreen.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.GainGreen = green;
        }

        private void iTrackBarGainBlue_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(iTrackBarGainBlue, iLabelGainBluePercent, iToolTip);
        }

        private void iTrackBarGainBlue_Scroll(object sender, EventArgs e)
        {
            // Set gain red
            Setting blue = new Setting((uint)iTrackBarGainBlue.Minimum, (uint)iTrackBarGainBlue.Value, (uint)iTrackBarGainBlue.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.GainBlue = blue;
        }

    }
}
