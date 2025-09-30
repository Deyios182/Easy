using EasyPatagonia.Services;
using EasyPatagonia.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyPatagonia
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new SplashPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
