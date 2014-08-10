using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Team2.PSU.Wireless.Mesh.Util
{
    static class IncomingData
    {
        private static string mpCurrentText;
        private static Mutex mutex = new Mutex();

        public static void lockMutex() { mutex.WaitOne(); }
        public static void unlockMutex() { mutex.ReleaseMutex(); }

        /// <summary>
        /// Thread Safe
        /// Adds onto the current text in memory.
        /// </summary>
        /// <param name="pText">New Text</param>
        public static void addIncomingText(string pText)
        {
            mutex.WaitOne(); // make sure we are not locked
            mpCurrentText += pText;
            mutex.ReleaseMutex();
        }
        /// <summary>
        /// Not Thread Safe
        /// Dangerous method, only call if you are personally handling the Mutex lock.  This will return the current text without a mutex locker in place.
        /// </summary>
        /// <returns>Current Text In Memory</returns>
        public static string getCurrentTextNotMutexed()
        {
            return mpCurrentText;
        }
        /// <summary>
        /// Not Thread Safe
        /// Dangerous method, only call if you are personally handling the Mutex lock.  Sets the current text to a whole new value without checking for mutex lock.
        /// </summary>
        /// <param name="pNewText">New Text Value.</param>
        public static void setCurrentTextNotMutexed(string pNewText)
        {
            mpCurrentText = pNewText;
        }
        /// <summary>
        /// Thread Safe
        /// Returns the current text in memory.
        /// </summary>
        /// <returns>Current Text In Memory</returns>
        public static string getCurrentText()
        {
            mutex.WaitOne(); // make sure we are not locked
            string textToReturn = mpCurrentText; // get a copy
            mutex.ReleaseMutex();
            return textToReturn; // return the copy
        }
        /// <summary>
        /// Thread Safe
        /// Sets the current text to a whole new value.
        /// </summary>
        /// <param name="pNewText">New Text Value.</param>
        public static void setCurrentText(string pNewText)
        {
            mutex.WaitOne(); // make sure we are not locked
            mpCurrentText = pNewText;
            mutex.ReleaseMutex();
        }
    }
}
