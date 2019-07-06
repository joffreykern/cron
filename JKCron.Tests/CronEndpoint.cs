using FluentAssertions;
using System;
using System.IO;

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
    }
}