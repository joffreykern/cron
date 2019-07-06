using NUnit.Framework;
using TestStack.BDDfy;

namespace JKCron.Tests
{
    public class CronShouldReturnExpectedValueWhenUsingADash
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
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "1-10", "0", "0", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.MinuteOutputIs("1 2 3 4 5 6 7 8 9 10"))
                .BDDfy();
        }

        [Test]
        public void ForHour()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "20-23", "0", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.HourOutputIs("20 21 22 23"))
                .BDDfy();
        }

        [Test]
        public void ForDayOfMonth()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "12-17", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.DayOfMonthOutputIs("12 13 14 15 16 17"))
                .BDDfy();
        }

        [Test]
        public void ForMonth()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "1-12", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.MonthOutputIs("1 2 3 4 5 6 7 8 9 10 11 12"))
                .BDDfy();
        }

        [Test]
        public void ForDayOfWeek()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "0", "2-3", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.DayOfWeekOutputIs("2 3"))
                .BDDfy();
        }
    }
}
