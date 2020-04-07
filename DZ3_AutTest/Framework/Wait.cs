using System;
using System.Threading;

namespace DZ3_AutTest.Framework
{
    public class Wait
    {
        public static bool WaitFor(Func<bool> func, int millisecondsTimeout = 250, int waitInterval = 50)
        {
            DateTime start = DateTime.Now;
            do
            {
                if (func())
                    return true;
                Thread.Sleep(waitInterval);
            } 
            while (DateTime.Now - start < TimeSpan.FromMilliseconds(millisecondsTimeout));

            return false;
        }
    }
}