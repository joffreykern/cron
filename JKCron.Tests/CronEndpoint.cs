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
            _textWriter.GetStringBuilder().ToString().Split(EndOfLineHelper.GetEndLine()).ElementAt(0).Should()
                .Be($"minute        {expectedOutput}");
        }

        public void HourOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split(EndOfLineHelper.GetEndLine()).ElementAt(1).Should()
                .Be($"hour          {expectedOutput}");
        }

        public void DayOfMonthOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split(EndOfLineHelper.GetEndLine()).ElementAt(2).Should()
                .Be($"day of month  {expectedOutput}");
        }

        public void MonthOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split(EndOfLineHelper.GetEndLine()).ElementAt(3).Should()
                .Be($"month         {expectedOutput}");
        }

        public void DayOfWeekOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split(EndOfLineHelper.GetEndLine()).ElementAt(4).Should()
                .Be($"day of week   {expectedOutput}");
        }

        public void CommandOutputIs(string expectedOutput)
        {
            _textWriter.GetStringBuilder().ToString().Split(EndOfLineHelper.GetEndLine()).ElementAt(5).Should()
                .Be($"command       {expectedOutput}");
        }
    }
}