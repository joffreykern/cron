namespace JKCron
{
    public static class StringExtensions
    {
        public static bool ContainsComma(this string input)
        {
            return input.Contains(',');
        }

        public static string SplitByComma(this string input)
        {
            return string.Join(' ', input.Split(','));
        }
    }
}
