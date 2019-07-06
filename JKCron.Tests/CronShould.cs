using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using TestStack.BDDfy;

namespace JKCron.Tests
{
    public class CronShould
    {
        private string[] _parameters;
        private StringWriter _textWriter;

        [SetUp]
        public void Setup()
        {
            _textWriter = new StringWriter();
            Console.SetOut(_textWriter);
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
            this.Given(_ => ParametersAre(new string[] { minute, hour, dayOfMonth, month, dayOfWeek, command }))
                .When(_ => ExecuteCron())
                .Then(_ => OutputShouldReturn($"minute \t\t{minute}\r\n" +
                                              $"hour \t\t{hour}\r\n" +
                                              $"day of month \t{dayOfMonth}\r\n" +
                                              $"month \t\t{month}\r\n" +
                                              $"day of week \t{dayOfWeek}\r\n" +
                                              $"command \t{command}\r\n"))
                .BDDfy();
        }

        private void OutputShouldReturn(string output)
        {
            _textWriter.GetStringBuilder().ToString().Should().Be(output);
        }

        private void ExecuteCron()
        {
            JKCron.Program.Main(_parameters);
        }

        private void ParametersAre(string[] parameters)
        {
            _parameters = parameters;
        }
    }
}