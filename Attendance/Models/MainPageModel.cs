using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Xamarin.Forms;

namespace Attendance.Models
{
    public class ButtonInfo
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
    }

    public class MainPageModel : BindableBase
    {
        public MainPageModel()
        {
            Buttons.Add(new ButtonInfo() { Name = "10,000", Image = ImageSource.FromFile("Top/top-icon-news") });
            Buttons.Add(new ButtonInfo() { Name = "5,000", Image = ImageSource.FromFile("Top/top-icon-class") });
            Buttons.Add(new ButtonInfo() { Name = "1,000", Image = ImageSource.FromFile("Top/top-icon-class") });
            Buttons.Add(new ButtonInfo() { Name = "500", Image = ImageSource.FromFile("Top/top-icon-calendar") });
            Buttons.Add(new ButtonInfo() { Name = "100", Image = ImageSource.FromFile("Top/top-icon-setting") });
            Buttons.Add(new ButtonInfo() { Name = "50", Image = ImageSource.FromFile("Top/top-icon-setting") });
            Buttons.Add(new ButtonInfo() { Name = "10", Image = ImageSource.FromFile("Top/top-icon-setting") });
            Buttons.Add(new ButtonInfo() { Name = "5", Image = ImageSource.FromFile("Top/top-icon-setting") });
            Buttons.Add(new ButtonInfo() { Name = "1", Image = ImageSource.FromFile("Top/top-icon-setting") });
        }

        private ObservableCollection<ButtonInfo> buttons = new ObservableCollection<ButtonInfo>();
        public ObservableCollection<ButtonInfo> Buttons
        {
            get => buttons;
            set => SetProperty(ref buttons, value);
        }
    }
}
