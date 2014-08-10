using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team2.PSU.Wireless.Mesh.Util
{
    public static class StringFunctions
    {
        public static int commaPosition(String s, int startSearch)
        {
            try
            {
                return s.IndexOf(',', startSearch);
            }
            catch (IndexOutOfRangeException e)
            {
                System.Diagnostics.Debug.Print(e.StackTrace);
                return -1;
            }
        }

        public static String right(String s, int numberOfCharacters)
        {
            try
            {
                return s.Substring(s.Length - numberOfCharacters, numberOfCharacters);
            }
            catch (IndexOutOfRangeException e)
            {
                System.Diagnostics.Debug.Print(e.StackTrace);
                return "";
            }

        }

        public static Double ParseDouble(String d)
        {
            try
            {
                return Double.Parse(d);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.StackTrace);
                System.Diagnostics.Debug.Print("String: " + d + " could not be parsed to a double");
                return 0;
            }
        }
    }
}
