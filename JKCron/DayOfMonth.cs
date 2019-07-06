namespace JKCron
{
    public class DayOfMonth
    {
        public static string Parse(string input)
        {
            return Parameter.Parse(input, 1, 31);
        }
    }
}