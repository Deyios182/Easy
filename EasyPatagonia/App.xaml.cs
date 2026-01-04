using EasyPatagonia.Services;
using EasyPatagonia.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace EasyPatagonia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new SplashPage();
        }
        protected override void OnStart()
        {
            Task.Run(async () => {
                try {
                    await DatosService.InicializarAsync();
                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            });
        }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
