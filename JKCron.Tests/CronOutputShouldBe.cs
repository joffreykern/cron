using NUnit.Framework;
using TestStack.BDDfy;

namespace JKCron.Tests
{
    public class CronOutputShouldBe
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
        public void FormatAsExpected(
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
                                              $"minute        {minute}{EndOfLineHelper.GetEndLine()}" +
                                              $"hour          {hour}{EndOfLineHelper.GetEndLine()}" +
                                              $"day of month  {dayOfMonth}{EndOfLineHelper.GetEndLine()}" +
                                              $"month         {month}{EndOfLineHelper.GetEndLine()}" +
                                              $"day of week   {dayOfWeek}{EndOfLineHelper.GetEndLine()}" +
                                              $"command       {command}{EndOfLineHelper.GetEndLine()}"))
                .BDDfy();
        }
    }
}