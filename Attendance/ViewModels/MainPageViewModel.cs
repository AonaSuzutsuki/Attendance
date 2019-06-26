using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Attendance.Models;
using Attendance.Views;
using KimamaXamarinLib.ViewModels;
using Prism.Mvvm;
using Reactive.Bindings;
using Xamarin.Forms;

namespace Attendance.ViewModels
{
    public class ButtonInfoViewModel
    {
        public ButtonInfoViewModel(ButtonInfo buttonInfo)
        {
            this.Name = ReactiveProperty.FromObject(buttonInfo, m => m.Name);
            this.Image = ReactiveProperty.FromObject(buttonInfo, m => m.Image);
        }

        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<ImageSource> Image { get; }
        public ICommand TappedCommand { get; set; }
    }

    public class MainPageViewModel : ViewModelBase
    {
        private MainPageModel model;

        public MainPageViewModel(INavigation nav, MainPageModel model) : base(nav)
        {
            this.model = model;

            this.Data = model.Buttons.ToReadOnlyReactiveCollection(m => new ButtonInfoViewModel(m));
            this.AssociateCommand(0, CreateAsyncReactiveCommand(async () => await Information_ClickedAsync()));
            this.AssociateCommand(1, CreateAsyncReactiveCommand(async () => await Information_ClickedAsync()));
            this.AssociateCommand(2, CreateAsyncReactiveCommand(async () => await Information_ClickedAsync()));
            this.AssociateCommand(3, CreateAsyncReactiveCommand(async () => await Information_ClickedAsync()));
            this.AssociateCommand(4, CreateAsyncReactiveCommand(async () => await Information_ClickedAsync()));
        }

        private void AssociateCommand(int index, ICommand cmd)
        {
            if (index < this.Data.Count && index >= 0)
                this.Data[index].TappedCommand = cmd;
        }

        #region Properties
        public ReadOnlyReactiveCollection<ButtonInfoViewModel> Data { get; set; }
        #endregion


        #region Event Methods
        public async Task Information_ClickedAsync()
        {
            await nav.PushAsync(new Calculator());
        }
        #endregion
    }
}
