using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using System.Linq;
using Attendance.Models.Extentions;
using Attendance.Views;
using Newtonsoft.Json;
using Prism.Mvvm;
using Xamarin.Forms;

namespace Attendance.Models
{
    [JsonObject]
    public class ButtonInfo : BindableBase
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        private int count;
        [JsonProperty("Count")]
        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }
        [JsonProperty("Price")]
        public int Price { get; set; }
        [JsonIgnore]
        public ButtonInfo Sender { get => this; }
    }

    public class MainPageModel : BindableBase
    {
        public MainPageModel()
        {
            Buttons.Add(new ButtonInfo { Name = "10,000円", Count = 0, Price = 10000 });
            Buttons.Add(new ButtonInfo { Name = "5,000円", Count = 0, Price = 5000 });
            Buttons.Add(new ButtonInfo { Name = "1,000円", Count = 0, Price = 1000 });
            Buttons.Add(new ButtonInfo { Name = "500円", Count = 0, Price = 500 });
            Buttons.Add(new ButtonInfo { Name = "100円", Count = 0, Price = 100 });
            Buttons.Add(new ButtonInfo { Name = "50円", Count = 0, Price = 50 });
            Buttons.Add(new ButtonInfo { Name = "10円", Count = 0, Price = 10 });
            Buttons.Add(new ButtonInfo { Name = "5円", Count = 0, Price = 5 });
            Buttons.Add(new ButtonInfo { Name = "1円", Count = 0, Price = 1 });
        }

        private string resultText = "0";
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



        public void Load()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "save.json");
            if (!File.Exists(filename))
                return;
            var json = File.ReadAllText(filename);
            var buttonInfos = JsonConvert.DeserializeObject<ButtonInfo[]>(json);
            var items = buttonInfos.Zip(Buttons, (saveInfo, baseInfo) => new { SaveInfo = saveInfo, BaseInfo = baseInfo });
            foreach (var item in items)
                item.BaseInfo.Count = item.SaveInfo.Count;
            Calculate();
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(Buttons);
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "save.json");
            File.WriteAllText(filename, json);
        }
        public void Calculate()
        {
            BigInteger bigInteger = 0;
            foreach (var elem in Buttons)
            {
                var res = elem.Count * elem.Price;
                bigInteger += res;
            }
            ResultText = bigInteger.ToString();
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
            Calculate();
        }
    }
}
