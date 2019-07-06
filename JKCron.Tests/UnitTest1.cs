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
        public void ReturnTheCorrectValuesForTheGivenParameters()
        {
            this.Given(_ => ParametersAre(new string[] { "15" }))
                .When(_ => ExecuteCron())
                .Then(_ => OutputShouldReturn("minute \t\t15\r\n"))
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