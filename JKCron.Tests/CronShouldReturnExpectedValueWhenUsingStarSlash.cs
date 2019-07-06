using NUnit.Framework;
using TestStack.BDDfy;

namespace JKCron.Tests
{
    public class CronShouldReturnExpectedValueWhenUsingStarSlash
    {
        private CronEndpoint _cronEndpoint;

        [SetUp]
        public void Setup()
        {
            _cronEndpoint = new CronEndpoint();
        }

        [Test]
        public void ForMinute()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "*/15", "*/2", "*/5", "*/3", "*/1", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.MinuteOutputIs("0 15 30 45"))
                .And(_ => _cronEndpoint.HourOutputIs("0 2 4 6 8 10 12 14 16 18 20 22"))
                .And(_ => _cronEndpoint.DayOfMonthOutputIs("1 6 11 16 21 26 31"))
                .And(_ => _cronEndpoint.MonthOutputIs("1 4 7 10"))
                .And(_ => _cronEndpoint.DayOfWeekOutputIs("1 2 3 4 5 6 7"))
                .BDDfy();
        }
    }
}
