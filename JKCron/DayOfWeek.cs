namespace JKCron
{
    public class DayOfWeek
    {
        public static string Parse(string input)
        {
            return Parameter.Parse(input, 1, 7);
        }
    }
}