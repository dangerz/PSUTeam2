using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Commands
{
    class InvalidCmd : Command
    {
        public InvalidCmd(String commandString) : base(commandString)
        {
            this.action = new Action(ActionType.invalid);
        }

        
    }
}
