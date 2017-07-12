using Factorizor.BLL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.Tests
{
    [TestFixture]
    public class MathTests
    {
        PerfectChecker _perfect = new PerfectChecker();

        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(28, true)]
        public void isPerfectNumber(int input, bool expectedOutput)
        {
            bool actualOutput = PerfectChecker.IsPerfectNumber(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        PrimeChecker _prime = new PrimeChecker();

        [TestCase(2, true)]
        [TestCase(4, false)]
        [TestCase(7, false)]
        public void isPrimeNumber(int input, bool expectedOutput)
        {
            bool actualOutput = PrimeChecker.IsPrimeNumber(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        FactorFinder _factors = new FactorFinder();

        [TestCase(3, new int[] { 0, 1, 0, 3 }, TestName = "TestArray 1")]
        [TestCase(4, new int[] { 0, 1, 2, 0, 4 }, TestName = "TestArray 2")]
        [TestCase(6, new int[] { 0, 1, 2, 3, 0, 0, 6}, TestName = "TestArray 3")]

        public void findFactors(int input, int[] expectedOutput)
        {
            int[] actualOutput = _factors.FindFactors(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
