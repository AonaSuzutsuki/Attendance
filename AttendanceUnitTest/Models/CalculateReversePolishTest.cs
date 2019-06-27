using System;
using System.Collections.Generic;
using System.Numerics;
using Attendance.Models;
using NUnit.Framework;

namespace AttendanceUnitTest.Models
{
    [TestFixture]
    public class CalculateReversePolishTest
    {
        [Test]
        public void CalculateReversePolishTestCase()
        {
            var expression = new List<BigInteger>
            {
                10,
                20,
                30,
                (int)CalculatorType.Mul,
                (int)CalculatorType.Plus,
                40,
                (int)CalculatorType.Minus,
                50,
                (int)CalculatorType.Plus,
            };
            var expressionQueue = new Queue<BigInteger>(expression);

            BigInteger exp = 620;
            var act = expressionQueue.Calculate();

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void CalculateReversePolishTestCase2()
        {
            var expression = new List<BigInteger>
            {
                30,
                2,
                (int)CalculatorType.Div,
            };
            var expressionQueue = new Queue<BigInteger>(expression);

            BigInteger exp = 15;
            var act = expressionQueue.Calculate();

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void CalculateReversePolishTestCase3()
        {
            var expression = new List<BigInteger>
            {
                30,
                2,
                (int)CalculatorType.Div,
                5,
                (int)CalculatorType.Mul,
                3,
                (int)CalculatorType.Div,
            };
            var expressionQueue = new Queue<BigInteger>(expression);

            BigInteger exp = 25;
            var act = expressionQueue.Calculate();

            Assert.AreEqual(exp, act);
        }
    }
}
