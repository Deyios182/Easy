using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;
// CORRECCIÓN: Usar el namespace completo del plugin para resolver los errores de 'Plugin' y 'CrossSimpleAudioPlayer'.
using Plugin.SimpleAudioPlayer; 

namespace EasyPatagonia
{
    /*
    IMPORTANTE: PARA QUE ESTO FUNCIONE, DEBES INSTALAR EL PAQUETE NUGET:
    'Xam.Plugins.SimpleAudioPlayer' en todos tus proyectos (PCL/Shared, Android, iOS).
    */
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        // Lista de consejos ecológicos
        private List<string> consejos = new List<string>
        {
            "Lleva tu botella reutilizable y evita plásticos.",
            "No dejes rastro: lleva tu basura contigo.",
            "Respeta la fauna local, observa desde lejos.",
            "Apoya la economía local comprando artesanías.",
            "Mantente siempre en los senderos marcados.",
            "El agua es vida, cuídala en tu viaje.",
            "Usa protector solar biodegradable."
        };

        private bool _isLoading = true;
        private Page _mainPagePreloaded;

        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // ----------------------------------------------------------------------
            // 2. REPRODUCIR SONIDO AL ABRIR
            // El plugin SimpleAudioPlayer puede cargar tanto archivos locales como URLs.
            // ----------------------------------------------------------------------
            // EJEMPLO DE ARCHIVO LOCAL (Recomendado para el inicio)
            ReproducirSonidoDeInicio("app_startup.mp3"); 
            
            // Si quieres usar una URL:
            // ReproducirSonidoDeInicio("https://tuservidor.com/audio/startup_sound.mp3");

            // Iniciar video (si es necesario iniciarlo manualmente)
            if (videoBackground != null)
                videoBackground.Play();

            // Precarga del mapa en segundo plano
            Task.Run(() =>
            {
                try { _mainPagePreloaded = new AppShell(); }
                catch { }
            });

            // Iniciar animaciones visuales en paralelo
            var tareaConsejos = RotarConsejos();
            var tareaProgreso = AnimarProgreso();

            await Task.WhenAll(tareaConsejos, tareaProgreso);

            // Transición final al mapa
            await NavegarAlMapa();
        }

        /// <summary>
        /// Reproduce un audio usando el plugin SimpleAudioPlayer.
        /// Este método es mucho más simple ya que el plugin maneja las dependencias.
        /// </summary>
        /// <param name="source">Nombre del archivo local o URL.</param>
        private void ReproducirSonidoDeInicio(string source)
        {
            try
            {
                // Acceso directo al reproductor
                var audioPlayer = CrossSimpleAudioPlayer.Current;

                // Para archivos locales:
                // Asegúrate de que el archivo esté en 'Assets' (Android) o 'Resources' (iOS).
                // Para URLs:
                // El plugin lo gestiona como streaming.

                if (audioPlayer.IsPlaying) audioPlayer.Stop();
                
                // Load() carga y prepara el audio, funciona con nombres de archivo locales y URLs.
                audioPlayer.Load(source); 
                audioPlayer.Play();
            }
            catch (Exception ex)
            {
                // El plugin fallará si el archivo no existe o la URL no es válida/accesible
                Console.WriteLine($"[Audio Error] No se pudo reproducir el sonido: {ex.Message}");
            }
        }

        private async Task RotarConsejos()
        {
            var random = new Random();
            // Mostrar primer consejo
            if (lblConsejo != null)
                lblConsejo.Text = consejos[random.Next(consejos.Count)];

            while (_isLoading)
            {
                await Task.Delay(3000); // Cambiar consejo cada 3 segundos
                if (!_isLoading) break;

                if (lblConsejo != null)
                {
                    // Efecto de desvanecimiento para cambiar el texto suavemente
                    await lblConsejo.FadeTo(0, 250);
                    lblConsejo.Text = consejos[random.Next(consejos.Count)];
                    await lblConsejo.FadeTo(1, 250);
                }
            }
        }

        private async Task AnimarProgreso()
        {
            uint duracionCarga = 6000; // Duración total de la "carga" (6 segundos)
            if (progressBar != null)
                await progressBar.ProgressTo(1.0, duracionCarga, Easing.Linear);

            _isLoading = false; // Detener rotación de consejos
        }

        private async Task NavegarAlMapa()
        {
            // Asegurar que la precarga del mapa haya terminado
            while (_mainPagePreloaded == null) await Task.Delay(100);

            // Transición suave (Fade Out)
            await this.FadeTo(0, 500, Easing.SinOut);

            // Cambiar a la página principal
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = _mainPagePreloaded;
            });
        }
    }
}