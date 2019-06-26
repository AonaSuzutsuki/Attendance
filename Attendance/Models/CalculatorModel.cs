using System;
using System.Collections.Generic;
using Prism.Mvvm;

namespace Attendance.Models
{
    public enum CalculatorType
    {
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
        _9
    }

    public class CalculatorModel : BindableBase
    {

        private List<CalculatorType> inputs = new List<CalculatorType>();

        private string resultText;

        public string ResultText
        {
            get => resultText;
            set => SetProperty(ref resultText, value);
        }

        public void Input(CalculatorType calculatorType)
        {
            if (calculatorType == CalculatorType.AC)
                inputs = new List<CalculatorType>();
            inputs.Add(calculatorType);
        }
    }
}
