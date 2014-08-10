using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team2.PSU.Wireless.Mesh.Util.MapUtils;
using Team2.PSU.Wireless.Mesh.Util;
using Team2.PSU.Wireless.Mesh.View;

namespace Team2.PSU.Wireless.Mesh.Commands
{
    public class CommandInterpreter
    {
        private GroundStation groundStation;

        public CommandInterpreter(GroundStation groundStation)
        {
            this.groundStation = groundStation;
        }

        public void HandleNewMapLocation(UpdateLocationCmd command)
        {
            if (command.GetGeoLocation().isValid())
                groundStation.DisplayMapLocation(command.GetNode().ToString(), command.GetGeoLocation());
        }

        public void HandleNewText(ReceiveTextCmd command)
        {
            groundStation.DisplayText(command.GetText());
        }

        public void HandleNewImage(ReceiveImageCmd command)
        {
            //Need to handle the image string here
            System.Diagnostics.Debug.Print(command.GetImageText());
        }


     }
}
