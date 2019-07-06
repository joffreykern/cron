namespace JKCron
{
    public class Hour
    {
        public static string Parse(string input)
        {
            return Parameter.Parse(input, 0, 24);
        }
    }
}