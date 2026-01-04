using Xamarin.Forms;
using Xamarin.Essentials;
using System;
using System.Linq;
using System.Threading.Tasks;
using EasyPatagonia.Models;

namespace EasyPatagonia
{
    public partial class EmpresaDetallePage : ContentPage
    {
        private Empresa _empresa;

        public EmpresaDetallePage(Empresa empresa)
        {
            InitializeComponent();
            _empresa = empresa;
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (_empresa == null) return;

            // 1. Llenar textos básicos
            lblNombre.Text = _empresa.Nombre;
            lblDireccion.Text = _empresa.Direccion;
            lblDescripcion.Text = _empresa.Descripcion;
            imgLogo.Source = _empresa.Logo;

            // 2. Configurar el Carrusel Superior
            if (_empresa.Imagenes != null && _empresa.Imagenes.Count > 0)
            {
                carruselEmpresa.ItemsSource = _empresa.Imagenes;
            }
            else
            {
                // Si no hay fotos de galería, mostramos el logo en grande para que no quede vacío
                carruselEmpresa.ItemsSource = new[] { _empresa.Logo };
            }

            // 3. Llenar la Lista de Servicios (Carta)
            listaServicios.Children.Clear();

            foreach (var act in _empresa.Actividades)
            {
                // Marco de la tarjeta
                var frame = new Frame { Padding = 0, CornerRadius = 10, BackgroundColor = Color.White, HasShadow = true };
                var stackPrincipal = new StackLayout { Spacing = 0 };

                // A. FOTO DEL SERVICIO (Si tiene)
                if (act.Imagenes != null && act.Imagenes.Count > 0)
                {
                    var imgServicio = new Image
                    {
                        Source = act.Imagenes[0],
                        HeightRequest = 180,
                        Aspect = Aspect.AspectFill,
                        BackgroundColor = Color.LightGray
                    };

                    // Gesto para hacer ZOOM en la foto
                    var tapZoom = new TapGestureRecognizer();
                    tapZoom.Tapped += async (s, e) => await AbrirImagenFullScreen(act.Imagenes[0]);
                    imgServicio.GestureRecognizers.Add(tapZoom);

                    stackPrincipal.Children.Add(imgServicio);
                }

                // B. TEXTOS DEL SERVICIO
                var stackInfo = new StackLayout { Padding = 15 };
                stackInfo.Children.Add(new Label { Text = act.Nombre, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Color.Black });
                stackInfo.Children.Add(new Label { Text = act.Precio, TextColor = Color.FromHex("#E74C3C"), FontAttributes = FontAttributes.Bold, FontSize = 15 });
                stackInfo.Children.Add(new Label { Text = act.Descripcion, FontSize = 13, TextColor = Color.Gray });

                // Texto de "Consultar"
                var lblConsultar = new Label
                {
                    Text = "💬 Consultar disponibilidad",
                    FontSize = 12,
                    TextColor = Color.FromHex("#25D366"),
                    FontAttributes = FontAttributes.Italic,
                    HorizontalOptions = LayoutOptions.End,
                    Margin = new Thickness(0, 5, 0, 0)
                };
                stackInfo.Children.Add(lblConsultar);

                stackPrincipal.Children.Add(stackInfo);
                frame.Content = stackPrincipal;

                // Gesto para CONTACTAR al tocar la info
                var tapContact = new TapGestureRecognizer();
                tapContact.Tapped += async (s, e) => await ContactarPorServicio(act);
                stackInfo.GestureRecognizers.Add(tapContact);

                listaServicios.Children.Add(frame);
            }
        }

        // --- ABRIR IMAGEN EN PANTALLA COMPLETA (MODAL NEGRO) ---
        private async Task AbrirImagenFullScreen(string urlImagen)
        {
            var page = new ContentPage { BackgroundColor = Color.Black };

            // Imagen centrada
            var img = new Image
            {
                Source = urlImagen,
                Aspect = Aspect.AspectFit,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            // Botón Cerrar
            var closeBtn = new Button
            {
                Text = "Cerrar",
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = 20
            };
            closeBtn.Clicked += async (s, e) => await Navigation.PopModalAsync();

            var grid = new Grid();
            grid.Children.Add(img);
            grid.Children.Add(closeBtn);

            page.Content = grid;
            await Navigation.PushModalAsync(page);
        }

        // --- CONTACTAR POR UN SERVICIO ESPECÍFICO ---
        private async Task ContactarPorServicio(Actividad actividad)
        {
            try
            {
                string texto = $"¡Hola {_empresa.Nombre}! Escribo desde EasyPatagonia. Estoy muy interesado/a en el servicio: *{actividad.Nombre}* ({actividad.Precio}). ¿Podrían confirmarme la disponibilidad o darme más detalles? ¡Gracias!";
                await Launcher.OpenAsync(new Uri($"https://wa.me/{_empresa.NumeroWhatsApp}?text={Uri.EscapeDataString(texto)}"));
            }
            catch { await DisplayAlert("Error", "No se pudo abrir WhatsApp", "OK"); }
        }

        // --- BOTÓN VER EN MAPA ---
        private async void OnVerEnMapaClicked(object sender, EventArgs e)
        {
            var mapPage = new MapPage();
            // Llama al método SetLocation en MapPage
            mapPage.SetLocation(_empresa.Latitud, _empresa.Longitud, _empresa.Nombre);
            await Navigation.PushAsync(mapPage);
        }

        // --- BOTÓN WHATSAPP GENERAL ---
        private async void OnWhatsAppClicked(object sender, EventArgs e)
        {
            try
            {
                string msg = Uri.EscapeDataString($"¡Hola! Vengo desde EasyPatagonia. Estoy viendo su perfil {_empresa.Nombre} y me gustaría saber si tienen disponibilidad o si puedo hacer una reserva. ¡Gracias!");
                await Launcher.OpenAsync(new Uri($"https://wa.me/{_empresa.NumeroWhatsApp}?text={msg}"));
            }
            catch { await DisplayAlert("Error", "No se pudo abrir WhatsApp", "OK"); }
        }
    }
}