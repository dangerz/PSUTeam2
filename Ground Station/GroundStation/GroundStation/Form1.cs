using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

using GroundStation.builder;
using GroundStation.classes;

namespace GroundStation
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer msUpdateTimer;
        private static mapBuilder msMapBuiler;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aBoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msMapBuiler = new mapBuilder();

            vehicle vehicle1 = new vehicle("R", 32.647054, -97.393900);
            vehicle vehicle2 = new vehicle("O", 32.646521, -97.394176);
            vehicle vehicle3 = new vehicle("Y", 32.646629, -97.393296);

            msMapBuiler.addVehicle(vehicle1);
            msMapBuiler.addVehicle(vehicle2);
            msMapBuiler.addVehicle(vehicle3);

            mainBrowser.Url = new Uri(msMapBuiler.getURL());
            textBox1.Text = msMapBuiler.getURL();

            msUpdateTimer = new System.Timers.Timer(2000);
            msUpdateTimer.Elapsed += new ElapsedEventHandler(msUpdateTimer_Elapsed);
            msUpdateTimer.Enabled = true;
            
            msUpdateTimer.Start();
        }

        void msUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            msMapBuiler.mVehicles["R"].setLatitude(msMapBuiler.mVehicles["R"].getLatitude() + .0001);
            
            mainBrowser.Url = new Uri(msMapBuiler.getURL());
            textBox1.Text = msMapBuiler.getURL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainBrowser.Url = new Uri(textBox1.Text);
        }
    }
}
