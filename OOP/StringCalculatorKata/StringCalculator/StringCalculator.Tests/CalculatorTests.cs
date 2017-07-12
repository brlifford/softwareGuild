using NUnit.Framework;
using StringCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StringCalculator.Tests
{
    [TestFixture]
    class CalculatorTests
    {
        SCalc _calc = new SCalc();

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("12", 12)]
        [TestCase("1, 2", 3)]
        [TestCase("1, 1, 1", 3)]
        [TestCase("1\n1, 1", 3)]
        [TestCase("//;\n1;1;1", 3)]
        public void TestAdd(string inputString, int expectedOutput)
        {

            int actualOutput = _calc.Add(inputString);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
