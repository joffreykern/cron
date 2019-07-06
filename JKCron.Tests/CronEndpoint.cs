using FluentAssertions;
using System;
using System.IO;
using System.Linq;

namespace JKCron.Tests
{
    public class CronEndpoint
    {
        private string[] _parameters;
        private StringWriter _textWriter;

        public CronEndpoint()
        {
            _textWriter = new StringWriter();
            Console.SetOut(_textWriter);
        }

        public void OutputShouldReturn(string output)
        {
            _textWriter.GetStringBuilder().ToString().Should().Be(output);
        }

        public void ExecuteCron()
        {
            JKCron.Program.Main(_parameters);
        }

        public void ParametersAre(string[] parameters)
        {
            _parameters = parameters;
        }

        public void MinuteOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split("\r\n").ElementAt(0).Should()
                .Be($"minute \t\t{expectedOutput}");
        }

        public void HourOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split("\r\n").ElementAt(1).Should()
                .Be($"hour \t\t{expectedOutput}");
        }

        public void DayOfMonthOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split("\r\n").ElementAt(2).Should()
                .Be($"day of month \t{expectedOutput}");
        }

        public void MonthOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split("\r\n").ElementAt(3).Should()
                .Be($"month \t\t{expectedOutput}");
        }

        public void DayOfWeekOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split("\r\n").ElementAt(4).Should()
                .Be($"day of week \t{expectedOutput}");
        }

        public void CommandOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split("\r\n").ElementAt(5).Should()
                .Be($"command \t{expectedOutput}");
        }
    }
}