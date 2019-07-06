using System;

namespace JKCron
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"minute \t\t{args[0]}");
            Console.WriteLine($"hour \t\t{args[1]}");
            Console.WriteLine($"day of month \t{args[2]}");
            Console.WriteLine($"month \t\t{args[3]}");
            Console.WriteLine($"day of week \t{args[4]}");
            Console.WriteLine($"command \t{args[5]}");
        }
    }
}
