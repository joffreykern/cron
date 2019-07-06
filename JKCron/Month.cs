namespace JKCron
{
    public class Month
    {
        public static string Parse(string input)
        {
            return Parameter.Parse(input, 1, 12);
        }
    }
}