using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            this.Name = buttonInfo.Name;
            Count = buttonInfo.ObserveProperty(m => m.Count).ToReactiveProperty();
            //this.Count = buttonInfo.ToReactivePropertyAsSynchronized(m => m.Count);
            this.CommandParameter = buttonInfo.Sender;
        }

        public string Name { get; }
        public ReactiveProperty<int> Count { get; }
        public ButtonInfo CommandParameter { get; }
        public ICommand TappedCommand { get; set; }
    }

    public class MainPageViewModel : ViewModelBase
    {
        private readonly MainPageModel model;

        public MainPageViewModel(INavigation nav, MainPageModel model) : base(nav)
        {
            this.model = model;

            ResultText = model.ToReactivePropertyAsSynchronized(m => m.ResultText);

            NewBtClicked = new Command(NewBt_Clicked);

            Data = model.Buttons.ToReadOnlyReactiveCollection(m => new ButtonInfoViewModel(m), Scheduler.CurrentThread);
            foreach (var item in Data.Select((v, i) => new { Index = i, Value = v }))
            {
                AssociateCommand(item.Value, item.Index, CreateAsyncReactiveCommand<ButtonInfo>(async (info) => await Information_ClickedAsync(info)));
            }
            //this.AssociateCommand(0, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            //this.AssociateCommand(1, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            //this.AssociateCommand(2, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            //this.AssociateCommand(3, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            //this.AssociateCommand(4, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            //this.AssociateCommand(5, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            //this.AssociateCommand(6, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            //this.AssociateCommand(7, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
            //this.AssociateCommand(8, CreateAsyncReactiveCommand<ButtonInfo>(async (price) => await Information_ClickedAsync(price)));
        }

        private static void AssociateCommand(ButtonInfoViewModel buttonInfoViewModel, int index, ICommand cmd)
        {
            //if (index < enumerable.Count && index >= 0)
            buttonInfoViewModel.TappedCommand = cmd;
        }

        #region Properties
        public ReactiveProperty<string> ResultText { get; set; }
        public ReadOnlyReactiveCollection<ButtonInfoViewModel> Data { get; set; }
        #endregion

        #region Event Properties
        public ICommand NewBtClicked { get; set; }
        #endregion


        #region Event Methods
        public void NewBt_Clicked()
        {
            model.NewData();
        }

        public async Task Information_ClickedAsync(ButtonInfo sender)
        {
            await model.ShowCalulator(nav, sender);
        }
        #endregion

        public void Load()
        {
            model.Load();
        }

        public void Save()
        {
            model.Save();
        }
    }
}
