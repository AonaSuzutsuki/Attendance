﻿using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Denomination.Views.Controls
{
    public class ListButtonViewModel : BindableBase
    {
        ReactiveProperty<int> count = new ReactiveProperty<int>();
        public ReactiveProperty<int> Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }

        ReactiveProperty<string> name = new ReactiveProperty<string>();
        public ReactiveProperty<string> Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        ICommand tappedCommand;
        public ICommand TappedCommand
        {
            get => tappedCommand;
            set => SetProperty(ref tappedCommand, value);
        }

        object commandParameter;
        public object CommandParameter
        {
            get => commandParameter;
            set => SetProperty(ref commandParameter, value);
        }
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListButton : ContentView
    {
        private readonly ListButtonViewModel vm;
        public ListButton ()
		{
			InitializeComponent ();

            vm = new ListButtonViewModel();
            BindingContext = vm;
		}

        private async void TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            await grid.FadeTo(0.5);
            //await Task.Delay(500);
            await grid.FadeTo(1);
        }

        //public static readonly BindableProperty CountProperty = BindableProperty.Create<ListButton, int>(p => p.Count, 0,
        //    propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).Count = newValue);

        public static readonly BindableProperty CountProperty = BindableProperty.Create(
            nameof(Count),
            typeof(int),
            typeof(ListButton),
            0,
            propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).Count = (int)newValue,
            defaultBindingMode: BindingMode.TwoWay
        );

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set
            {
                SetValue(CountProperty, value);
                vm.Count.Value = value;
            }
        }

        //public static readonly BindableProperty NameProperty = BindableProperty.Create<ListButton, string>(p => p.Name, null,
        //    propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).Name = newValue);

        public static readonly BindableProperty NameProperty = BindableProperty.Create(
            nameof(Name),
            typeof(string),
            typeof(ListButton),
            string.Empty,
            propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).Name = (string)newValue,
            defaultBindingMode: BindingMode.TwoWay
        );

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set
            {
                SetValue(NameProperty, value);
                vm.Name.Value = value;
            }
        }

        //public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create<ListButton, ICommand>(p => p.TappedCommand, null,
        //    propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).TappedCommand = newValue);

        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create(
            nameof(Name),
            typeof(ICommand),
            typeof(ListButton),
            null,
            propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).TappedCommand = (ICommand)newValue,
            defaultBindingMode: BindingMode.TwoWay
        );

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set
            {
                SetValue(TappedCommandProperty, value);
                vm.TappedCommand = value;
            }
        }

        //CommandParameter
        //public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<ListButton, object>(p => p.CommandParameter, null,
        //    propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).CommandParameter = newValue);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(Name),
            typeof(object),
            typeof(ListButton),
            null,
            propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).CommandParameter = newValue,
            defaultBindingMode: BindingMode.TwoWay
        );

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set
            {
                SetValue(CommandParameterProperty, value);
                vm.CommandParameter = value;
            }
        }
    }
}
