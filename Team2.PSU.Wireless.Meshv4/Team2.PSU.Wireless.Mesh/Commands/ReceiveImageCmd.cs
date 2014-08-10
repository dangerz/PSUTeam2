using System;
using System.Collections.Generic;
using Team2.PSU.Wireless.Mesh.Properties;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Commands
{
    public class ReceiveImageCmd : Command
    {
        private Settings settings = Settings.Default;

        private String imageString = "";
        public ReceiveImageCmd(String commandString, CommandInterpreter interpreter)
            : base(commandString, interpreter)
        {
            this.action = new Action(ActionType.receiveImage);
            setupImage();
        }

        public override void Execute()
        {
            interpreter.HandleNewImage(this);
        }

        public String GetImageText()
        {
            return imageString;
        }

        private void setupImage()
        {
            try
            {
                imageString = GetParameterString(); // remember that this is a string of hex values
                int numChars = imageString.Length;
                if (numChars % 2 == 1)
                {
                    numChars++;
                    imageString += "9"; // addition to the end in case of corrupt to make sure we are ok, jpegs are lossy so they'll compensate
                }
                byte[] byteArray = new byte[numChars / 2];

                for (int i = 0; i < numChars; i += 2)
                    byteArray[i / 2] = Convert.ToByte(imageString.Substring(i, 2), 16);

                string receivedFilePath = settings.ReceivedFilePath;
                string webFileName = settings.WWWFilePath;
                string sourceFileName = receivedFilePath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss.ff") + ".jpg"; // name the file

                System.IO.FileStream fileStream = new System.IO.FileStream(sourceFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                fileStream.Write(byteArray, 0, byteArray.Length); // write the byte array to the file
                fileStream.Close();

                System.Threading.Thread.Sleep(2000);
                System.IO.File.Copy(sourceFileName, webFileName, true);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.StackTrace);
                this.action = new Action(ActionType.invalid);
            }
        }

    }
}
