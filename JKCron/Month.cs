using System.Linq;

namespace JKCron
{
    public class Month
    {
        public static string Parse(string input)
        {
            if (input.ContainsComma())
            {
                return input.SplitByComma();
            }

            if (input == "*")
            {
                return string.Join(' ', Enumerable.Range(1, 12));
            }

            return input;
        }
    }
}