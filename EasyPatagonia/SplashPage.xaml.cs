using EasyPatagonia;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyPatagonia
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        private async void OnMediaEnded(object sender, EventArgs e)
        {
            await this.FadeTo(0, 1000); // Transición de desvanecimiento
            // Navegar a la página principal
            Application.Current.MainPage = new AppShell();
        }
     
    }
}
