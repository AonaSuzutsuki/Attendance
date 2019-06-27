using System;
using System.Collections.Generic;
using System.Numerics;
using Attendance.Models;
using Xamarin.Forms;

namespace Attendance.Views
{
    public partial class Calculator : ContentPage
    {
        public Calculator(ButtonInfo sender)
        {
            InitializeComponent();

            var model = new Models.CalculatorModel(sender.Count)
            {
                SetReturnResult = (integer) =>
                {
                    OnEqualed(new CalculatorEventArgs { Sender = sender, Integer = integer });
                }
            };
            var vm = new ViewModels.CalculatorViewModel(Navigation, model);
            BindingContext = vm;
        }

        #region ReadedEvent
        public class CalculatorEventArgs : EventArgs
        {
            public ButtonInfo Sender;
            public BigInteger Integer;
        }
        public delegate void CalculatorEqualEventHandler(object sender, CalculatorEventArgs e);
        public event CalculatorEqualEventHandler Equaled;
        private void OnEqualed(CalculatorEventArgs e)
        {
            Equaled?.Invoke(this, e);
        }
        #endregion
    }
}
