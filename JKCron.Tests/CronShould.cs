using NUnit.Framework;
using TestStack.BDDfy;

namespace JKCron.Tests
{
    public class CronShould
    {
        private CronEndpoint _cronEndpoint;

        [SetUp]
        public void Setup()
        {
            _cronEndpoint = new CronEndpoint();
        }

        [Test]
        [TestCase("9", "12", "15", "5", "1", "/usr/bind/find")]
        [TestCase("1", "2", "3", "4", "5", "/usr/bind/dotnet")]
        [TestCase("60", "24", "31", "12", "7", "/usr/bind/helloworld")]
        [TestCase("0", "0", "0", "0", "0", "/usr/bind/hello")]
        public void ReturnTheCorrectValuesForTheGivenParameters(
            string minute,
            string hour,
            string dayOfMonth,
            string month,
            string dayOfWeek,
            string command)
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { minute, hour, dayOfMonth, month, dayOfWeek, command }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.OutputShouldReturn(
                                              $"minute        {minute}\r\n" +
                                              $"hour          {hour}\r\n" +
                                              $"day of month  {dayOfMonth}\r\n" +
                                              $"month         {month}\r\n" +
                                              $"day of week   {dayOfWeek}\r\n" +
                                              $"command       {command}\r\n"))
                .BDDfy();
        }
    }
}