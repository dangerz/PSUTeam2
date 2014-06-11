using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GroundStation.classes;

namespace GroundStation.builder
{
    class mapBuilder
    {
        const string BASE_MAP_LOCATION = "http://maps.googleapis.com/maps/api/staticmap?";
        public Dictionary<string, vehicle> mVehicles;

        public mapBuilder()
        {
            mVehicles = new Dictionary<string, vehicle>();
        }
        /// <summary>
        /// Returns a Google Map API URL
        /// </summary>
        /// <returns></returns>
        public string getURL(string aWidth = "640", string aHeight = "640")
        {
            string whatToReturn = BASE_MAP_LOCATION;
            whatToReturn += "size=" + aWidth + "x" + aHeight + "&maptype=roadmap";
            if (mVehicles.Count() > 0)
            {
                foreach (vehicle veh in mVehicles.Values)
                {
                    whatToReturn += "&markers=";
                    whatToReturn += "color:red%7C";
                    whatToReturn += "label:" + veh.getName() + "%7C";
                    whatToReturn += veh.getLatitude() + "," + veh.getLongitude();
                }
            }
            else
            {
                whatToReturn += "&center=Fort Worth, TX";
            }
            return whatToReturn;
        }
        /// <summary>
        /// Adds vehicles to be used as markers when building a map
        /// </summary>
        /// <param name="aVehicle">Vehicle to be added</param>
        public void addVehicle(vehicle aVehicle)
        {
            mVehicles[aVehicle.getName()] = aVehicle;
        }
    }
}
