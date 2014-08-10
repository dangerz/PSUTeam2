using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Util.MapUtils
{
    public class MapMarker
    {
        private const String separator = "%7C";
        private String color = "blue";
        private String label = "";
        private String serialNumber;
        private GeoLocation location;
        private String size = "mid";
        private StringBuilder markerString = new StringBuilder();


        public MapMarker(String serialNumber, GeoLocation location, String label, String color)
        {
            System.Diagnostics.Debug.Print("Label sent to marker: " + label);
            this.color = color;
            this.label = label;
            this.location = location;
            this.serialNumber = serialNumber;
        }

        public MapMarker(String serialNumber, GeoLocation location, String label)
        {
            System.Diagnostics.Debug.Print("Label sent to marker: " + label);
            this.location = location;
            this.label = label;
            this.serialNumber = serialNumber;
        }

        public void SetLocation(GeoLocation location)
        {
            this.location = location;
        }

        public String GetSerialNumber()
        {
            return serialNumber;
        }

        public String GetLabel()
        {
            return this.label;
        }

        public void SetSize(String size)
        {
            this.size = size;
        }

        public String GetMarkerString()
        {
            markerString.Remove(0, markerString.Length);
            markerString.Append("markers=");

            if (color.Length > 0)
            {
                markerString.Append(GetColorString());
            }
            markerString.Append(GetRequiredSeparator(markerString.ToString()));

            markerString.Append(GetLabelString());
            markerString.Append(GetRequiredSeparator(markerString.ToString()));
            markerString.Append(GetSizeString());
            markerString.Append(separator);
            markerString.Append(GetLocationString());
            System.Diagnostics.Debug.Print(markerString.ToString());
            return markerString.ToString();            
        }

        private String GetRequiredSeparator(String s)
        {
            if (s.ToString().EndsWith("=") || s.ToString().EndsWith(separator))
            {
                return "";
            }
            else
            {
                return separator;
            }
        }

        private String GetColorString()
        {
            return "color:" + color;
        }

        private String GetLabelString()
        {
            return "label:" + label;
        }

        private String GetSizeString()
        {
            return "size:" + size;
        }

        private String GetLocationString()
        {
            return location.GetLatitude().ToString() + "," + location.GetLongitude().ToString();
        }
    }
}
