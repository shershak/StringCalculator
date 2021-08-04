using NUnit.Framework;
using StringCalculator;
using System;

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
        #region Task 1
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
        #endregion
        #region Task 2
        [Test]
        public void Add_Input1and2and3_Return6()
        {
            // Arrange
            string input = "1,2,3";
            int expected = 6;

            // Act
            int actual = Calc.Add(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region Task 3
        [Test]
        public void Add_Input1and2and3WithNewLine_Return6()
        {
            // Arrange
            string input = "1\n2,3";
            int expected = 6;

            // Act
            int actual = Calc.Add(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region Task 4
        [Test]
        public void Add_Input1and2WithSemicolonDelimiter_Return3()
        {
            // Arrange
            string input = "//;\n1;2";
            int expected = 3;

            // Act
            int actual = Calc.Add(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region Task 5
        [Test]
        public void Add_InputNegative1_ReturnException()
        {
            // Arrange
            string input = "-1";

            // Assert
            Assert.Throws<Exception>(delegate { Calc.Add(input); } );
        }
        [Test]
        public void Add_InputMultipleNegative_ReturnException()
        {
            // Arrange
            string input = "-1,-2,-3";

            // Assert
            Assert.Throws<Exception>(delegate { Calc.Add(input); });
        }
        #endregion
    }
}