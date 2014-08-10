using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Team2.PSU.Wireless.Mesh.View
{
    public partial class ConnectionTimer : ToolStripItem
    {

        private long lngConnectionTime;
        private DateTime startTime;

        public ConnectionTimer()
        {
            InitializeComponent();
        }

        public void StartConnectionTimer()
        {
            tmrConnection.Enabled = true;
            startTime = System.DateTime.Now;
            lblTime.Visible = true;
        }

        public void StopConnectionTimer()
        {
            tmrConnection.Enabled = false;
            lblTime.Visible = false;
            lngConnectionTime = 0;
        }

        private void tmrConnection_Tick(object sender, EventArgs e)
        {
            lblTime.Text = Convert.ToString(System.DateTime.Now - startTime);
        }

        

    }
}
