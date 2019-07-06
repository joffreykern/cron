using System.Linq;

namespace JKCron
{
    public class Minute
    {
        public static string Parse(string minute)
        {
            if (minute == "*")
            {
                return string.Join(' ', Enumerable.Range(0, 60));
            }

            return minute;
        }
    }
}