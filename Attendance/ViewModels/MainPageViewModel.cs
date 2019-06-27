using System;
using System.Numerics;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using System.Windows.Input;
using Attendance.Models;
using Attendance.Views;
using KimamaXamarinLib.ViewModels;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;

namespace Attendance.ViewModels
{
    public class ButtonInfoViewModel
    {
        public ButtonInfoViewModel(ButtonInfo buttonInfo)
        {
            this.Name = ReactiveProperty.FromObject(buttonInfo, m => m.Name);
            this.Count = buttonInfo.ToReactivePropertyAsSynchronized(m => m.Count);
            this.CommandParameter = buttonInfo.Sender;
        }

        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<int> Count { get; }
        public ButtonInfo CommandParameter { get; }
        public ICommand TappedCommand { get; set; }
    }

    public class MainPageViewModel : ViewModelBase
    {
        private MainPageModel model;

        public MainPageViewModel(INavigation nav, MainPageModel model) : base(nav)
        {
            this.model = model;

            ResultText = model.ToReactivePropertyAsSynchronized(m => m.ResultText);

            this.Data = model.Buttons.ToReadOnlyReactiveCollection(m => new ButtonInfoViewModel(m), Scheduler.CurrentThread);
            this.AssociateCommand(0, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            this.AssociateCommand(1, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            this.AssociateCommand(2, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            this.AssociateCommand(3, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            this.AssociateCommand(4, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            this.AssociateCommand(5, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            this.AssociateCommand(6, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            this.AssociateCommand(7, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            this.AssociateCommand(8, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
        }

        private void AssociateCommand(int index, ICommand cmd)
        {
            if (index < this.Data.Count && index >= 0)
                this.Data[index].TappedCommand = cmd;
        }

        #region Properties
        public ReactiveProperty<string> ResultText { get; set; }
        public ReadOnlyReactiveCollection<ButtonInfoViewModel> Data { get; set; }
        #endregion


        #region Event Methods
        public async Task Information_ClickedAsync(ButtonInfo sender)
        {
            await model.ShowCalulator(nav, sender);
        }
        #endregion
    }
}
