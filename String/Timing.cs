using System;
using System.Diagnostics;

namespace String
{
    public class Timing
    {
        TimeSpan startingTime;
        //startingTime - to store the starting time of the code we are testing
        //duration - the ending time of the code we are testing
        TimeSpan duration;

        public Timing()
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }

        public void stopTime() {
            duration = 
                Process.GetCurrentProcess().Threads[0].
                UserProcessorTime.Subtract(startingTime);
        }

        public void startTime() {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime = 
                Process.GetCurrentProcess().Threads[0].
                UserProcessorTime;
        }

        public TimeSpan Result() {
            return duration;
        }
    }
}
