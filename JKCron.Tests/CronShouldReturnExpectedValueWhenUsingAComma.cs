using NUnit.Framework;
using NUnit.Framework.Internal;
using TestStack.BDDfy;

namespace JKCron.Tests
{
    public class CronShouldReturnExpectedValueWhenUsingAComma
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
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "1,15", "0", "0", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.MinuteOutputIs("1 15"))
                .BDDfy();
        }

        [Test]
        public void ForHour()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "1,4,19", "0", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.HourOutputIs("1 4 19"))
                .BDDfy();
        }

        [Test]
        public void ForDayOfMonth()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "1,12,31", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.DayOfMonthOutputIs("1 12 31"))
                .BDDfy();
        }


        [Test]
        public void ForMonth()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "3,9,12", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.MonthOutputIs("3 9 12"))
                .BDDfy();
        }

        [Test]
        public void ForDayOfWeek()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "0", "1,2,4", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.DayOfWeekOutputIs("1 2 4"))
                .BDDfy();
        }
    }
}
