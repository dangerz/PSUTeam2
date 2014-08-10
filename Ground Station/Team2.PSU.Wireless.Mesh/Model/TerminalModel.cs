using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Team2.PSU.Wireless.Mesh.View;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using Team2.PSU.Wireless.Mesh.Commands;

namespace Team2.PSU.Wireless.Mesh.Model
{
    public class TerminalModel
    {
        private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        
        
        public TerminalModel()
        {
            //Setup a constructor just to drop some debug tags at runtime.
          

        }

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        public string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }


        /*
        public void ReceiveMapLocation(WebBrowser browser, String serialNumber, GeoLocation location)
        {
            //Using website now no need for static

            //mapBuilder.PlaceMarker(serialNumber, location);
            //browser.Url = new System.Uri(mapBuilder.GetMapURL(), System.UriKind.Absolute); 
        }
        */
        /// <summary> Log data to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void Log(RichTextBox rtfTerminal, LogMsgType msgtype, string msg)
        {
            rtfTerminal.Invoke(new EventHandler(delegate
            {
                rtfTerminal.SelectedText = string.Empty;
                rtfTerminal.SelectionFont = new Font(rtfTerminal.SelectionFont, FontStyle.Bold);
                rtfTerminal.SelectionColor = LogMsgTypeColor[(int)msgtype];
                rtfTerminal.AppendText(msg);
                rtfTerminal.ScrollToCaret();
            }));
        }


        public void SendData(DataMode CurrentDataMode, SerialPort comport, string txtSendDataText, TextBox txtSendData, RichTextBox rtfTerminal)
        {
            if (CurrentDataMode == DataMode.Text)
            {
                // Send the user's text straight out the port
                comport.Write(txtSendDataText);

                // Show in the terminal window the user's text
                Log(rtfTerminal, LogMsgType.Outgoing, txtSendDataText + "\n");
            }
            else
            {
                try
                {
                    // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
                    byte[] data = HexStringToByteArray(txtSendDataText);

                    // Send the binary data out the port
                    comport.Write(data, 0, data.Length);

                    // Show the hex digits on in the terminal window
                    Log(rtfTerminal, LogMsgType.Outgoing, ByteArrayToHexString(data) + "\n");
                }
                catch (FormatException)
                {
                    // Inform the user if the hex string was not properly formatted
                    Log(rtfTerminal, LogMsgType.Error, "Not properly formatted hex string: " + txtSendDataText + "\n");
                }
            }
            txtSendData.SelectAll();
        }

        public bool CheckIfError(SerialPort comport, string cmbBaudRateText, string cmbDataBitsText,string cmbStopBitsText,
                                  string cmbParityText, string cmbPortNameText)
        {
              bool error = false;
              // Set the port's settings
              comport.BaudRate = int.Parse(cmbBaudRateText);
              comport.DataBits = int.Parse(cmbDataBitsText);
              comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBitsText);
              comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParityText);
              comport.PortName = cmbPortNameText;
              comport.Encoding = Encoding.UTF8;
              try
              {
                  // Open the port
                  comport.Open();
              }
              catch (UnauthorizedAccessException) { error = true; }
              catch (IOException) { error = true; }
              catch (ArgumentException) { error = true; }

              return error;
        }


    }
}
