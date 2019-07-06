
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
        public void ExpectedValueForGivenInput()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new[] { "*/15", "0", "1,15", "*", "1-5", "/usr/bin/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.MinuteOutputIs("0 15 30 45"))
                .And(_ => _cronEndpoint.HourOutputIs("0"))
                .And(_ => _cronEndpoint.DayOfMonthOutputIs("1 15"))
                .And(_ => _cronEndpoint.MonthOutputIs("1 2 3 4 5 6 7 8 9 10 11 12"))
                .And(_ => _cronEndpoint.DayOfWeekOutputIs("1 2 3 4 5"))
                .And(_ => _cronEndpoint.CommandOutputIs("/usr/bin/find"))
                .BDDfy();
        }
    }
}
