using System.Linq;

namespace JKCron
{
    public static class StringExtensions
    {
        private static char WhiteSpace = ' ';
        private const char Comma = ',';
        private const char Dash = '-';

        public static bool ContainsComma(this string input)
        {
            return input.Contains(Comma);
        }

        public static bool ContainsDash(this string input)
        {
            return input.Contains(Dash);
        }

        public static string SplitByComma(this string input)
        {
            return string.Join(WhiteSpace, input.Split(Comma));
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
