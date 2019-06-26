using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Attendance.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var model = new Models.MainPageModel();
            var vm = new ViewModels.MainPageViewModel(Navigation, model);
            BindingContext = vm;
        }
    }
}
