using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_AutoTextTimer
{
    internal class TextUpdater
    {
        static void Main()
        {
            Console.WriteLine("Enter Timer: ");
            TimeSpan totalMinutes = TimeSpan.FromMinutes(Double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter File Update Interval: ");
            TimeSpan updateInterval = TimeSpan.FromMinutes(Double.Parse(Console.ReadLine()));

            Console.CancelKeyPress += Reset;

            for (double i = totalMinutes.Minutes; i > 0; i-=updateInterval.Minutes)
            {
                ChangeTxtFileValue(@"C:\Users\A\Downloads\Stream Assets\New Text Document.txt", $"Be back in {i} {(i>1?"minutes":"minute")}");
                Wait(updateInterval);
            }

            ChangeTxtFileValue(@"C:\Users\A\Downloads\Stream Assets\New Text Document.txt", $"Be back soon");
        }

        static void Wait(TimeSpan minutes)
        {
            DateTime startTime = DateTime.UtcNow;

            while (DateTime.UtcNow - startTime < minutes) ;//wait for timespan to end
        }

        static void ChangeTxtFileValue(string path, string value)
        {
            File.WriteAllText(path, value);
        }

        static void Reset(object? sender, EventArgs e)
        {
            ChangeTxtFileValue(@"C:\Users\A\Downloads\Stream Assets\New Text Document.txt", "");
        }

        
    }
}
