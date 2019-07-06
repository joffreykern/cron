namespace JKCron
{
    public class Minute
    {
        public static string Parse(string input)
        {
            return Parameter.Parse(input, 0, 60);
        }
    }
}