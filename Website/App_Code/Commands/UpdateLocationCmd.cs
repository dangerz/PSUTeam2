using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team2.PSU.Wireless.Mesh.Util.MapUtils;
using Team2.PSU.Wireless.Mesh.Util;

namespace Team2.PSU.Wireless.Mesh.Commands
{
    public class UpdateLocationCmd : Command
    {

        private GeoLocation location;


        public UpdateLocationCmd(String commandString)
            : base(commandString)
        {
            if (commandString.Contains("NoFix"))
            {
                this.action = new Action(ActionType.invalid);
            }
            else
            {
                this.action = new Action(ActionType.updateLocation);
                SetupGeoLocation();
            }
        }

        override public void Execute()
        {
            if (action.GetActionType() != ActionType.invalid)
            {
               
            }
            else
            {
                System.Diagnostics.Debug.Print("Command String: " + commandString + " is invalid.");
            }

        }

        private void SetupGeoLocation()
        {
            System.Diagnostics.Debug.Print ("Geo String: " + GetParameterString());
            location = GeoLocationBuilder.GetGeoLocation(GetParameterString());
        }

        public GeoLocation GetGeoLocation()
        {
            return location;
        }


    }
}
