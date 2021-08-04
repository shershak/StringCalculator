using NUnit.Framework;
using StringCalculator;

namespace StringCalculatorTests
{
    [TestFixture]
    public class StringCalcTests
    {
        StringCalc Calc;

        [SetUp]
        public void Setup()
        {
            Calc = new StringCalc();
        }

        [Test]
        public void Add_EmptyString_Return0()
        {
            // Arrange
            string input = "";
            int expected = 0;

            // Act
            int actual = Calc.Add(input);
           
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_Input1_Return1()
        {
            // Arrange
            string input = "1";
            int expected = 1;

            // Act
            int actual = Calc.Add(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_Input1and2_Return3()
        {
            // Arrange
            string input = "1,2";
            int expected = 3;

            // Act
            int actual = Calc.Add(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}