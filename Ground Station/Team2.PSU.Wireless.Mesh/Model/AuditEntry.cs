using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Model
{
    public class AuditEntry
    {
        private string comPort;

        public string ComPort
        {
            get { return comPort; }
            set { comPort = value; }
        }
        private string baudRate;

        public string BaudRate
        {
            get { return baudRate; }
            set { baudRate = value; }
        }
        private string parity;

        public string Parity
        {
            get { return parity; }
            set { parity = value; }
        }
        private string dataBits;

        public string DataBits
        {
            get { return dataBits; }
            set { dataBits = value; }
        }
        private string stopBits;

        public string StopBits
        {
            get { return stopBits; }
            set { stopBits = value; }
        }
        private string textMessage;

        public string TextMessage
        {
            get { return textMessage; }
            set { textMessage = value; }
        }
        private string dataDirection;

        public string DataDirection
        {
            get { return dataDirection; }
            set { dataDirection = value; }
        }
        //public enum DataDirection { Incomming, Outgoing } ;
    }
}

