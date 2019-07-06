using NUnit.Framework;

namespace JKCron.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            JKCron.Program.Main(null);
        }
    }
}