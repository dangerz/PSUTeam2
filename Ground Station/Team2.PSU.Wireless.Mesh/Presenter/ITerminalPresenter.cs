using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2.PSU.Wireless.Mesh.View;
using System.IO.Ports;

namespace Team2.PSU.Wireless.Mesh.Presenter
{
    interface ITerminalPresenter
    {
        byte[] HexStringToByteArray(string s);
        string ByteArrayToHexString(byte[] data);
        string[] OrderedPortNames();
        void RefreshComPortList(ComboBox cmbPortName, bool IsPortOpen);
        string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen);
        void Log(RichTextBox rtfTerminal, LogMsgType msgtype, string msg);
        void ClearTerminal(RichTextBox rtfTerminal);
        bool CheckIfError(SerialPort comport, string cmbBaudRateText, string cmbDataBitsText, string cmbStopBitsText, string cmbParity, string cmbPortName);
        void SendData(DataMode CurrentDataMode, SerialPort comport, string txtSendDataText, TextBox txtSendData, RichTextBox rtfTerminal);
        void SaveSettings(string cmbBaudRateText, string cmbDataBitsText, DataMode CurrentDataMode, string cmbParityText, string cmbStopBitsText,
                           string cmbPortNameText, bool chkClearOnOpen, bool chkClearWithDTR);
        void InitializeControlValues(ComboBox cmbParity, ComboBox cmbStopBits, ComboBox cmbDataBits, ComboBox cmbBaudRate, CheckBox chkClearOnOpen,
                                           CheckBox chkClearWithDTR, DataMode CurrentDataMode, ComboBox cmbPortName, bool IsPortOpen);

    }
}
