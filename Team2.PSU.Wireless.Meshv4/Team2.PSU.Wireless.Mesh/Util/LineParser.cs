using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Util
{
    class LineParser
    {

        private int currentPosition;
        private String line;


        public LineParser(String line)
        {
            currentPosition = 1;
            this.line = line;
        }

        public String GetValueAtPosition(int position)
        {
            int commaPosition = 1;

            for (int c = 1; c <= position; c++)
            {
                commaPosition = StringFunctions.commaPosition(line, commaPosition + 1);
            }
            int nextCommaPosition = StringFunctions.commaPosition(line, commaPosition + 1);

            if (nextCommaPosition == -1)
            {
                return line.Substring(commaPosition + 1);
            }
            else
            {
                return line.Substring(commaPosition + 1, nextCommaPosition - commaPosition - 1);
            }
        }
    }
}
