using System.Linq;

namespace JKCron
{
    public class DayOfMonth
    {
        public static string Parse(string input)
        {
            if (input == "*")
            {
                return string.Join(' ', Enumerable.Range(1, 31));
            }

            return input;
        }
    }
}