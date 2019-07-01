using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Attendance.Models.Extentions
{
    public static class StringExtention
    {
        public static string ToFormattedString(this BigInteger bigInteger)
        {
            var text = bigInteger.ToString().Reverse();
            var cArray = new List<char>();
            foreach (var item in text.Select((v, i) => new { Index = i, Value = v }))
            {
                if (item.Index > 0 && item.Index % 3 == 0)
                    cArray.Add(',');
                cArray.Add(item.Value);
            }
            return new string(((IEnumerable<char>)cArray).Reverse().ToArray());
        }
    }
}
