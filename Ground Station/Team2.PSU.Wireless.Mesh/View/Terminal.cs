/* 
 * Project:    SerialPort Terminal
 * Author:     Team2 PSU
 * 
 * Notes:      This was created to demonstrate how to use the SerialPort control for
 *             communicating with your PC's Serial RS-232 COM Port
 */

#region Namespace Inclusions
using System;
using System.Linq;
using System.Data;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Team2.PSU.Wireless.Mesh.Properties;
using System.Threading;
using System.IO;
using Team2.PSU.Wireless.Mesh.Presenter;
#endregion

namespace Team2.PSU.Wireless.Mesh.View
{
  #region Public Enumerations
  public enum DataMode { Text, Hex }
  public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
  #endregion

  public partial class frmTerminal : Form
  {
      #region Local Variables

      // The main control for communicating through the RS-232 port
      private SerialPort comport = new SerialPort();

      // Various colors for logging info
      //private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

      // Temp holder for whether a key was pressed
      private bool KeyHandled = false;

      private Settings settings = Settings.Default;

      TerminalPresenter terminalPresenter = new TerminalPresenter();
      #endregion

      #region Constructor

      public frmTerminal()
      {
          // Load user settings
          settings.Reload();

          // Build the form
          InitializeComponent();

          // Restore the users settings
          InitializeControlValues();

          // Enable/disable controls based on the current state
          EnableControls();

          // When data is recieved through the port, call this method
          comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
          comport.PinChanged += new SerialPinChangedEventHandler(comport_PinChanged);
      }

      void comport_PinChanged(object sender, SerialPinChangedEventArgs e)
      {
          // Show the state of the pins
          UpdatePinState();
      }

      private void UpdatePinState()
      {
          this.Invoke(new ThreadStart(() =>
          {
              // Show the state of the pins
              chkCD.Checked = comport.CDHolding;
              chkCTS.Checked = comport.CtsHolding;
              chkDSR.Checked = comport.DsrHolding;
          }));
      }

      #endregion

      #region Local Methods 

      /// <summary> Populate the form's controls with default settings. </summary>
      private void InitializeControlValues()
      {
          terminalPresenter.InitializeControlValues(cmbParity, cmbStopBits, cmbDataBits, cmbBaudRate, chkClearOnOpen, chkClearWithDTR,
               CurrentDataMode, cmbPortName, comport.IsOpen);          

          // If it is still avalible, select the last com port used
          if (cmbPortName.Items.Contains(settings.PortName)) cmbPortName.Text = settings.PortName;
          else if (cmbPortName.Items.Count > 0) cmbPortName.SelectedIndex = cmbPortName.Items.Count - 1;
          else
          {
              MessageBox.Show(this, "There are no COM Ports detected on this computer.\nPlease install a COM Port and restart this app.", "No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
              this.Close();
          }
      }

      /// <summary> Enable/disable controls based on the app's current state. </summary>
      private void EnableControls()
      {
          // Enable/disable controls based on whether the port is open or not
          gbPortSettings.Enabled = !comport.IsOpen;
          txtSendData.Enabled = btnSend.Enabled = comport.IsOpen;
          //chkDTR.Enabled = chkRTS.Enabled = comport.IsOpen;

          if (comport.IsOpen) btnOpenPort.Text = "&Close Port";
          else btnOpenPort.Text = "&Open Port";
      }
         

      #endregion

      #region Local Properties
      private DataMode CurrentDataMode
      {
          get
          {
              if (rbHex.Checked) return DataMode.Hex;
              else return DataMode.Text;
          }
          set
          {
              if (value == DataMode.Text) rbText.Checked = true;
              else rbHex.Checked = true;
          }
      }
      #endregion

      #region Event Handlers

      private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
          // Show the user the about dialog
          ///(new frmAbout()).ShowDialog(this);
          (new About()).ShowDialog(this);
      }

      private void frmTerminal_Shown(object sender, EventArgs e)
      {
          terminalPresenter.Log(rtfTerminal, LogMsgType.Normal, String.Format("Application Started at {0}\n", DateTime.Now));
      }

      private void frmTerminal_FormClosing(object sender, FormClosingEventArgs e)
      {
          // The form is closing, save the user's preferences
          terminalPresenter.SaveSettings(cmbBaudRate.Text, cmbDataBits.Text, CurrentDataMode, cmbParity.Text,
                                         cmbStopBits.Text, cmbPortName.Text, chkClearOnOpen.Checked, chkClearWithDTR.Checked);
      }

      private void rbText_CheckedChanged(object sender, EventArgs e)
      { if (rbText.Checked) CurrentDataMode = DataMode.Text; }

      private void rbHex_CheckedChanged(object sender, EventArgs e)
      { if (rbHex.Checked) CurrentDataMode = DataMode.Hex; }

      private void cmbBaudRate_Validating(object sender, CancelEventArgs e)
      { int x; e.Cancel = !int.TryParse(cmbBaudRate.Text, out x); }

      private void cmbDataBits_Validating(object sender, CancelEventArgs e)
      { int x; e.Cancel = !int.TryParse(cmbDataBits.Text, out x); }

      private void btnOpenPort_Click(object sender, EventArgs e)
      {
          bool error = false;

          // If the port is open, close it.
          if (comport.IsOpen) comport.Close();
          else
          {
              error = terminalPresenter.CheckIfError(comport, cmbBaudRate.Text, cmbDataBits.Text, cmbStopBits.Text,
                                   cmbParity.Text, cmbPortName.Text);

              if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              else
              {
                  // Show the initial pin states
                  UpdatePinState();
                  chkDTR.Checked = comport.DtrEnable;
                  chkRTS.Checked = comport.RtsEnable;
              }
          }

          // Change the state of the form's controls
          EnableControls();

          // If the port is open, send focus to the send data box
          if (comport.IsOpen)
          {
              txtSendData.Focus();
              if (chkClearOnOpen.Checked)
                  terminalPresenter.ClearTerminal(rtfTerminal);
          }
      }

      private void btnSend_Click(object sender, EventArgs e)
      {
          terminalPresenter.SendData(CurrentDataMode, comport, txtSendData.Text, txtSendData, rtfTerminal);
      }

      private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
          // If the com port has been closed, do nothing
          if (!comport.IsOpen) return;

          // This method will be called when there is data waiting in the port's buffer

          // Determain which mode (string or binary) the user is in
          if (CurrentDataMode == DataMode.Text)
          {
              // Read all the data waiting in the buffer
              string data = comport.ReadExisting();

              // Display the text to the user in the terminal
              terminalPresenter.Log(rtfTerminal,LogMsgType.Incoming, data);
          }
          else
          {
              // Obtain the number of bytes waiting in the port's buffer
              int bytes = comport.BytesToRead;

              // Create a byte array buffer to hold the incoming data
              byte[] buffer = new byte[bytes];

              // Read the data from the port and store it in our buffer
              comport.Read(buffer, 0, bytes);

              // Show the user the incoming data in hex format
              terminalPresenter.Log(rtfTerminal,LogMsgType.Incoming, terminalPresenter.ByteArrayToHexString(buffer));
          }
      }

      private void txtSendData_KeyDown(object sender, KeyEventArgs e)
      {
          // If the user presses [ENTER], send the data now
          if (KeyHandled = e.KeyCode == Keys.Enter) 
          { 
              e.Handled = true; 
              //SendData(); 
              terminalPresenter.SendData(CurrentDataMode, comport, txtSendData.Text, txtSendData, rtfTerminal);
          }
      }

      private void txtSendData_KeyPress(object sender, KeyPressEventArgs e)
      { e.Handled = KeyHandled; }
      
      private void chkDTR_CheckedChanged(object sender, EventArgs e)
      {
          comport.DtrEnable = chkDTR.Checked;
          if (chkDTR.Checked && chkClearWithDTR.Checked)
              terminalPresenter.ClearTerminal(rtfTerminal);
      }

      private void chkRTS_CheckedChanged(object sender, EventArgs e)
      {
          comport.RtsEnable = chkRTS.Checked;
      }

      private void btnClear_Click(object sender, EventArgs e)
      {
          terminalPresenter.ClearTerminal(rtfTerminal);
      }
     
      private void tmrCheckComPorts_Tick(object sender, EventArgs e)
      {
          // checks to see if COM ports have been added or removed
          // since it is quite common now with USB-to-Serial adapters
          terminalPresenter.RefreshComPortList(cmbPortName, comport.IsOpen);
      }

      #endregion

      #region Commented

      //private void ClearTerminal()
      //{
      //    rtfTerminal.Clear();
      //}


      //private void RefreshComPortList()
      //{
      //    // Determain if the list of com port names has changed since last checked
      //    string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);

      //    // If there was an update, then update the control showing the user the list of port names
      //    if (!String.IsNullOrEmpty(selected))
      //    {
      //        cmbPortName.Items.Clear();
      //        cmbPortName.Items.AddRange(terminalPresenter.OrderedPortNames());
      //        cmbPortName.SelectedItem = selected;
      //    }
      //}



      //private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
      //{
      //    // Create a new return report to populate
      //    string selected = null;

      //    // Retrieve the list of ports currently mounted by the operating system (sorted by name)
      //    string[] ports = SerialPort.GetPortNames();

      //    // First determain if there was a change (any additions or removals)
      //    bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

      //    // If there was a change, then select an appropriate default port
      //    if (updated)
      //    {
      //        // Use the correctly ordered set of port names
      //        ports = terminalPresenter.OrderedPortNames();

      //        // Find newest port if one or more were added
      //        string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

      //        // If the port was already open... (see logic notes and reasoning in Notes.txt)
      //        if (PortOpen)
      //        {
      //            if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
      //            else if (!String.IsNullOrEmpty(newest)) selected = newest;
      //            else selected = ports.LastOrDefault();
      //        }
      //        else
      //        {
      //            if (!String.IsNullOrEmpty(newest)) selected = newest;
      //            else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
      //            else selected = ports.LastOrDefault();
      //        }
      //    }

      //    // If there was a change to the port list, return the recommended default selection
      //    return selected;
      //}

      #endregion

  }

}