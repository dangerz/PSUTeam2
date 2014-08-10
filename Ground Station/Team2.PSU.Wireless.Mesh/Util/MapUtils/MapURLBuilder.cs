using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Team2.PSU.Wireless.Mesh.Util;

namespace Team2.PSU.Wireless.Mesh.Util.MapUtils

{
    public class MapURLBuilder
    {

        private const String urlBeginning = "http://maps.googleapis.com/maps/api/staticmap?";
        private const String separator = "&";
        private StringBuilder url = new StringBuilder();
        private GeoLocation center;
        private int zoom;
        private int width = 300;
        private int height = 300;
        private int scale = 1;
        private String mapType = "terrain";
        private List<MapMarker> markers;

        public MapURLBuilder()
        {
            markers = new List<MapMarker>();
        }

        public void SetMapType(String mapType)
        {
            this.mapType = mapType;
        }

        public void SetCenter(GeoLocation location)
        {
            this.center = location;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public void SetZoom(int zoom)
        {
            this.zoom = zoom;
        }


        public void PlaceMarker(String serialNumber, GeoLocation location)
        {
            if(MarkerExists(serialNumber))
            {
                ChangeMarkerLocation(serialNumber, location);
            }
            else
            {
                AddMarker(serialNumber, location, serialNumber.Substring(0,1));
            }
        }

        public void AddMarker(String serialNumber, GeoLocation location, String label)
        {
            markers.Add(new MapMarker(serialNumber, location, label));
        }



        public void ChangeMarkerLocation(int markerPosition, GeoLocation location)
        {
            markers.ElementAt(markerPosition).SetLocation(location);
        }

        public void ChangeMarkerLocation(String serialNumber, GeoLocation location)
        {
            foreach (MapMarker m in markers)
            {
                if (m.GetSerialNumber() == serialNumber)
                {
                    m.SetLocation(location);
                    break;
                }
            }
        }

        public bool MarkerExists(String serialNumber)
        {
            foreach (MapMarker m in markers)
            {
                if (m.GetSerialNumber().Equals(serialNumber))
                {
                    return true;
                }
            }
            return false;

        }


        public String GetMapURL()
        {
            url.Remove(0, url.Length);
            url.Append(urlBeginning);
            url.Append(GetCenterString());
            url.Append(GetRequiredSeparator(url.ToString()));
            url.Append(GetZoomString());
            url.Append(GetRequiredSeparator(url.ToString()));
            url.Append(GetSizeString());
            url.Append(GetRequiredSeparator(url.ToString()));
            url.Append(GetMapTypeString());
            url.Append(GetRequiredSeparator(url.ToString()));
            url.Append(GetScaleString());
            url.Append(GetRequiredSeparator(url.ToString()));
            url.Append(GetMarkersString());
            if(url.ToString().EndsWith(separator))
            {
                url.Remove(url.Length - separator.Length, separator.Length);
            }
            System.Diagnostics.Debug.Print(url.ToString());
            return url.ToString();

        }

        private String GetRequiredSeparator(String s)
        {
            if (s.ToString().EndsWith("=") || s.ToString().EndsWith("&"))
            {
                return "";
            }
            else
            {
                return separator;
            }

        }

        private String GetCenterString()
        {
            try
            {
                return "center=" + DDMMSSToDecimalDegrees(center.GetLatitude().ToString()) + "," + DDMMSSToDecimalDegrees( center.GetLongitude().ToString() );
            }
            catch (NullReferenceException e)
            {
                return "";
            }
        }

        public static string DDMMSSToDecimalDegrees(string data)
        {
            var ddmmss = (Convert.ToDouble(data) / 100);

            var degrees = (int)ddmmss;

            var minutesseconds = ((ddmmss - degrees) * 100) / 60.0;

            string whatToReturn = degrees.ToString() + Math.Round( minutesseconds, 4 ).ToString().Substring(1);
            return whatToReturn;

        }
        private String GetZoomString()
        {
            if (zoom > 0)
            {
                return "zoom=" + zoom;
            }
            else
            {
                return "";
            }
        }

        private String GetSizeString()
        {
            return "size=" + width + "x" + height;
        }

        private String GetMapTypeString()
        {
            return "maptype=" + mapType;
        }

        private String GetScaleString()
        {
            return "scale=" + scale;
        }

        private String GetMarkersString()
        {
            String s = "";

            foreach (MapMarker m in markers)
            {
                s = s + GetRequiredSeparator(s);
                s = s + m.GetMarkerString();
            }
            return s;
        }

    }
}
