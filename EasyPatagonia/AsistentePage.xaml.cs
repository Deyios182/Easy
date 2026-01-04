using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EasyPatagonia.Services;
using EasyPatagonia.Models;
using Xamarin.Essentials;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EasyPatagonia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsistentePage : ContentPage
    {
        private ItinerarioSugerido _itinerarioActual;

        public AsistentePage()
        {
            InitializeComponent();
        }

        private async void OnGenerarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPresupuesto.Text) || string.IsNullOrEmpty(txtDias.Text) || string.IsNullOrEmpty(txtPersonas.Text))
            {
                await DisplayAlert("Faltan datos", "Por favor completa todos los campos.", "OK");
                return;
            }

            if (!decimal.TryParse(txtPresupuesto.Text, out decimal presupuesto) ||
                !int.TryParse(txtDias.Text, out int dias) ||
                !int.TryParse(txtPersonas.Text, out int personas))
            {
                await DisplayAlert("Error", "Ingresa solo números válidos.", "OK");
                return;
            }

            bool incAct = chkActividades.IsChecked;
            bool incCom = chkComidas.IsChecked;
            bool incAloj = chkAlojamiento.IsChecked;

            if (!incAct && !incCom && !incAloj)
            {
                await DisplayAlert("Error", "Selecciona al menos una opción (Tours, Comidas o Hotel).", "OK");
                return;
            }

            _itinerarioActual = RecomendadorService.GenerarItinerario(presupuesto, dias, personas, incAct, incCom, incAloj);

            resultLayout.IsVisible = true;
            botonesExportar.IsVisible = true;

            lblMensajeIA.Text = _itinerarioActual.MensajeIA;
            lblCostoTotal.Text = $"Costo Total Estimado: ${_itinerarioActual.CostoTotal:N0}";

            listaDias.Children.Clear();

            foreach (var dia in _itinerarioActual.Dias)
            {
                var frameDia = new Frame { CornerRadius = 10, HasShadow = true, Padding = 12, BackgroundColor = Color.White };
                var stackDia = new StackLayout { Spacing = 5 };

                stackDia.Children.Add(new Label { Text = $"Día {dia.DiaNumero}", FontSize = 16, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#34495E") });

                if (dia.Alojamiento != null)
                    stackDia.Children.Add(CrearItemResumen("🛏️ Alojamiento:", dia.Alojamiento.Nombre));

                if (dia.Actividad != null)
                    stackDia.Children.Add(CrearItemResumen("🚣 Actividad:", dia.Actividad.Nombre));

                if (dia.Comida != null)
                    stackDia.Children.Add(CrearItemResumen("🍽️ Comer en:", dia.Comida.Nombre));

                stackDia.Children.Add(new BoxView { HeightRequest = 1, Color = Color.LightGray, Margin = new Thickness(0, 5) });
                stackDia.Children.Add(new Label { Text = $"Costo aprox: ${dia.CostoDia:N0}", FontSize = 12, TextColor = Color.Gray, HorizontalOptions = LayoutOptions.End });

                frameDia.Content = stackDia;
                listaDias.Children.Add(frameDia);
            }
        }

        private StackLayout CrearItemResumen(string titulo, string valor)
        {
            var stack = new StackLayout { Orientation = StackOrientation.Horizontal };
            stack.Children.Add(new Label { Text = titulo, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, FontSize = 13 });
            stack.Children.Add(new Label { Text = valor, TextColor = Color.FromHex("#E74C3C"), FontSize = 13, LineBreakMode = LineBreakMode.TailTruncation });
            return stack;
        }

        // --- CORRECCIÓN: GUARDAR IMAGEN DE MANERA SEGURA ---
        private async void OnGuardarImagenClicked(object sender, EventArgs e)
        {
            if (_itinerarioActual == null) return;

            try
            {
                // Generamos un reporte de texto detallado
                var sb = new StringBuilder();
                sb.AppendLine("====================================");
                sb.AppendLine("   ITINERARIO EASY PATAGONIA");
                sb.AppendLine("====================================");
                sb.AppendLine($"Costo Total Est: ${_itinerarioActual.CostoTotal:N0}");
                sb.AppendLine($"Plan para {_itinerarioActual.Dias.Count} días.");
                sb.AppendLine("");

                foreach (var dia in _itinerarioActual.Dias)
                {
                    sb.AppendLine($"--- DÍA {dia.DiaNumero} ---");
                    if (dia.Alojamiento != null) sb.AppendLine($"[Hospedaje] {dia.Alojamiento.Nombre}");
                    if (dia.Actividad != null) sb.AppendLine($"[Actividad] {dia.Actividad.Nombre}");
                    if (dia.Comida != null) sb.AppendLine($"[Comida] {dia.Comida.Nombre}");
                    sb.AppendLine($"Costo día: ${dia.CostoDia:N0}");
                    sb.AppendLine("");
                }

                sb.AppendLine("Generado por EasyPatagonia App.");

                // Guardamos como archivo .txt en el caché
                var fn = "Plan_EasyPatagonia.txt";
                var file = Path.Combine(FileSystem.CacheDirectory, fn);
                File.WriteAllText(file, sb.ToString());

                // Compartimos el archivo (El usuario puede guardarlo en Drive, enviarlo por correo, etc.)
                await Share.RequestAsync(new ShareFileRequest
                {
                    Title = "Mi Plan de Viaje",
                    File = new ShareFile(file)
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo exportar el plan: " + ex.Message, "OK");
            }
        }

        private async void OnCompartirClicked(object sender, EventArgs e)
        {
            if (_itinerarioActual == null) return;

            var sb = new StringBuilder();
            sb.AppendLine("🏔️ Mi Plan EasyPatagonia 🏔️");
            sb.AppendLine($"Total Est: ${_itinerarioActual.CostoTotal:N0}");
            sb.AppendLine("--------------------------------");

            foreach (var dia in _itinerarioActual.Dias)
            {
                sb.AppendLine($"📅 DÍA {dia.DiaNumero}:");
                if (dia.Alojamiento != null) sb.AppendLine($"- Alojamiento: {dia.Alojamiento.Nombre}");
                if (dia.Actividad != null) sb.AppendLine($"- Actividad: {dia.Actividad.Nombre}");
                if (dia.Comida != null) sb.AppendLine($"- Comida: {dia.Comida.Nombre}");
                sb.AppendLine("");
            }
            sb.AppendLine("Generado por la App EasyPatagonia 📲");

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = sb.ToString(),
                Title = "Compartir mi viaje"
            });
        }

        private async void OnWhatsAppClicked(object sender, EventArgs e)
        {
            string telefono = "+56956425005";
            string mensaje = "¡Hola! Estaba usando el Asistente IA pero necesito ayuda humana para mi viaje.";
            try { await Launcher.OpenAsync(new Uri($"whatsapp://send?phone={telefono}&text={Uri.EscapeDataString(mensaje)}")); }
            catch { await Launcher.OpenAsync(new Uri($"https://wa.me/{telefono}?text={Uri.EscapeDataString(mensaje)}")); }
        }
    }
}