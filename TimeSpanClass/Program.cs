using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpanClass
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var time in Intervals(new TimeSpan[] {
                new TimeSpan(10,00,00),
                new TimeSpan(11,00,00),
                new TimeSpan(15,00,00),
                new TimeSpan(15,30,00),
                new TimeSpan(16,50,00), }, new int[] { 60, 30, 10, 10, 40 }, new TimeSpan(08, 00, 00), new TimeSpan(18, 00, 00), 30))
            {
                Console.WriteLine(time.ToList());
            }

            Console.ReadKey();
        }

        public static IEnumerable<string> Intervals(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            List<string> timeInterval = new List<string>();
            TimeSpan beginTime;
            TimeSpan endTime;
            var time = beginWorkingTime;

            for (int i = 0; i < startTimes.Count(); i++)
            {
                for (TimeSpan t = time; t < startTimes[i]; t += TimeSpan.FromMinutes(consultationTime))
                {
                    for (TimeSpan ts = time; ts < startTimes[i]; ts += TimeSpan.FromMinutes(1))
                    {
                        try
                        {
                            if (startTimes[i] == ts)
                                time += TimeSpan.FromMinutes(durations[i]);
                        }
                        catch { }
                    }

                    beginTime = time;
                    time += TimeSpan.FromMinutes(consultationTime);
                    endTime = time;
                    timeInterval.Add(beginTime + " - " + endTime);
                    yield return timeInterval.ToString();
                }
            }
        }
    }
}
