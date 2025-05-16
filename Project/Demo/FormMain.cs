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
//using Squirrel;
using System.Diagnostics;

namespace MonitorConfigDemo
{
    public partial class FormMain : Form
    {
        Monitors iMonitors;

        public FormMain()
        {
            InitializeComponent();

            UpdateMonitors();

            // Show version in title bar
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            Text += " - v" + version;
        }

        /// <summary>
        /// Check for application update and ask the user to proceed if any.
        /// </summary>
        async void SquirrelUpdate()
        {
            // Check for Squirrel application update
#if !DEBUG
            ReleaseEntry release = null;
            using (var mgr = new UpdateManager("http://publish.slions.net/MonitorConfigDemo"))
            {
                //
                UpdateInfo updateInfo = await mgr.CheckForUpdate();
                if (updateInfo.ReleasesToApply.Any()) // Check if we have any update
                {
                    // We have an update ask our user if he wants it
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    string msg =    "New version available!" +
                                    "\n\nCurrent version: " + updateInfo.CurrentlyInstalledVersion.Version +
                                    "\nNew version: " + updateInfo.FutureReleaseEntry.Version +
                                    "\n\nUpdate application now?";
                    DialogResult dialogResult = MessageBox.Show(msg, fvi.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // User wants it, do the update
                        release = await mgr.UpdateApp();
                    }
                    else
                    {
                        // User cancel an update enable manual update option
                        iToolStripMenuItemUpdate.Visible = true;
                    }
                }
            }

            // Restart the app
            if (release!=null)
            {
                UpdateManager.RestartApp();
            }           
#endif
        }


        /// <summary>
        /// Our virtual monitor was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iComboBoxVirtualMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            iLabelDeviceName.Text = CurrentVirtualMonitor().DeviceName;
            PopulatePhysicalMonitors();
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateColorTemperature()
        {
            //
            iComboBoxColorTemperature.Items.Clear();
            //
            if (iCheckBoxColorTemperatureUnlock.Checked)
            {
                // Unlock mode provides all choices
                // This was designed to be able to test Dell monitors not reporting capabilities properly
                foreach (ColorTemperature t in Enum.GetValues(typeof(ColorTemperature)))
                {
                    iComboBoxColorTemperature.Items.Add(t);
                }

                return;
            }

            PhysicalMonitor pm = CurrentPhysicalMonitor();
            ColorTemperature current = pm.ColorTemperature;
            //
            iComboBoxColorTemperature.Items.Add(ColorTemperature.Unknown);

            // Add supported color temperature to our combo box
            // For those Dell monitors not reporting supported color temperature we added the current check
            // That makes sure the current profile is in the combo box

            if (pm.SupportsColorTemperature4000K || current== ColorTemperature.K4000)
            {
                iComboBoxColorTemperature.Items.Add(ColorTemperature.K4000);
            }

            if (pm.SupportsColorTemperature5000K || current == ColorTemperature.K5000)
            {
                iComboBoxColorTemperature.Items.Add(ColorTemperature.K5000);
            }

            if (pm.SupportsColorTemperature6500K || current == ColorTemperature.K6500)
            {
                iComboBoxColorTemperature.Items.Add(ColorTemperature.K6500);
            }

            if (pm.SupportsColorTemperature7500K || current == ColorTemperature.K7500)
            {
                iComboBoxColorTemperature.Items.Add(ColorTemperature.K7500);
            }

            if (pm.SupportsColorTemperature8200K || current == ColorTemperature.K8200)
            {
                iComboBoxColorTemperature.Items.Add(ColorTemperature.K8200);
            }

            if (pm.SupportsColorTemperature9300K || current == ColorTemperature.K9300)
            {
                iComboBoxColorTemperature.Items.Add(ColorTemperature.K9300);
            }

            if (pm.SupportsColorTemperature10000K || current == ColorTemperature.K10000)
            {
                iComboBoxColorTemperature.Items.Add(ColorTemperature.K10000);
            }

            if (pm.SupportsColorTemperature11500K || current == ColorTemperature.K11500)
            {
                iComboBoxColorTemperature.Items.Add(ColorTemperature.K11500);
            }            
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
                String itemText = m.FriendlyName + " ( " + m.Rect.Size.Width + " x " + m.Rect.Size.Height + " )";
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
            VirtualMonitor vm = CurrentVirtualMonitor();
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
        private void UpdateColorTemperature()
        {
            // Color temperature
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            PopulateColorTemperature();
            // We don't enforce disabling color temperature as notably Dell P2312H supports it but pretends it does not.
            iComboBoxColorTemperature.Enabled = iCheckBoxColorTemperatureUnlock.Checked || pm.SupportsColorTemperature;
            iComboBoxColorTemperature.SelectedItem = pm.ColorTemperature;
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

            // Color temperature
            UpdateColorTemperature();

            // Gain
            iGroupBoxGain.Enabled = pm.SupportsRgbGain;
            SetupTrackBar(iTrackBarGainRed, pm.GainRed);
            SetupTrackBar(iTrackBarGainGreen, pm.GainGreen);
            SetupTrackBar(iTrackBarGainBlue, pm.GainBlue);

            // Drive
            iGroupBoxDrive.Enabled = pm.SupportsRgbDrive;
            SetupTrackBar(iTrackBarDriveRed, pm.DriveRed);
            SetupTrackBar(iTrackBarDriveGreen, pm.DriveGreen);
            SetupTrackBar(iTrackBarDriveBlue, pm.DriveBlue);

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
            PhysicalMonitor pm = CurrentVirtualMonitor().PhysicalMonitors[iComboBoxPhysicalMonitors.SelectedIndex];
            return pm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private VirtualMonitor CurrentVirtualMonitor()
        {
            return iMonitors.VirtualMonitors[iComboBoxVirtualMonitors.SelectedIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        private void WaitForPhysicalMonitorToComeBackOnline()
        {
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            // Wait for the monitor to come back online
            int max = 40;
            while (!pm.Construct() && max >= 0)
            {
                max--;
                Thread.Sleep(250); // Added that delay as Dell P2312H is not responsive immediately after reset                
            }
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

        private void iTrackBarBrightness_MouseCaptureChanged(object sender, EventArgs e)
        {
            // In case other properties were altered by our brightness changes, reload them
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

        private void iTrackBarContrast_MouseCaptureChanged(object sender, EventArgs e)
        {
            // Sent when the user stops scrolling
            // On DELL U2413 any Drive component actually changes the contrast
            // and the contrast changes the Drives, just don't ask
            UpdatePhysicalMonitor();
            // Doing the above upon scrolling is too slow so we only do that
            // when the user is done scrolling
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
            WaitForPhysicalMonitorToComeBackOnline();
            // Update our UI
            UpdatePhysicalMonitor();
        }

        private void iButtonColorReset_Click(object sender, EventArgs e)
        {
            // Initiate reset
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.RestoreFactoryColorDefault();
            WaitForPhysicalMonitorToComeBackOnline();
            // Update our UI
            UpdatePhysicalMonitor();
        }

        ////

        private void iTrackBarGainRed_MouseCaptureChanged(object sender, EventArgs e)
        {
            // When user is down scrolling update all properties
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

        /////

        private void iTrackBarGainGreen_MouseCaptureChanged(object sender, EventArgs e)
        {
            // When user is down scrolling update all properties
            UpdatePhysicalMonitor();
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
            UpdateColorTemperature();
        }

        /////

        private void iTrackBarGainBlue_MouseCaptureChanged(object sender, EventArgs e)
        {
            // When user is down scrolling update all properties
            UpdatePhysicalMonitor();
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
            UpdateColorTemperature();
        }

        private void iComboBoxColorTemperature_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.ColorTemperature = (ColorTemperature)iComboBoxColorTemperature.SelectedItem;
            WaitForPhysicalMonitorToComeBackOnline(); // Dell U2413 was being too slow again
            // We will need to fetch the new color settings
            // In fact changing color temperature often just changes color gain to some predefined value            
            UpdatePhysicalMonitor();
        }

        private void iCheckBoxColorTemperatureUnlock_CheckedChanged(object sender, EventArgs e)
        {
            UpdateColorTemperature();
        }

        /////

        private void iTrackBarDriveRed_MouseCaptureChanged(object sender, EventArgs e)
        {
            // On DELL U2413 any Drive component actually changes the contrast
            UpdatePhysicalMonitor();
        }

        private void iTrackBarDriveRed_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(iTrackBarDriveRed, iLabelDriveRedPercent, iToolTip);
        }

        private void iTrackBarDriveRed_Scroll(object sender, EventArgs e)
        {
            // Set Drive red
            Setting red = new Setting((uint)iTrackBarDriveRed.Minimum, (uint)iTrackBarDriveRed.Value, (uint)iTrackBarDriveRed.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.DriveRed = red;
        }

        /////

        private void iTrackBarDriveGreen_MouseCaptureChanged(object sender, EventArgs e)
        {
            // On DELL U2413 any Drive component actually changes the contrast
            UpdatePhysicalMonitor();
        }

        private void iTrackBarDriveGreen_ValueChanged(object sender, EventArgs e)
        {
            // On DELL U2413 any Drive component actually changes the contrast
            UpdateTrackBar(iTrackBarDriveGreen, iLabelDriveGreenPercent, iToolTip);
        }

        private void iTrackBarDriveGreen_Scroll(object sender, EventArgs e)
        {
            // Set Drive green
            Setting green = new Setting((uint)iTrackBarDriveGreen.Minimum, (uint)iTrackBarDriveGreen.Value, (uint)iTrackBarDriveGreen.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.DriveGreen = green;
        }

        /////

        private void iTrackBarDriveBlue_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void iTrackBarDriveBlue_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(iTrackBarDriveBlue, iLabelDriveBluePercent, iToolTip);
        }

        private void iTrackBarDriveBlue_Scroll(object sender, EventArgs e)
        {
            // Set Drive red
            Setting blue = new Setting((uint)iTrackBarDriveBlue.Minimum, (uint)iTrackBarDriveBlue.Value, (uint)iTrackBarDriveBlue.Maximum);
            PhysicalMonitor pm = CurrentPhysicalMonitor();
            pm.DriveBlue = blue;
            // On DELL U2413 any Drive component actually changes the contrast
            UpdatePhysicalMonitor();
        }

        async private void FormMain_Shown(object sender, EventArgs e)
        {
            SquirrelUpdate();
        }

        async private void iToolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            SquirrelUpdate();
        }

        private void iToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }
    }
}
