using System.Linq;

namespace JKCron
{
    public class Parameter
    {
        public static string Parse(string input, int min, int max)
        {
            if (input.ContainsDash())
            {
                return input.SplitByDash();
            }

            if (input.ContainsComma())
            {
                return input.SplitByComma();
            }

            if (input == "*")
            {
                return string.Join(' ', Enumerable.Range(min, max));
            }

            return input;
        }
    }
}