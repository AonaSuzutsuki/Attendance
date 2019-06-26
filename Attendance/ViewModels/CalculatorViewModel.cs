using System;
using System.Windows.Input;
using Attendance.Models;
using KimamaXamarinLib.ViewModels;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;

namespace Attendance.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        public CalculatorViewModel(INavigation nav, CalculatorModel model) : base(nav)
        {
            this.model = model;

            ResultText = model.ToReactivePropertyAsSynchronized(m => m.ResultText);

            ButtonPushed = new Command<CalculatorType>(Button_Pushed);
        }

        private CalculatorModel model;

        public ReactiveProperty<string> ResultText { get; set; }

        public ICommand ButtonPushed { get; set; }

        public void Button_Pushed(CalculatorType arg)
        {
            model.Input(arg);
        }
    }
}
