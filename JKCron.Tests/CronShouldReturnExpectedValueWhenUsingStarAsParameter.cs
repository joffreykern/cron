using NUnit.Framework;
using TestStack.BDDfy;

namespace JKCron.Tests
{
    public class CronShouldReturnExpectedValueWhenUsingStarAsParameter
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
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "*", "0", "0", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.MinuteOutputIs(
                    "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59"))
                .BDDfy();
        }

        [Test]
        public void ForHour()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "*", "0", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.HourOutputIs("0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23"))
                .BDDfy();
        }

        [Test]
        public void ForDayOfMonth()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "*", "0", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.DayOfMonthOutputIs("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31"))
                .BDDfy();
        }

        [Test]
        public void ForMonth()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "*", "0", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.MonthOutputIs("1 2 3 4 5 6 7 8 9 10 11 12"))
                .BDDfy();
        }

        [Test]
        public void ForDayOfWeek()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "0", "*", "/usr/bind/find" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.DayOfWeekOutputIs("1 2 3 4 5 6 7"))
                .BDDfy();
        }


        [Test]
        public void ForCommand()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "0", "0", "*" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.CommandOutputIs("*"))
                .BDDfy();
        }
    }
}
