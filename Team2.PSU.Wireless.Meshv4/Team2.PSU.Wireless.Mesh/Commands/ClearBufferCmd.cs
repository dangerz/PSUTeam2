using System;
using System.Collections.Generic;
using Team2.PSU.Wireless.Mesh.Properties;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Commands
{
    public class ClearBufferCmd : Command
    {
        public ClearBufferCmd(String commandString, CommandInterpreter interpreter)
            : base(commandString, interpreter)
        {
            this.action = new Action(ActionType.startReceiveImageTimer);
        }

        public override void Execute()
        {
            
        }
    }
}
