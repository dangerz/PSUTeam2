using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Team2.PSU.Wireless.Mesh.View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new GroundStation());
        }
    }
}
