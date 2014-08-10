using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team2.PSU.Wireless.Mesh.Util;
namespace Team2.PSU.Wireless.Mesh.Commands
{
    public class ReceiveTextCmd : Command
    {   
        private String text;

        public ReceiveTextCmd(String commandString, CommandInterpreter interpreter) : base(commandString, interpreter)
        {
            this.action = new Action(ActionType.receiveText);
            SetupText(commandString);
        }

        public override void Execute()
        {
            if (action.GetActionType() != ActionType.invalid)
            {
                interpreter.HandleNewText(this);
            }
            else
            {
                System.Diagnostics.Debug.Print("Command String: " + commandString + " is invalid");
            }
        }

        public String GetText()
        {
            return text;
        }

        private void SetupText(String commandString)
        {
            try
            {
                text = GetParameterString();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.StackTrace);
                this.action = new Action(ActionType.invalid);
            }
        }
    }
}
