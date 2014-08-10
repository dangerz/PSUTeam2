using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team2.PSU.Wireless.Mesh.Util;

namespace Team2.PSU.Wireless.Mesh.Util.MapUtils
{
    class GeoLocationBuilder
    {

        
        private static int timePosition = 1;
        private static int validityPosition = 2;
        private static int latitudePosition = 3;
        private static int northSouthPosition = 4;
        private static int longitudePosition = 5;
        private static int eastWestPosition = 6;
        private static int knotsPosition = 7;
        private static int coursePosition = 8;
        private static int dateStampPosition = 9;
        private static int variationPosition = 10;
        private static int variationEastWestPosition = 11;
        private static int checksumPosition = 12;

        public GeoLocationBuilder()
        {
        }

        // example "$GPRMC,054016.000,A,3238.8270,N,09723.6242,W,0.21,124.65,160714,,,D*77\r"
        // "$GPRMC,033841.000,A,3238.8235 ,N,09723.6235,W,0.18,283.00,170714,,,D*7B\r"
        // "$GPRMCA,3238.8195,N,09723.6229,W,0.27,307.31,170714,,,D*7F\r"
        public static GeoLocation GetGeoLocation(String geoLocationString)
        {
            GeoLocation location = new GeoLocation();
            location.setValid(false);

            try
            {
                LineParser parser = new LineParser(geoLocationString);
                if (geoLocationString.StartsWith("$GPRMC,") || geoLocationString.StartsWith("$GPGGA")) // make sure it's a valid gps string
                {
                    double tryParseOutput;

                    String nmeaLatitude = parser.GetValueAtPosition(latitudePosition);
                    String nmeaDegrees = nmeaLatitude.Substring(0, 2);
                    String nmeaMinutes = nmeaLatitude.Substring(2, nmeaLatitude.IndexOf(".") - 2);
                    String nmeaSeconds = nmeaLatitude.Substring(nmeaLatitude.IndexOf(".") + 1);

                    if (double.TryParse(nmeaDegrees, out tryParseOutput) && double.TryParse(nmeaMinutes, out tryParseOutput) && double.TryParse(nmeaSeconds, out tryParseOutput)) // checksum
                    {
                        double googleLatitude = Math.Round(double.Parse(nmeaDegrees) + (double.Parse(nmeaMinutes) / 60) + ((double.Parse(nmeaSeconds) / 100) / 3600), 4);
                        if (parser.GetValueAtPosition(northSouthPosition) == "S" && googleLatitude > 0)
                            googleLatitude = -googleLatitude;

                        String nmeaLongitude = parser.GetValueAtPosition(longitudePosition);
                        nmeaDegrees = nmeaLongitude.Substring(0, 3);
                        nmeaMinutes = nmeaLongitude.Substring(3, nmeaLatitude.IndexOf(".") - 2);
                        nmeaSeconds = nmeaLongitude.Substring(nmeaLatitude.IndexOf(".") + 2);

                        if (double.TryParse(nmeaDegrees, out tryParseOutput) && double.TryParse(nmeaMinutes, out tryParseOutput) && double.TryParse(nmeaSeconds, out tryParseOutput)) // checksum
                        {
                            double googleLongitude = Math.Round(double.Parse(nmeaDegrees) + (double.Parse(nmeaMinutes) / 60) + ((double.Parse(nmeaSeconds) / 100) / 3600), 4);

                            if (parser.GetValueAtPosition(eastWestPosition) == "W" && googleLongitude > 0)
                                googleLongitude = -googleLongitude;

                            location.SetLatitude(googleLatitude);
                            location.SetLongitude(googleLongitude);
                            location.SetKnots(StringFunctions.ParseDouble(parser.GetValueAtPosition(knotsPosition)));
                            location.SetNorthSouth(parser.GetValueAtPosition(northSouthPosition));
                            location.SetEastWest(parser.GetValueAtPosition(eastWestPosition));
                            location.SetValidity(parser.GetValueAtPosition(validityPosition));
                            location.setValid(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If we are in here, something in the string was malformed.  No need to alert the user, we'll get another
                // update in a few seconds.
                ex.ToString(); // just to get rid of the warning
            }
            return location;
               
        }




    }
}
