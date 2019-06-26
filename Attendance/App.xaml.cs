using System;
using Attendance.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attendance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            var navigationPage = Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Black;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
