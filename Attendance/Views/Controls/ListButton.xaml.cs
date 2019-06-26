using Prism.Mvvm;
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
        ReactiveProperty<ImageSource> image = new ReactiveProperty<ImageSource>();
        public ReactiveProperty<ImageSource> Image
        {
            get => image;
            set => SetProperty(ref image, value);
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
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListButton : ContentView
    {
        ListButtonViewModel vm;
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

        [Obsolete]
        public static readonly BindableProperty ImageProperty = BindableProperty.Create<ListButton, ImageSource>(p => p.Image, null,
            propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).Image = newValue);

        [Obsolete]
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set
            {
                SetValue(ImageProperty, value);
                vm.Image.Value = value;
            }
        }

        [Obsolete]
        public static readonly BindableProperty NameProperty = BindableProperty.Create<ListButton, string>(p => p.Name, null,
            propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).Name = newValue);

        [Obsolete]
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set
            {
                SetValue(NameProperty, value);
                vm.Name.Value = value;
            }
        }

        [Obsolete]
        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create<ListButton, ICommand>(p => p.TappedCommand, null,
            propertyChanged: (bindable, oldValue, newValue) => ((ListButton)bindable).TappedCommand = newValue);

        [Obsolete]
        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set
            {
                SetValue(TappedCommandProperty, value);
                vm.TappedCommand = value;
            }
        }
    }
}
