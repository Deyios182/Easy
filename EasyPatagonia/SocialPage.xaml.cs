using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic; // Necesario para List<string>

namespace EasyPatagonia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialPage : ContentPage
    {
        // Correo al que se enviará la consulta
        private const string EmailContacto = "infoeasypatagonia@gmail.com";

        public SocialPage()
        {
            InitializeComponent();
        }

        private async void OnInstagramClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://www.instagram.com/easy.patagonia");
        }

        private async void OnEasyClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://easypatagonia.com/");
        }
        private async void OnTikTokClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://www.tiktok.com/@easy.patagonia?_t=ZM-8srRmTRFV1q&_r=1");
        }

        private async void OnWhatsAppClicked(object sender, EventArgs e)
        {
            string telefono = "56956425005";
            string mensaje = "¡Hola! Escribo desde la app EasyPatagonia. Tengo una consulta sobre su plataforma o alianzas.";

            try
            {
                await Launcher.OpenAsync(new Uri($"whatsapp://send?phone={telefono}&text={Uri.EscapeDataString(mensaje)}"));
            }
            catch
            {
                await Launcher.OpenAsync(new Uri($"https://wa.me/{telefono}?text={Uri.EscapeDataString(mensaje)}"));
            }
        }

        // --- FUNCIÓN CORREGIDA CON LÓGICA DE FALLBACK (TU SOLUCIÓN) ---
        private async void OnEmailClicked(object sender, EventArgs e)
        {
            // Mensaje que queremos precargar
            string subject = "Consulta desde EasyPatagonia App";
            string body = "Estimado equipo EasyPatagonia,\n\nEscribo con respecto a...";

            // 1. Intentar abrir la aplicación de correo nativa (mailto:)
            try
            {
                // Usamos mailto: con URL Encoding para precargar Asunto y Cuerpo
                string uri = $"mailto:{EmailContacto}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";

                await Launcher.OpenAsync(uri);
            }
            catch (Exception)
            {
                // 2. Si el mailto: falla (porque no hay aplicación nativa configurada),
                // abrimos la versión web de Gmail como fallback.
                try
                {
                    // Usamos la URL de composición de Gmail con parámetros
                    string gmailUrl = $"https://mail.google.com/mail/?view=cm&fs=1&to={EmailContacto}&su={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
                    await Launcher.OpenAsync(gmailUrl);
                }
                catch
                {
                    await DisplayAlert("Error", "No se encontró una aplicación de correo ni acceso a Gmail. Copia el email: " + EmailContacto, "OK");
                }
            }
        }
    }
}