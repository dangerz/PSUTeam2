using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Team2.PSU.Wireless.Mesh.View;

namespace Team2.PSU.Wireless.Mesh.Model
{
    interface ITerminalModel
    {
        byte[] HexStringToByteArray(string s);
        string ByteArrayToHexString(byte[] data);
        string[] OrderedPortNames();
        void Log(RichTextBox rtfTerminal, LogMsgType msgtype, string msg);
        void SendData(DataMode CurrentDataMode, SerialPort comport, string txtSendDataText, TextBox txtSendData, RichTextBox rtfTerminal);
        bool CheckIfError(SerialPort comport, string cmbBaudRateText, string cmbDataBitsText, string cmbStopBitsText, string cmbParityText, string cmbPortNameText);
    }
}
