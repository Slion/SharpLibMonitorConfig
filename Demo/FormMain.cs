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

            iMonitors = new Monitors();
            iMonitors.Scan();

            //Rect rect;
            //rect.S

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

            if (iComboBoxVirtualMonitors.Items.Count>0)
            {
                // Select first monitor
                iComboBoxVirtualMonitors.SelectedIndex = 0;
            }
            

        }
    }
}
