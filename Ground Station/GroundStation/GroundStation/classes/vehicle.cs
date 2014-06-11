using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroundStation.classes
{
    class vehicle
    {
        private double mLatitude;
        private double mLongitude;
        private string mName;

        /// <summary>
        /// Creates a new vehicle object
        /// </summary>
        /// <param name="aName">Name of the vehicle, limited to 1 character.</param>
        /// <param name="aLatitude">Longitude of the vehicle</param>
        /// <param name="aLongitude">Latitude of the vehicle</param>
        public vehicle(string aName, double aLatitude, double aLongitude)
        {
            mLatitude = aLatitude;
            mLongitude = aLongitude;
            
            if (aName.Length > 1)
                aName = aName.Substring(0, 1);

            mName = aName;
        }

        public void setLongitude(double aLongitude)
        {
            mLongitude = aLongitude;
        }
        public void setLatitude(double aLatitude)
        {
            mLatitude = aLatitude;
        }
        public string getName() { return mName; }
        public double getLatitude() { return mLatitude; }
        public double getLongitude() { return mLongitude; }
    }
}
