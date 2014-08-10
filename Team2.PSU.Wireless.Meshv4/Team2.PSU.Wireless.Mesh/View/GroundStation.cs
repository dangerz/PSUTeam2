using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;

using Team2.PSU.Wireless.Mesh.Presenter;
using Team2.PSU.Wireless.Mesh.Commands;
using Team2.PSU.Wireless.Mesh.Util;
using Team2.PSU.Wireless.Mesh.Util.MapUtils;
using Team2.PSU.Wireless.Mesh.Model;

namespace Team2.PSU.Wireless.Mesh.View
{

    #region Public Enumerations
    public enum DataMode { Text, Hex, TextFile, Image }
    public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
    #endregion

    public partial class GroundStation : Form
    {
        private TerminalPresenter terminalPresenter = new TerminalPresenter();
        private AircraftViewControl acView;
        private TerminalControl terminalControlView;
        private CommandInterpreter interpreter;
        private DateTime startTime;

        private System.Windows.Forms.Timer mProgressBarTimer;
        private const int mProgressBarMin = 0;
        private int mProgressBarMax;
        private static bool msEnableProgressBar = false;
        private static string msProgressBarDescription = "";

        private static Mutex msProgressBarMutex = new Mutex();

        public GroundStation()
        {
            InitializeComponent();
            acView = new AircraftViewControl(terminalPresenter);
            acView.Dock = DockStyle.Fill;
            terminalControlView = new TerminalControl(terminalPresenter, this);
            tabComPortSettings.Controls.Add(terminalControlView);
            tabAircraftView.Controls.Add(acView);

            mProgressBarMax = 50; // just a start value

            toolStripProgressBar1.Maximum = mProgressBarMax;
            toolStripProgressBar1.Minimum = mProgressBarMin;

            mProgressBarTimer = new System.Windows.Forms.Timer();
            mProgressBarTimer.Interval = 1000;
            mProgressBarTimer.Tick += new EventHandler(updateProgressBarTimer);
            mProgressBarTimer.Start();

            interpreter = new CommandInterpreter(this);
        }

        public void CommandReceived(String commandString)
        {
            Command c = CommandBuilder.getCommand(commandString, interpreter);
            c.Execute();

            if (c.getAction() == Team2.PSU.Wireless.Mesh.Commands.ActionType.startReceiveImageTimer)
            {
                SetCurrentAction("Receiving Image..");
                startProgressBar();
            }
            else
            {
                stopProgressBar();
            }
        }
        public void stopProgressBar()
        {
            msProgressBarMutex.WaitOne();
            msEnableProgressBar = false;
            msProgressBarMutex.ReleaseMutex();
        }
        public void startProgressBar()
        {
            msProgressBarMutex.WaitOne();
            msEnableProgressBar = true;
            msProgressBarMutex.ReleaseMutex();
        }

        void updateProgressBarTimer(object sender, EventArgs e)
        {
            msProgressBarMutex.WaitOne();
            if (GroundStation.msEnableProgressBar)
            {
                toolStripProgressBar1.Visible = true;
                toolStripProgressBar1.Value++;
                if (toolStripProgressBar1.Value >= mProgressBarMax - 5)
                {
                    mProgressBarMax += 5;
                    toolStripProgressBar1.Maximum = mProgressBarMax;
                }
                lblCurrentAction.Text = msProgressBarDescription;
            }
            else
            {
                toolStripProgressBar1.Visible = false;
                toolStripProgressBar1.Value = 0;
                lblCurrentAction.Text = "";
            }
            msProgressBarMutex.ReleaseMutex();
        }

        public void SetCurrentAction(String currentAction)
        {
            msProgressBarMutex.WaitOne();
            msProgressBarDescription = currentAction;
            msProgressBarMutex.ReleaseMutex();
        }
        public void DisplayMapLocation(String serialNumber, GeoLocation location)
        {
            terminalPresenter.DisplayMapLocation(acView.getMapView(), serialNumber, location);
        }

        public void DisplayText(String text)
        {
            terminalPresenter.Log(terminalControlView.GetTextBox(),LogMsgType.Normal, text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public ToolStripStatusLabel GetTimerLabel()
        {
            return lblConnectionTime;
        }

        private void tmrConnection_Tick(object sender, EventArgs e)
        {
            TimeSpan connectTime = System.DateTime.Now.Subtract(startTime);
            lblConnectionTime.Text = Math.Floor(connectTime.TotalHours % 60).ToString().PadLeft(2,'0') + ":" + Math.Floor(connectTime.TotalMinutes % 60).ToString().PadLeft(2,'0') + ":" + Math.Floor(connectTime.TotalSeconds % 60).ToString().PadLeft(2, '0');
        }

        public void ConnectionChanged(bool connectionOpen)
        {
            if (connectionOpen)
            {
                StartConnection();
            }
            else
            {
                StopConnection();
            }
	    }

        private void StartConnection()
        {
            startTime = System.DateTime.Now;
            tmrConnection.Enabled = true;
           
            lblConnectionStatus.Text = "Connected";
            lblConnectionTime.Visible = true;
        }

        private void StopConnection()
        {
            tmrConnection.Enabled = false;

            lblConnectionStatus.Text = "Disconnected";
            lblConnectionTime.Text = "";
        }

        private void GroundStation_Load(object sender, EventArgs e)
        {

        }

    }
}
