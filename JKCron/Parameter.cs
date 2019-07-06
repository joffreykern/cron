using System.Linq;

namespace JKCron
{
    public class Parameter
    {
        public static string Parse(string input, int min, int max)
        {
            if (input.StartWithStarSlash())
            {
                return input.GetValueForStarSlash(min, max);
            }

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
                return string.Join(' ', Enumerable.Range(min, max - min + 1));
            }

            return input;
        }
    }
}