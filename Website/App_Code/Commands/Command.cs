using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team2.PSU.Wireless.Mesh.Util;
namespace Team2.PSU.Wireless.Mesh.Commands
{

    public enum AvailableNodes { GroundStation, Plane, QuadCopter }
    
    
     public class Command
    {
        public const String commandEnder = ",**";   
        protected Action action;
        protected String commandString;
        protected AvailableNodes node;
        protected String nodeCommandString;
  
        protected int parameterStartPosition = 6;



        public Command(String commandString)
        {
            this.commandString = commandString;
            SetNode();
        }

        public virtual void Execute() { }

        public String GetCommandString()
        {
            return commandString;
        }

        public void setCommandString(String commandString)
        {
            this.commandString = commandString;
        }

        public AvailableNodes GetNode()
        {
            return this.node;
        }

        protected String GetParameterString()
        {
            return commandString.Substring(parameterStartPosition, commandString.Length - parameterStartPosition - commandEnder.Length);
        }
        private void SetNode()
        {
            String nodeString = commandString.Substring(0, 3);
            System.Diagnostics.Debug.Print("Node: " + nodeString);
            if (nodeString.Equals("pl1"))
            {
                this.node = AvailableNodes.Plane;
            }
            else if (nodeString.Equals("qd1"))
            {
                this.node = AvailableNodes.QuadCopter;
            }
            else if (nodeString.Equals("gs1"))
            {
                this.node = AvailableNodes.GroundStation;
            }
        }

        
    }
}
