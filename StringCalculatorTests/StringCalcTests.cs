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

        #region Task 1, 4
        [TestCase("", ExpectedResult = 0)]
        public int Add_EmptyString_Return0(string input)
        {
            return Calc.Add(input);
        }

        [TestCase("1", ExpectedResult = 1)]
        public int Add_Input1_Return1(string input)
        {
            return Calc.Add(input);
        }

        [TestCase("1,2", ExpectedResult = 3)]
        [TestCase("//;\n1;2", ExpectedResult = 3)]
        public int Add_Input1and2_Return3(string input)
        {
            return Calc.Add(input);
        }
        #endregion

        #region Task 2, 3, 7, 8, 9
        [TestCase("1,2,3", ExpectedResult = 6)]
        [TestCase("1\n2,3", ExpectedResult = 6)]
        [TestCase("//[***]\n1***2***3", ExpectedResult = 6)]
        [TestCase("//[*][%]\n1*2%3", ExpectedResult = 6)]
        [TestCase("//[***][%%%]\n1***2%%%3", ExpectedResult = 6)]
        public int Add_Input1and2and3_Return6(string input)
        {
            return Calc.Add(input);
        }
        #endregion

        #region Task 5
        [TestCase("-1")]
        public void Add_InputNegative1_ReturnException(string input)
        {
            Assert.Throws<Exception>(delegate { Calc.Add(input); } );
        }

        [TestCase("-1,-2,-3")]
        public void Add_InputMultipleNegative_ReturnException(string input)
        {
            Assert.Throws<Exception>(delegate { Calc.Add(input); });
        }
        #endregion

        #region Task 6
        [TestCase("1001,2", ExpectedResult = 2)]
        public int Add_Input2and1001_Return2(string input)
        {
            return Calc.Add(input);
        }

        [TestCase("//;\n1001;2", ExpectedResult = 2)]
        public int Add_Input2and1001WithSemicolonDelimiter_Return2(string input)
        {
            return Calc.Add(input);
        }
        #endregion
    }
}