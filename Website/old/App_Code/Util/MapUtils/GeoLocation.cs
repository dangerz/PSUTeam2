using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Util.MapUtils
{
    public class GeoLocation
    {
        private double latitude;
        private double longitude;
        private String stringLatitude;
        private String stringLongitude;
        private DateTime timeStamp;
        private DateTime dateStamp;

        private String validity;
        private String northSouth;
        private String eastWest;
        private double knots;
        private double variation;
        private String eastWestVariationDirection;
        private String checksum;

        private bool mIsValid;

        public GeoLocation()
        {

        }

        public bool isValid()
        {
            return mIsValid;
        }
        public void setValid ( bool pIsValid )
        {
            mIsValid = pIsValid;
        }
        public GeoLocation(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public void SetLatitude(double latitude)
        {
            System.Diagnostics.Debug.Print("Latitude: " + latitude);
            this.latitude = latitude;
        }
        public double GetLatitude()
        {
            return this.latitude;
        }

        public void SetLongitude(double longitude)
        {
            System.Diagnostics.Debug.Print("Longitude: " + longitude);
            this.longitude = longitude;
        }
        public double GetLongitude()
        {
            return this.longitude;
        }

        public void SetTimeStamp(DateTime timeStamp)
        {
            this.timeStamp = timeStamp;
        }

        public DateTime GetTimeStamp()
        {
            return timeStamp;
        }

        public void SetDateStamp(DateTime dateStamp)
        {
            this.dateStamp = dateStamp;
        }

        public DateTime GetDateStamp()
        {
            return dateStamp;
        }

        public void SetValidity(String validity)
        {
            this.validity = validity;
        }

        public String GetValidity()
        {
            return validity;
        }

        public void SetNorthSouth(String northSouth)
        {
            this.northSouth = northSouth;
        }

        public String GetNorthSouth()
        {
            return northSouth;
        }

        public void SetEastWest(String eastWest)
        {
            this.eastWest = eastWest;
        }

        public String GetEastWest()
        {
            return eastWest;
        }

        public void SetKnots(Double knots)
        {
            this.knots = knots;
        }

        public Double GetKnots()
        {
            return knots;
        }

        public void SetVariation(Double variation)
        {
            this.variation = variation;
        }

        public double GetVariation()
        {
            return variation;
        }

        public void SetVariationDirection(String variationDirection)
        {
            this.eastWestVariationDirection = variationDirection;
        }

        public String GetVariationDirection()
        {
            return eastWestVariationDirection;
        }

        public void SetCheckSum(String checkSum)
        {
            this.checksum = checkSum;
        }

        public String GetCheckSum()
        {
            return checksum;
        }



    }
}
