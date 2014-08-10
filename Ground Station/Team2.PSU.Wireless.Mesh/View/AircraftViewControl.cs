using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2.PSU.Wireless.Mesh.Properties;
using Team2.PSU.Wireless.Mesh.Presenter;

namespace Team2.PSU.Wireless.Mesh.View
{
    public partial class AircraftViewControl : UserControl
    {
        private Settings settings = Settings.Default;
        public AircraftViewControl(TerminalPresenter terminalPresenter)
        {
            InitializeComponent();
            updateUrl(settings.MapURL);

        }

        private void updateUrl(string url)
        {
            this.webBrowsermapView.Url = new System.Uri(url, System.UriKind.Absolute);
        }

        public WebBrowser getMapView()
        {
            return this.webBrowsermapView;
        }

    }
}
