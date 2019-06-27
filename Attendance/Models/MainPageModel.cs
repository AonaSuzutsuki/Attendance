using System;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading.Tasks;
using Attendance.Views;
using Prism.Mvvm;
using Xamarin.Forms;

namespace Attendance.Models
{
    public class ButtonInfo : BindableBase
    {
        public string Name { get; set; }
        private int count;
        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }
        public int Price { get; set; }
        public ButtonInfo Sender { get => this; }
    }

    public class MainPageModel : BindableBase
    {
        public MainPageModel()
        {
            Buttons.Add(new ButtonInfo() { Name = "10,000円", Count = 10, Price = 10000 });
            Buttons.Add(new ButtonInfo() { Name = "5,000円", Count = 0, Price = 5000 });
            Buttons.Add(new ButtonInfo() { Name = "1,000円", Count = 0, Price = 1000 });
            Buttons.Add(new ButtonInfo() { Name = "500円", Count = 0, Price = 500 });
            Buttons.Add(new ButtonInfo() { Name = "100円", Count = 0, Price = 100 });
            Buttons.Add(new ButtonInfo() { Name = "50円", Count = 0, Price = 50 });
            Buttons.Add(new ButtonInfo() { Name = "10円", Count = 0, Price = 10 });
            Buttons.Add(new ButtonInfo() { Name = "5円", Count = 0, Price = 5 });
            Buttons.Add(new ButtonInfo() { Name = "1円", Count = 0, Price = 1 });
        }

        private string resultText;
        public string ResultText
        {
            get => resultText;
            set => SetProperty(ref resultText, value);
        }

        private ObservableCollection<ButtonInfo> buttons = new ObservableCollection<ButtonInfo>();
        public ObservableCollection<ButtonInfo> Buttons
        {
            get => buttons;
            set => SetProperty(ref buttons, value);
        }

        public async Task ShowCalulator(INavigation nav, ButtonInfo sender)
        {
            var calc = new Calculator(sender);
            calc.Equaled += Calc_Equaled;
            await nav.PushAsync(calc);
        }

        private void Calc_Equaled(object sender, Calculator.CalculatorEventArgs e)
        {
            e.Sender.Count = (int)e.Integer;
        }
    }
}
