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

using System.Threading;
using System.IO;
using Team2.PSU.Wireless.Mesh.Presenter;
using Team2.PSU.Wireless.Mesh.Properties;
using Team2.PSU.Wireless.Mesh.Commands;
using Team2.PSU.Wireless.Mesh.Model;
using Team2.PSU.Wireless.Mesh.Util;
using System.Drawing.Imaging;

#endregion

namespace Team2.PSU.Wireless.Mesh.View
{


    public partial class TerminalControl : UserControl
    {
        #region Local Variables

        // The main control for communicating through the RS-232 port
        private SerialPort comport = new SerialPort();

        // Various colors for logging info
        //private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

        // Temp holder for whether a key was pressed
        private bool KeyHandled = false;

        private Settings settings = Settings.Default;

        private TerminalPresenter terminalPresenter;
        private GroundStation groundStation;
        private String commandString;
        public enum CurrentDataDirection { Incoming, Outgoing };
        private String activeBaudRate = "";
        private String activeComPort = "";
        private String activeDataBits = "";
        private String activeParity = "";
        private String activeStopBits = "";

        #endregion

        #region Constructor

        public TerminalControl(TerminalPresenter terminalPresenter, GroundStation groundStation)
        {
            this.terminalPresenter = terminalPresenter;
            this.groundStation = groundStation;
            System.Diagnostics.Debug.Print("Initializing Terminal Control");
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
            updateUI();
        }

        private void UpdatePinState()
        {
            try
            {
                this.Invoke(new ThreadStart(() =>
                {
                    // Show the state of the pins
                    chkCD.Checked = comport.CDHolding;
                    chkCTS.Checked = comport.CtsHolding;
                    chkDSR.Checked = comport.DsrHolding;
                }));
            }
            catch (System.UnauthorizedAccessException e)
            {
                System.Diagnostics.Debug.Print("Caught lost connection exception");
                comport.Close();
                updateUI();         
            }
            catch (System.InvalidOperationException e)
            {
                comport.Close();
                updateUI();
                System.Diagnostics.Debug.Print("Caught invalid operation");
            }

        }

        private void updateUI()
        {
            terminalPresenter.EnableControls(gbPortSettings, gbLineSignals, chkDTR, chkRTS, txtSendData, btnSend, requestPictureBtn, btnOpenPort, btnAtachFile, comport.IsOpen, groundStation, CurrentDataMode);

            groundStation.ConnectionChanged(comport.IsOpen);
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
                //this.Close();
            }
            setCurrentValues();
        }

        private void setCurrentValues()
        {
            activeBaudRate = Convert.ToString(cmbBaudRate.SelectedItem);
            activeComPort = Convert.ToString(cmbPortName.SelectedItem);
            activeDataBits = Convert.ToString(cmbDataBits.SelectedItem);
            activeParity = Convert.ToString(cmbParity.SelectedItem);
            activeStopBits = Convert.ToString(cmbStopBits.SelectedItem);
        }

        /// <summary> Enable/disable controls based on the app's current state. </summary>
        private void EnableControls()
        {
            // Enable/disable controls based on whether the port is open or not
            gbPortSettings.Enabled = !comport.IsOpen;
            requestPictureBtn.Enabled = txtSendData.Enabled = btnSend.Enabled = comport.IsOpen;
            //chkDTR.Enabled = chkRTS.Enabled = comport.IsOpen;
            if (comport.IsOpen && (CurrentDataMode == DataMode.Image || CurrentDataMode == DataMode.TextFile))
            {
                btnAtachFile.Enabled = true;
            }
            else { btnAtachFile.Enabled = false; }
            if (comport.IsOpen)
            {
                btnOpenPort.Text = "&Close Port";
                groundStation.ConnectionChanged(true);
            }
            else
            {
                btnOpenPort.Text = "&Open Port";
                groundStation.ConnectionChanged(false);
            }

        }

        private void SendBinaryFile(SerialPort port, string FileName)
        {
            using (FileStream fs = File.OpenRead(FileName))
            {
                try
                {
                    //Code to send the image file as bytes
                    BinaryReader br = new BinaryReader(fs);
                    byte[] image = br.ReadBytes((int)(fs.Length));
                    br.Close();
                    fs.Close();

                    try
                    {
                        using (Image currentImage = Image.FromStream(new MemoryStream(image)))
                        {
                            Bitmap b = new Bitmap(currentImage);
                            pictureBox1.Image = b;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        string fileName = settings.ReceivedFilePath + "ReceivedImage_" + DateTime.Now.Minute + DateTime.Now.Second + ".jpg";
                        File.WriteAllBytes(fileName, image);
                        port.Write(fileName);
                        //MessageBox.Show("Saved file by Option 2" + fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static void SendTextFile(SerialPort port, string FileName)
        { port.Write(File.OpenText(FileName).ReadToEnd()); }

        public void AddAuditToHistory(string message, CurrentDataDirection currentDataDirection)
        {

            AuditEntry auditEntry = new AuditEntry();
            auditEntry.BaudRate = activeBaudRate;
            auditEntry.DataBits = activeDataBits;
            auditEntry.ComPort = activeComPort;
            auditEntry.Parity = activeParity;
            auditEntry.StopBits = activeStopBits;
            auditEntry.DataDirection = currentDataDirection.ToString();

            auditEntry.TextMessage = message;
            terminalPresenter.AddAuditEntry(auditEntry);

        }

        public void AddAuditToHistoryforfile(string message, CurrentDataDirection currentDataDirection)
        {
            /*AuditEntry auditEntry = new AuditEntry();
            auditEntry.BaudRate = Convert.ToString(cmbBaudRate.SelectedItem);
            auditEntry.ComPort = Convert.ToString(cmbPortName.SelectedItem);
            auditEntry.DataBits = Convert.ToString(cmbDataBits.SelectedItem);
            auditEntry.DataDirection = currentDataDirection.ToString();
            auditEntry.Parity = Convert.ToString(cmbParity.SelectedItem);
            auditEntry.StopBits = Convert.ToString(cmbStopBits.SelectedItem);
            auditEntry.TextMessage = message;
            terminalPresenter.AddAuditEntry(auditEntry);*/
        }
        #endregion

        #region Local Properties
        private DataMode CurrentDataMode
        {
            get
            {
                if (rbHex.Checked) { return DataMode.Hex; }
                else if (rbText.Checked) { return DataMode.Text; }
                else if (rdTextFile.Checked) { return DataMode.TextFile; }
                else { return DataMode.Image; }
            }
            set
            {
                if (value == DataMode.Text) rbText.Checked = true;
                else if (value == DataMode.Hex) rbHex.Checked = true;
                else if (value == DataMode.TextFile) rdTextFile.Checked = true;
                else { rdImage.Checked = true; }
            }
        }

        public RichTextBox GetTextBox()
        {
            return rtfTerminal;
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
            System.Diagnostics.Debug.Print("Open Port Clicked");
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
                {
                    terminalPresenter.ClearTerminal(rtfTerminal);
                    setCurrentValues();
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            terminalPresenter.SendData(CurrentDataMode, comport, txtSendData.Text, txtSendData, rtfTerminal);
            AddAuditToHistory(txtSendData.Text, CurrentDataDirection.Outgoing);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // If the com port has been closed, do nothing
            if (!comport.IsOpen) return;

            // This method will be called when there is data waiting in the port's buffer

            // Determain which mode (string or binary) the user is in
            if (CurrentDataMode == DataMode.Text)
            {
                //Handle Commands in form of text PF
                IncomingData.addIncomingText(comport.ReadExisting());

                bool updatesMade = false;
                string currentCommandString = "";

                IncomingData.lockMutex(); // incase we have updates, let's lock this thing down
                string commandString = IncomingData.getCurrentTextNotMutexed(); // this is safe because we are handling the mutex ourselves
                while (commandString.Contains(Command.commandEnder))
                {
                    commandString = commandString.Replace('\r', ' '); // unnecessary character
                    // strip the command out
                    currentCommandString = commandString.Substring(0, commandString.IndexOf(Command.commandEnder) + Command.commandEnder.Length);

                    // remove the current command from the current command list
                    commandString = commandString.Substring(currentCommandString.Length);
                    updatesMade = true;

                    terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, currentCommandString + '\n');
                    groundStation.CommandReceived(currentCommandString); // send the new command to the ground station
                    AddAuditToHistory(currentCommandString, CurrentDataDirection.Incoming);
                }
                if (updatesMade)
                    IncomingData.setCurrentTextNotMutexed(commandString); // set our current text to whatever is left of the command string, this is safe because we are handling the mutex ourselves
                IncomingData.unlockMutex();
                //AddAuditToHistory(data, CurrentDataDirection.Incoming);
            }
            else if (CurrentDataMode == DataMode.Hex)
            {
                // Obtain the number of bytes waiting in the port's buffer
                int bytes = comport.BytesToRead;

                // Create a byte array buffer to hold the incoming data
                byte[] buffer = new byte[bytes];

                // Read the data from the port and store it in our buffer
                comport.Read(buffer, 0, bytes);

                // Show the user the incoming data in hex format
                terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, terminalPresenter.ByteArrayToHexString(buffer));
                AddAuditToHistory(terminalPresenter.ByteArrayToHexString(buffer), CurrentDataDirection.Incoming);
            }
            else if (CurrentDataMode == DataMode.TextFile)
            {
                // Obtain the number of bytes waiting in the port's buffer
                int bytes = comport.BytesToRead;

                // Create a byte array buffer to hold the incoming data
                byte[] buffer = new byte[bytes];

                // Read the data from the port and store it in our buffer
                comport.Read(buffer, 0, bytes);
                string fileName = settings.ReceivedFilePath + "ReceivedFile_" + DateTime.Now.Minute + DateTime.Now.Second + ".txt";
                File.WriteAllBytes(fileName, buffer);

                terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, "New file received in the path:" + fileName);
                terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, "\n");
                StreamReader receivedFile = null;
                try
                {
                    terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, "Summary:");
                    terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, "\n");
                    receivedFile = new System.IO.StreamReader(fileName);
                    string summaryOfFile = receivedFile.ReadLine();
                    terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, summaryOfFile);
                    terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    receivedFile.Close();
                }
                AddAuditToHistoryforfile("New file received in the path:" + fileName, CurrentDataDirection.Incoming);

            }
            else if (CurrentDataMode == DataMode.Image)
            {
                string data = comport.ReadExisting();
                terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, "New Image received in the path:" + data);
                AddAuditToHistoryforfile("New Image received in the path:" + data, CurrentDataDirection.Incoming);
                /*                 
                 * Iam not reading anything from the port for now, let's see if we are able to open up the saved images in the SendBinaryFile method, 
                 * then we will write the path to the  port in the SendBinaryFile method and read it below in the port_DataReceived
                 */
            }
            #region Commented
            //int bytes = Convert.ToInt32(comport.ReadExisting());

            ////int bytes = comport.BytesToRead;
            //byte[] image = new byte[bytes];
            //comport.Read(image, 0, bytes);
            //string fileName = settings.ReceivedFilePath + "ReceivedFile_" + DateTime.Now.Minute + DateTime.Now.Second + ".jpg";
            //File.WriteAllBytes(fileName, image);
            //terminalPresenter.Log(rtfTerminal, LogMsgType.Incoming, "New file received in the path:" + fileName);
            //System.Drawing.Image newImage;

            //if (image != null)
            //{
            //    using (MemoryStream stream = new MemoryStream(image))
            //    {
            //        try
            //        {

            //            stream.Position = 0;
            //            stream.ToArray();
            //            newImage = System.Drawing.Image.FromStream(stream);
            //            Bitmap b = new Bitmap(newImage);
            //            pictureBox1.Image = b;
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //}

            //OpenFileDialog openFileDialogToSend = new OpenFileDialog();
            //openFileDialogToSend.Multiselect = false;
            //if (openFileDialogToSend.ShowDialog() == DialogResult.OK)
            //{
            //    SendBinaryFile(comport, openFileDialogToSend.FileName);
            //}           
            //    // Obtain the number of bytes waiting in the port's buffer
            //    int bytes = comport.BytesToRead;


            //    // Create a byte array buffer to hold the incoming data
            //    byte[] buffer = new byte[bytes];

            //    // Read the data from the port and store it in our buffer
            //    comport.Read(buffer, 0, bytes);
            //    try
            //    {
            //        MemoryStream ms = new MemoryStream();
            //        ms.Write(buffer, 0, buffer.Length);
            //        ms.ToArray();

            //        ms.Position = 0;
            //        Bitmap b = new Bitmap(ms);

            //        PictureBox pictureBox = new PictureBox();
            //        pictureBox.Image = b;
            //    }
            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            //    //Giri in most of the blogs i read we have to Reset the position of the memory stream prior to loading the image.

            //    //string fileName = settings.ReceivedFilePath + "ReceivedImageFile_" + DateTime.Now.Minute + DateTime.Now.Second + ".txt";
            //    //File.WriteAllBytes(fileName, buffer);
            //    //byte[] tempFile = File.ReadAllBytes(fileName);
            //    //MemoryStream stream = new MemoryStream(tempFile);
            //    //Image currentImage = Image.FromStream(stream);
            //    try
            //    {
            //        MemoryStream stream = new MemoryStream(buffer);
            //        Image image = System.Drawing.Image.FromStream(stream, true);
            //    }
            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            //}
            #endregion
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

        private void lnkLblAuditHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new AuditHistory()).ShowDialog(this);
        }

        private void btnAtachFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogToSend = new OpenFileDialog();
            openFileDialogToSend.Multiselect = false;
            if (openFileDialogToSend.ShowDialog() == DialogResult.OK)
            {
                if (CurrentDataMode == DataMode.Image)
                {
                    SendBinaryFile(comport, openFileDialogToSend.FileName);
                    AddAuditToHistory("Image Sent", CurrentDataDirection.Outgoing);
                }
                else if (CurrentDataMode == DataMode.TextFile)
                {
                    SendTextFile(comport, openFileDialogToSend.FileName);
                    AddAuditToHistory("Text File Sent", CurrentDataDirection.Outgoing);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings appSettings = Settings.Default;
            string sourceFileName = "Log-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss.ff") + ".txt"; // name the file
            string textToWrite = rtfTerminal.Text;

            if (!includeTimeCB.Checked)
            {
                string[] textToParse = textToWrite.Split('\n');
                string lineToWrite = "";
                textToWrite = "";
                foreach (string line in textToParse)
                {
                    lineToWrite = line.Substring(line.IndexOf(" ") + 1);
                    textToWrite += lineToWrite + Environment.NewLine;
                }
            }
            
            if (gpsDataOnlyCB.Checked)
            {
                string[] textToParse = textToWrite.Split('\n');
                textToWrite = "";
                foreach (string line in textToParse)
                {
                    if (line.Contains("GPRMC"))
                        textToWrite += line + Environment.NewLine;
                }
            }

            System.IO.File.WriteAllText(appSettings.LogFilePath + sourceFileName, textToWrite);
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            terminalPresenter.SendData(CurrentDataMode, comport, "gs1pctpl1", txtSendData, rtfTerminal);
            AddAuditToHistory("gs1pctpl1", CurrentDataDirection.Outgoing);
        }
    }

}