using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace IndividualWork
{
    class Program
    {
        public static void Main(string[] args)
        {
            int consultationTime = 30; // формат разделения времени
            int[] durations = {30}; // занятый промежуток

            // тестовые данные
            TimeSpan test4 = new TimeSpan(11, 00, 00);

            TimeSpan[] startTimes = { test4}; // массив типа промежутков даты

            TimeSpan beginWorkingTime = new TimeSpan(08, 00, 00); // начальное время
            TimeSpan endWorkingTime = new TimeSpan(20, 00, 00); // конечное время  

            Console.WriteLine((int)endWorkingTime.TotalHours - (int)beginWorkingTime.TotalHours / durations[0]);

            List<TimeSpan> Times = new List<TimeSpan>();

            int count = 0;

            for(TimeSpan i = beginWorkingTime; i <= endWorkingTime; i+= new TimeSpan(00, 01, 00))
            {
                // только если время попадает в исключение
                for(int t = 0; t < startTimes.Length; t++)
                {
                    if (i == startTimes[t])
                    {
                        Times.Add(i);
                        i += new TimeSpan(00, durations[t], 00);
                        count = 0;
                    }
                }
                if (count == consultationTime) count = 0;
                if(count == 0)
                {
                    Times.Add(i);
                    Times.Add(i);
                }
                count++;
            }

            bool check = true;

            List<string> outputBegin = new List<string>();
            List<string> outputEnd = new List<string>();

            for (int i = 0; i < Times.Count; i++)
            {
                for (int t = 0; t < startTimes.Length; t++)
                {
                    if (Times[i] == startTimes[t])
                    {
                        outputEnd.Add(Times[i].ToString(@"hh\:mm"));
                        outputBegin.Add((Times[i] + new TimeSpan(00, durations[t], 00)).ToString(@"hh\:mm"));
                        check = false;
                    }
                }
                if (i == 0 || i % 2 == 0 && check == true) outputBegin.Add(Times[i].ToString(@"hh\:mm"));
                else if (i != 1 && i % 2 != 0 && check == true) outputEnd.Add(Times[i].ToString(@"hh\:mm"));
                check = true;
            }
           
            List<string> Result = new List<string>();

            for (int i = 0; i < outputEnd.Count; i++)
            {
                if(outputBegin[i] != outputEnd[i])
                Result.Add($"{outputBegin[i]}-{outputEnd[i]}");
            }

            string[] stringOut = new string[Result.Count];
            for (int i = 0; i < Result.Count; i++) stringOut[i] = Result[i];

            foreach (var item in stringOut) Console.WriteLine(item);
            Console.WriteLine(stringOut.Length);
            

            Console.ReadLine();
        }
    }
}

