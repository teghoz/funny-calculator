using FunnyCalculator;
using NUnit.Framework;

namespace FunnyCalculatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestItShouldReturnTheAdditionOfAllOperands()
        {
            Calculator calc = new Calculator();
            var result = calc.Add("1,2,3,4");
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void TestItShouldReturnZeroWhenNumberIsEitherNullOrEmpty()
        {
            Calculator calc = new Calculator();
            var result = calc.Add(null);
            Assert.AreEqual(result, 0);

            var result1 = calc.Add(string.Empty);
            Assert.AreEqual(result1, 0);
        }
        [Test]
        public void TestItShouldReturnNullWhenNegativeNumbersExist()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(calc.Add($@"1,-3"), null);
        }
        [Test]
        public void TestItShouldReturnNullWhenFormatIsWrong()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(calc.Add($@"ABCDEFGHIJ"), null);

            Calculator calc1 = new Calculator();
            Assert.AreEqual(calc1.Add($@"1,\n"), null);
        }
        [Test]
        public void TestItShouldReturnResultWhenDelimiterIsUsed()
        {
            Calculator calc = new Calculator();
            var result = calc.Add("//;\n1;2");
            Assert.AreEqual(result, 3);
        }
    }
}