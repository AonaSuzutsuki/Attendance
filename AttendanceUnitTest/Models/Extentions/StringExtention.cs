using System;
using Attendance.Models.Extentions;
using System.Numerics;
using NUnit.Framework;

namespace AttendanceUnitTest.Models.Extentions
{
    [TestFixture]
    public class StringExtention
    {
        [Test]
        public void ToFormattedStringTest()
        {
            BigInteger integer = 1234567890;
            var exp = "1,234,567,890";
            var act = integer.ToFormattedString();

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void ToFormattedStringTest2()
        {
            BigInteger integer = 123456789;
            var exp = "123,456,789";
            var act = integer.ToFormattedString();

            Assert.AreEqual(exp, act);
        }
    }
}
