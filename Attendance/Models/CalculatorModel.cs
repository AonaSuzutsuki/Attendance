using System;
using System.Collections.Generic;
using System.Numerics;
using Prism.Mvvm;

namespace Attendance.Models
{
    public enum CalculatorType
    {
        Unknown = -99,
        AC,
        Equal,
        Plus,
        Minus,
        Mul,
        Div,
        _0,
        _1,
        _2,
        _3,
        _4,
        _5,
        _6,
        _7,
        _8,
        _9,
    }

    public static class CalculatorTypeExtention
    {
        public static bool IsNum(this CalculatorType calculatorType)
        {
            return (int)calculatorType >= (int)CalculatorType._0 && (int)calculatorType <= (int)CalculatorType._9;
        }

        public static int ToInt(this CalculatorType calculatorType)
        {
            if (calculatorType.IsNum())
                return (int)calculatorType - (int)CalculatorType._0;
            return 0;
        }

        public static CalculatorType ToCalculatorType(this BigInteger bigInteger)
        {
            if (bigInteger >= (int)CalculatorType.AC && bigInteger <= (int)CalculatorType._9)
                return (CalculatorType)((int)bigInteger);
            return CalculatorType.Unknown;
        }
    }

    public class CalculatorModel : BindableBase
    {
        private List<BigInteger> inputs = new List<BigInteger>();

        private string resultText;

        public string ResultText
        {
            get => resultText;
            set => SetProperty(ref resultText, value);
        }

        private BigInteger resultInteger = 0;
        public BigInteger ResultInteger
        {
            get => resultInteger;
            set
            {
                resultInteger = value;
                ResultText = resultInteger.ToString();
            }
        }

        public Action<BigInteger> SetReturnResult { get; set; }


        public CalculatorModel() { ResultInteger = 0; }
        public CalculatorModel(BigInteger integer)
        {
            ResultInteger = integer;
            inputs.Add(integer);
        }

        public void Input(CalculatorType calculatorType)
        {
            if (calculatorType == CalculatorType.AC)
            {
                inputs = new List<BigInteger>();
                ResultInteger = 0;
                return;
            }
            else if (calculatorType == CalculatorType.Equal)
            {
                inputs.Add(ResultInteger);
                Calculate();
                return;
            }

            if (calculatorType.IsNum())
            {
                ResultInteger = (ResultInteger * 10) + calculatorType.ToInt();
                SetReturnResult(ResultInteger);
            }
            else
            {
                inputs.Add(ResultInteger);
                inputs.Add(new BigInteger((int)calculatorType));
                ResultInteger = 0;
            }
        }

        public void Calculate()
        {
            var repolish = inputs.ConvertReversePolish();
            ResultInteger = repolish.Calculate();
            inputs = new List<BigInteger> { ResultInteger };
            SetReturnResult(ResultInteger);
        }
    }
}
