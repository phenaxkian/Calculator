using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass()]
    public class SimpleCalculatorTests
    {
        //These consts are used in tests to check that it isn't Max/Min specifically that's resulting in an error. i.e. error isn't hard checking for max/min as an input.
        private const int ONE_UNDER_INT_MAX = 2147483646;
        private const int ONE_UNDER_INT_MIN = -2147483647;

        private SimpleCalculator _calculator = new SimpleCalculator();

        #region Test "Add"

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(0, 1, 1)]
        [DataRow(1, 1, 2)]
        [DataRow(1, 2, 3)]
        [DataRow(-1, 1, 0)]
        [DataRow(-1, -1, -2)]
        public void AddTest_ReturnsResult(int start, int amount, int expected)
        {
            var result = _calculator.Add(start, amount);
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        [DataRow(int.MaxValue, 1)]
        [DataRow(int.MaxValue, 2)]
        [DataRow(ONE_UNDER_INT_MAX, 10000)]
        [DataRow(int.MinValue, -1)]
        [DataRow(int.MinValue, -2)]
        [DataRow(ONE_UNDER_INT_MIN, -10000)] 
        public void AddTest_LargeValues_ReturnsException(int start, int amount)
        {
            var restult = _calculator.Add(start, amount);
        }
        #endregion

        #region Test "Subtract"

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(1, 0, 1)]
        [DataRow(1, 1, 0)]
        [DataRow(2, 1, 1)]
        [DataRow(3, 2, 1)]
        [DataRow(0, -1, 1)]
        [DataRow(-1, -1, 0)]
        [DataRow(-1, -2, 1)]
        [DataRow(-2, -1, -1)]
        [DataRow(-1, int.MaxValue, int.MinValue)]
        public void SubtractTest_ReturnsResult(int start, int amount, int expected)
        {
            var result = _calculator.Subtract(start, amount);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        [DataRow(int.MinValue, 1)]
        [DataRow(int.MinValue, 2)]
        [DataRow(ONE_UNDER_INT_MIN, 10000)] 
        [DataRow(int.MaxValue, -1)]
        [DataRow(int.MaxValue, -2)]
        [DataRow(ONE_UNDER_INT_MAX, -10000)]
        public void SubtractTest_LargeValues_ReturnsException(int start, int amount)
        {
            var restult = _calculator.Subtract(start, amount);
        }

        #endregion

    }
}