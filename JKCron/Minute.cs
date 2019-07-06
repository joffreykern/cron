using System.Linq;

namespace JKCron
{
    public class Minute
    {
        public static string Parse(string input)
        {
            if (input.ContainsComma())
            {
                return input.SplitByComma();
            }

            if (input == "*")
            {
                return string.Join(' ', Enumerable.Range(0, 60));
            }

            return input;
        }
    }
}