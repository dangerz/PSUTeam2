using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team2.PSU.Wireless.Mesh.Model;
using System.Windows.Forms;
using System.IO.Ports;
using Team2.PSU.Wireless.Mesh.Properties;
using Team2.PSU.Wireless.Mesh.View;
using System.Drawing;
using Team2.PSU.Wireless.Mesh.Commands;
using Team2.PSU.Wireless.Mesh.Util.MapUtils;
using System.Data;
using Team2.PSU.Wireless.Mesh.DataAccess;

namespace Team2.PSU.Wireless.Mesh.Presenter
{       
    public class TerminalPresenter
    {
        TerminalModel terminalModel = new TerminalModel();
        TerminalDataAccess terminalDataAccess = new TerminalDataAccess();
        private Settings settings = Settings.Default;
        

        public byte[] HexStringToByteArray(string s)
        {
            return terminalModel.HexStringToByteArray(s);
        }

        public string ByteArrayToHexString(byte[] data)
        {
            return terminalModel.ByteArrayToHexString(data);
        }

        public string[] OrderedPortNames()
        {
            //TerminalModel terminalModel = new TerminalModel();
            return terminalModel.OrderedPortNames();
        }

        public void InitializeControlValues(ComboBox cmbParity, ComboBox cmbStopBits,
                                             ComboBox cmbDataBits, ComboBox cmbBaudRate,
                                             CheckBox chkClearOnOpen, CheckBox chkClearWithDTR,
                                             DataMode CurrentDataMode,ComboBox cmbPortName, bool IsPortOpen)
        {
            cmbParity.Items.Clear(); cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.Items.Clear(); cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            cmbParity.Text = settings.Parity.ToString();
            cmbStopBits.Text = settings.StopBits.ToString();
            cmbDataBits.Text = settings.DataBits.ToString();
            cmbParity.Text = settings.Parity.ToString();
            cmbBaudRate.Text = settings.BaudRate.ToString();
            CurrentDataMode = settings.DataMode;

            RefreshComPortList(cmbPortName, IsPortOpen);

            chkClearOnOpen.Checked = settings.ClearOnOpen;
            chkClearWithDTR.Checked = settings.ClearWithDTR;
        }

        public void EnableControls(GroupBox gbPortSettings, GroupBox gbLineSettings, CheckBox chkDTR, CheckBox chkRTS, TextBox txtSendData, Button btnSend, Button btnRequestPicture, Button btnOpenPort, Button btnAtachFile, bool portOpen, GroundStation gs, DataMode currentDataMode)
        {
            // Enable/disable controls based on whether the port is open or not
            System.Diagnostics.Debug.Print("Enable controls TP: " + !portOpen);
            gbPortSettings.Invoke(new EventHandler(delegate
            {
                gbPortSettings.Enabled = !portOpen;
                btnRequestPicture.Enabled = txtSendData.Enabled = btnSend.Enabled = portOpen;

                if (portOpen && (currentDataMode == DataMode.Image || currentDataMode == DataMode.TextFile))
                {
                    btnAtachFile.Enabled = true;
                }
                else { btnAtachFile.Enabled = false; }
                if (portOpen) btnOpenPort.Text = "&Close Port";
                else btnOpenPort.Text = "&Open Port";
                gs.ConnectionChanged(portOpen);
                }));

            gbLineSettings.Invoke(new EventHandler(delegate
                {
                    chkDTR.Enabled = !portOpen;
                    chkRTS.Enabled = !portOpen;
                }));
            
        }
            
        public void RefreshComPortList(ComboBox cmbPortName, bool IsPortOpen)
        {
        
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, IsPortOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmbPortName.Items.Clear();
                cmbPortName.Items.AddRange(terminalModel.OrderedPortNames());
                cmbPortName.SelectedItem = selected;
            }
             
        }

        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = SerialPort.GetPortNames();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = terminalModel.OrderedPortNames();

                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }


        public void DisplayMapLocation(WebBrowser browser, String serialNumber, GeoLocation location)
        {
            //terminalModel.ReceiveMapLocation(browser, serialNumber, location);
        }


        /// <summary> Save the user's settings. </summary>
        public void SaveSettings(string  cmbBaudRateText, string cmbDataBitsText, DataMode CurrentDataMode,
                                 string cmbParityText,string cmbStopBitsText, string cmbPortNameText,
                                 bool chkClearOnOpen, bool chkClearWithDTR)
        {
            settings.BaudRate = int.Parse(cmbBaudRateText);
            settings.DataBits = int.Parse(cmbDataBitsText);
            settings.DataMode = CurrentDataMode;
            settings.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParityText);
            settings.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBitsText);
            settings.PortName = cmbPortNameText;
            settings.ClearOnOpen = chkClearOnOpen;
            settings.ClearWithDTR = chkClearWithDTR;

            settings.Save();
        }


        public void Log(RichTextBox rtfTerminal, LogMsgType msgtype, string msg)
        {
            string currentTime = DateTime.Now.ToString("HH:mm:ss: ");
            terminalModel.Log(rtfTerminal, msgtype, currentTime + msg);
        }

        /// <summary> Send the user's data currently entered in the 'send' box.</summary>
        public void SendData(DataMode CurrentDataMode, SerialPort comport, string txtSendDataText, TextBox txtSendData,RichTextBox rtfTerminal)
        {
            terminalModel.SendData(CurrentDataMode, comport, txtSendDataText, txtSendData, rtfTerminal);
        }


        public void ClearTerminal(RichTextBox rtfTerminal)
        {
            rtfTerminal.Clear();
        }

        public bool CheckIfError(SerialPort comport, string cmbBaudRateText, string cmbDataBitsText, string cmbStopBitsText,
                                  string cmbParity, string cmbPortName)
        {
           return terminalModel.CheckIfError(comport, cmbBaudRateText, cmbDataBitsText,cmbStopBitsText,cmbParity, cmbPortName);
        }

        public int AddAuditEntry(AuditEntry auditEntry)
        {
            return terminalDataAccess.AddAuditEntry(auditEntry);
        }

        public DataSet GetAuditRecords(AuditEntry auditEntry)
        {
            return terminalDataAccess.GetAuditRecords(auditEntry);
        }

    }
}
