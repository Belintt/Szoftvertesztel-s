using ConsoleApp1;
namespace TestProject1
{
    public class Tests
    {
        BusinessLogic? logic;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            logic = new BusinessLogic();
        }
        [TestCase("3/0")]
        [TestCase("3+3-2/0")]
        [TestCase("3/3")]
        public void DivideByZeroException(string input)
        {
            Assert.Throws(typeof(DivideByZeroException), () => logic.Szamolas(input));
        }


        [TestCase("2asd+2")]
        [TestCase("3+3!")]
        [TestCase("3/3")]
        public void FormatExceptionIfInvalidFormat(string input)
        {
            Assert.Throws(typeof(FormatException), () => logic.Szamolas(input));
        }


        [TestCase("5+5+5", 15)]
        [TestCase("3*25/12", 6.25)]
        [TestCase("4+2*7-1", 17)]
        public void MainTest(string input, double shouldbethis)
        {
            if (shouldbethis == logic.Szamolas(input))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}