using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Attendance.Models;
using NUnit.Framework;

namespace AttendanceUnitTest.Models
{
    [TestFixture]
    public class ReversePolandTest
    {
        [Test]
        public void ReversePolandTestCase()
        {
            var list = new List<BigInteger>
            {
                10,
                (int)CalculatorType.Plus,
                20,
                (int)CalculatorType.Mul,
                30,
                (int)CalculatorType.Minus,
                40,
                (int)CalculatorType.Plus,
                50
            };

            var expList = new List<BigInteger>
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
            var exp = new Queue<BigInteger>(expList);

            var act = list.ConvertReversePolish();

            CollectionAssert.AreEqual(exp, act);

            //var sb = new StringBuilder();
            //foreach (var elem in stack)
            //{
            //    var type = elem.ToCalculatorType();
            //    if (type != CalculatorType.Unknown)
            //    {
            //        sb.Append(type);
            //    }
            //    else
            //    {
            //        sb.Append(elem);
            //    }
            //}
            //Console.WriteLine(sb);
        }

        [Test]
        public void ReversePolandTestCase2()
        {
            var list = new List<BigInteger>
            {
                1,
                (int)CalculatorType.Plus,
                2,
                (int)CalculatorType.Mul,
                3,
                (int)CalculatorType.Mul,
                4,
                (int)CalculatorType.Plus,
                5,
                (int)CalculatorType.Div,
                6,
                (int)CalculatorType.Minus,
                7,
                (int)CalculatorType.Mul,
                8,
                (int)CalculatorType.Div,
                9
            };
            var expList = new List<BigInteger>
            {
                1,
                2,
                3,
                (int)CalculatorType.Mul,
                4,
                (int)CalculatorType.Mul,
                (int)CalculatorType.Plus,
                5,
                6,
                (int)CalculatorType.Div,
                (int)CalculatorType.Plus,
                7,
                8,
                (int)CalculatorType.Mul,
                9,
                (int)CalculatorType.Div,
                (int)CalculatorType.Minus
            };

            var exp = new Queue<BigInteger>(expList);
            var act = list.ConvertReversePolish();

            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        public void ReversePolandTestCase3()
        {
            var list = new List<BigInteger>
            {
                1,
                (int)CalculatorType.Plus,
                2,
                (int)CalculatorType.Mul,
                3,
                (int)CalculatorType.Mul,
                4,
                (int)CalculatorType.Plus,
                5
            };
            var expList = new List<BigInteger>
            {
                1,
                2,
                3,
                (int)CalculatorType.Mul,
                4,
                (int)CalculatorType.Mul,
                (int)CalculatorType.Plus,
                5,
                (int)CalculatorType.Plus
            };

            var exp = new Queue<BigInteger>(expList);
            var act = list.ConvertReversePolish();

            CollectionAssert.AreEqual(exp, act);
        }

        //[Test]
        //public void ReversePolandTestCase()
        //{
        //    var text = "10 + 20 * 30 - 40 + 50";
        //    var exp = "102030*+40-50+";
        //    var act = ReversePoland.Test(text);

        //    Assert.AreEqual(exp, act);
        //}

        //[Test]
        //public void ReversePolandTestCase2()
        //{
        //    var text = "1 + 2 * 3 * 4 + 5 / 6 - 7 * 8 / 9";
        //    var exp = "123*4*+56/+78*9/-";
        //    var act = ReversePoland.Test(text);

        //    Assert.AreEqual(exp, act);
        //}

        //[Test]
        //public void ReversePolandTestCase3()
        //{
        //    var text = "1 + 2 * 3 * 4 + 5";
        //    var exp = "123*4*+5+";
        //    var act = ReversePoland.Test(text);

        //    Assert.AreEqual(exp, act);
        //}
    }
}
