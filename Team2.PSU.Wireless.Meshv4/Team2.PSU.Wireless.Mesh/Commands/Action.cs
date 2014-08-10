using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Commands
{
    public enum ActionType { invalid, receiveText, sendText, updateLocation, updateAltitude, sendTakeImage, receiveImage, startReceiveImageTimer };

    public class Action
    {
        private ActionType actionType;
        private String nodeActionString;
        

        public Action(ActionType type)
        {
            this.actionType = type;
        }

        public Action(String type)
        {
            if (type.Length == 3)
            {
                nodeActionString = type;
                actionType = ConvertNodeCommandToActionType(type);
            }
            else
            {
                actionType = ConvertActionStringToType(type);
                nodeActionString = ConvertActionToNodeString(actionType);
            }
        }

        public ActionType GetActionType()
        {
            return actionType;
        }

        public static ActionType ConvertActionStringToType(String action)
        {
            if (action.Equals(ActionType.receiveImage.ToString()))
            {
                return ActionType.receiveImage;
            }
            else if (action.Equals(ActionType.receiveText.ToString()))
            {
                return ActionType.receiveText;
            }
            else if (action.Equals(ActionType.updateAltitude.ToString()))
            {
                return ActionType.updateAltitude;
            }
            else if (action.Equals(ActionType.updateLocation.ToString()))
            {
                return ActionType.updateLocation;
            }
            else if(action.Equals(ActionType.sendText.ToString()))
            {
                return ActionType.sendText;
            }
            else if (action.Equals(ActionType.sendTakeImage.ToString()))
            {
                return ActionType.sendTakeImage;
            }
            else if (action.Equals(ActionType.startReceiveImageTimer.ToString()))
            {
                return ActionType.startReceiveImageTimer;
            }
            else
            {
                return ActionType.invalid;
            }

        }

        public static ActionType ConvertNodeCommandToActionType(String nodeCommand)
        {
            if (nodeCommand.Equals("txr"))
            {
                return ActionType.receiveText;
            }
            else if(nodeCommand.Equals("txs"))
            {
                return ActionType.sendText;
            }

            else if(nodeCommand.Equals("pct"))
            {
                return ActionType.sendTakeImage;
            }
            else if(nodeCommand.Equals("gps"))
            {
                return ActionType.updateLocation;
            }
            else if(nodeCommand.Equals("pcr"))
            {
                return ActionType.receiveImage;
            }
            else if (nodeCommand.Equals("alt"))
            {
                return ActionType.updateAltitude;
            }
            else if (nodeCommand.Equals("bfc"))
            {
                return ActionType.startReceiveImageTimer;
            }
            else
            {
                return ActionType.invalid;
            }
        }

        public static String ConvertActionToNodeString(ActionType type)
        {

            if (type == ActionType.receiveImage)
            {
                return "pcr";
            }
            else if (type == ActionType.receiveText)
            {
                return "txr";
            }
            else if (type == ActionType.sendTakeImage)
            {
                return "pct";
            }
            else if (type == ActionType.sendText)
            {
                return "txs";
            }
            else if (type == ActionType.updateAltitude)
            {
                return "alt";
            }
            else if (type == ActionType.updateLocation)
            {
                return "gps";
            }
            else if (type == ActionType.startReceiveImageTimer)
            {
                return "bfc";
            }
            else
            {
                return "inv";
            }
        }


    }
}
