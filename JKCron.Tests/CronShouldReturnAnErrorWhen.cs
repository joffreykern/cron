using NUnit.Framework;
using TestStack.BDDfy;

namespace JKCron.Tests
{
    public class CronShouldReturnAnErrorWhen
    {
        private string ExpectedErrorMessage = "Invalid number of parameters, we are expecting 6 parameters" + EndOfLineHelper.GetEndLine();
        private CronEndpoint _cronEndpoint;

        [SetUp]
        public void Setup()
        {
            _cronEndpoint = new CronEndpoint();
        }

        [Test]
        public void ParametersAreNull()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(null))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.OutputShouldReturn(ExpectedErrorMessage))
                .BDDfy();
        }

        [Test]
        public void NumberOfParametersEqualsZero()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.OutputShouldReturn(ExpectedErrorMessage))
                .BDDfy();
        }

        [Test]
        public void NumberOfParametersEqualsSeven()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "0", "0", "/usr/bind/hello", "onemoretime" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.OutputShouldReturn(ExpectedErrorMessage))
                .BDDfy();
        }

        [Test]
        public void NumberOfParametersEqualsFive()
        {
            this.Given(_ => _cronEndpoint.ParametersAre(new string[] { "0", "0", "0", "0", "0" }))
                .When(_ => _cronEndpoint.ExecuteCron())
                .Then(_ => _cronEndpoint.OutputShouldReturn(ExpectedErrorMessage))
                .BDDfy();
        }
    }
}
