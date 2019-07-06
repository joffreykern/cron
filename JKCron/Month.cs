using System.Linq;

namespace JKCron
{
    public class Month
    {
        public static string Parse(string month)
        {
            if (month == "*")
            {
                return string.Join(' ', Enumerable.Range(1, 12));
            }

            return month;
        }
    }
}