using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team2.PSU.Wireless.Mesh.Util;

namespace Team2.PSU.Wireless.Mesh.Commands
{
    public class CommandBuilder
    {

        private const int commandTypePositionStart = 3;
        private const int commandTypeLength = 3;

        public static Command getCommand(string commandString, CommandInterpreter interpreter)
        {
            String commandType;
            try
            {
                commandType = commandString.Substring(commandTypePositionStart, commandTypeLength);
                System.Diagnostics.Debug.Print("Building Command: " + commandString);
                if (commandType.Equals("txr"))
                {
                    System.Diagnostics.Debug.Print("Txt Command Received");
                    return new ReceiveTextCmd(commandString, interpreter);
                }
                else if (commandType.Equals("gps"))
                {
                    System.Diagnostics.Debug.Print("GPS Command Received");
                    return new UpdateLocationCmd(commandString, interpreter);
                }
                else if (commandType.Equals("pcr"))
                {
                    System.Diagnostics.Debug.Print("Image Received");
                    return new ReceiveImageCmd(commandString, interpreter);
                }
                else if (commandType.Equals("bfc"))
                {
                    System.Diagnostics.Debug.Print("Clear buffer, image incomming");
                    return new ClearBufferCmd(commandString, interpreter);
                }
                else
                {
                    System.Diagnostics.Debug.Print("Invalid Command Received");
                    return new InvalidCmd(commandString, interpreter);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Invalid Command Received: " + ex.ToString());
                return new InvalidCmd(commandString, interpreter);
            }
        }

    }
}
