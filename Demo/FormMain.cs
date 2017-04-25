using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            foreach(VirtualMonitor m in iMonitors.VirtualMonitors)
            {
                iComboBoxVirtualMonitors.Items.Add(m.Name);
            }

            if (iComboBoxVirtualMonitors.Items.Count>0)
            {
                // Select first monitor
                iComboBoxVirtualMonitors.SelectedIndex = 0;
            }
            

        }
    }
}
