using System;
using Attendance.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attendance
{
    public partial class App : Application
    {
        private readonly MainPage page;

        public App()
        {
            page = new MainPage();

            InitializeComponent();

            MainPage = new NavigationPage(page);
            var navigationPage = Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Black;
            navigationPage.BarTextColor = Color.White;
        }

        protected override void OnStart()
        {
            page.Load();
        }

        protected override void OnSleep()
        {
            page.Save();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
