using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyPatagonia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialPage : ContentPage
    {
        public SocialPage()
        {
            InitializeComponent();
        }

        private async void OnFacebookClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://www.facebook.com/Easy.Patagonia");
        }

        private async void OnInstagramClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://www.instagram.com/easy.patagonia");
        }

        private async void OnWhatsAppClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://wa.me/56956425005");
        }

        private async void OnTikTokClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://www.tiktok.com/@easy.patagonia?_t=ZM-8srRmTRFV1q&_r=1"); // Reemplaza este enlace por el de tu cuenta
        }
    }
}
