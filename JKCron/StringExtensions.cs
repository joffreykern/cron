using System.Collections.Generic;
using System.Linq;

namespace JKCron
{
    public static class StringExtensions
    {
        private const char WhiteSpace = ' ';
        private const char Comma = ',';
        private const char Dash = '-';
        private const string StarSlash = "*/";

        public static bool ContainsComma(this string input)
        {
            return input.Contains(Comma);
        }

        public static bool ContainsDash(this string input)
        {
            return input.Contains(Dash);
        }

        public static bool StartWithStarSlash(this string input)
        {
            return input.Contains(StarSlash);
        }

        public static string SplitByComma(this string input)
        {
            return string.Join(WhiteSpace, input.Split(Comma));
        }

        public static string GetValueForStarSlash(this string input, int min, int max)
        {
            int multiplier = int.Parse(input.Substring(2));
            List<int> values = new List<int>();

            var current = min;
            while (current <= max)
            {
                values.Add(current);
                current += multiplier;
            }

            return string.Join(WhiteSpace, values);
        }

        public static string SplitByDash(this string input)
        {
            var tmp = input.Split(Dash);
            int start = int.Parse(tmp[0]);
            int end = int.Parse(tmp[1]);

            return string.Join(WhiteSpace, Enumerable.Range(start, end - start + 1));
        }
    }
}
