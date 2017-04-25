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
            iMonitors = new Monitors();
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
            // Brightness update
            iTrackBarBrightness.Enabled = 
                iLabelBrightness.Enabled = 
                iLabelBrightnessPercent.Visible = pm.SupportsBrightness();
            Setting brightness = pm.Brightness;
            iTrackBarBrightness.Minimum = (int)brightness.iMin;
            iTrackBarBrightness.Maximum = (int)brightness.iMax;
            iTrackBarBrightness.Value = (int)brightness.iCurrent;
            iTrackBarBrightness.TickFrequency = (iTrackBarBrightness.Maximum - iTrackBarBrightness.Minimum) / 20;
            // Contrast update
            iTrackBarContrast.Enabled =
                iLabelContrast.Enabled =
                iLabelContrastPercent.Visible = pm.SupportsContrast();
            Setting contrast = pm.Contrast;
            iTrackBarContrast.Minimum = (int)contrast.iMin;
            iTrackBarContrast.Maximum = (int)contrast.iMax;
            iTrackBarContrast.Value = (int)contrast.iCurrent;
            iTrackBarContrast.TickFrequency = (iTrackBarContrast.Maximum - iTrackBarContrast.Minimum) / 20;
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
            iToolTip.SetToolTip(iTrackBarBrightness, iTrackBarBrightness.Value.ToString());
            float max = iTrackBarBrightness.Maximum - iTrackBarBrightness.Minimum;
            float current = iTrackBarBrightness.Value - iTrackBarBrightness.Minimum;
            int percent = (int)(max / 100 * current);
            iLabelBrightnessPercent.Text = percent.ToString() + "%";
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
            iToolTip.SetToolTip(iTrackBarContrast, iTrackBarContrast.Value.ToString());
            float max = iTrackBarContrast.Maximum - iTrackBarContrast.Minimum;
            float current = iTrackBarContrast.Value - iTrackBarContrast.Minimum;
            int percent = (int)(max / 100 * current);
            iLabelContrastPercent.Text = percent.ToString() + "%";
        }

        private void iTrackBarContrast_Scroll(object sender, EventArgs e)
        {
            // Set contrast
            Setting contrast = new Setting((uint)iTrackBarContrast.Minimum, (uint)iTrackBarContrast.Value, (uint)iTrackBarContrast.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.Contrast = contrast;
        }

    }
}
