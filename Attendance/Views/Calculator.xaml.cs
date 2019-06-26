using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Attendance.Views
{
    public partial class Calculator : ContentPage
    {
        public Calculator()
        {
            InitializeComponent();

            var model = new Models.CalculatorModel();
            var vm = new ViewModels.CalculatorViewModel(Navigation, model);
            BindingContext = vm;
        }
    }
}
