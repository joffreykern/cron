using System;

namespace JKCron
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length != 6)
            {
                Console.WriteLine("Invalid number of parameters, we are expecting 6 parameters");
                return;
            }

            Console.WriteLine($"minute \t\t{Minute.Parse(args[0])}");
            Console.WriteLine($"hour \t\t{Hour.Parse(args[1])}");
            Console.WriteLine($"day of month \t{DayOfMonth.Parse(args[2])}");
            Console.WriteLine($"month \t\t{Month.Parse(args[3])}");
            Console.WriteLine($"day of week \t{DayOfWeek.Parse(args[4])}");
            Console.WriteLine($"command \t{args[5]}");
        }
    }
}
