using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EasyPatagonia
{
    public partial class DetallePage : ContentPage
    {
        private Lugar _lugar;

        public DetallePage(Lugar lugar)
        {
            InitializeComponent();
            _lugar = lugar;
            // Guardar coordenadas para el mapa
            this.Latitud = lugar.Latitud;
            this.Longitud = lugar.Longitud;
            // Asignar valores
            tituloLabel.Text = lugar.Nombre;
            descripcionLabel.Text = lugar.Descripcion;
            direccionLabel.Text = "Ubicación: " + lugar.Direccion;
            galleryCollectionView.ItemsSource = lugar.Imagenes;
            servicioLabel.Text = lugar.Servicio;
            // Asignar Logo
            if (!string.IsNullOrEmpty(lugar.Logo))
            {
                logoImage.Source = ImageSource.FromUri(new Uri(lugar.Logo));
            }
            else
            {
                logoImage.IsVisible = false; // Ocultar si no hay logo
            }
        }
        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (sender is Image image)
            {
                // Si el gesto de pinch está en ejecución, escalar la imagen
                if (e.Status == GestureStatus.Running)
                {
                    var scale = image.Scale * e.Scale;
                    image.Scale = scale;
                }
            }
        }

        // Evento para abrir una imagen seleccionada en tamaño completo
        // Evento para abrir una imagen seleccionada en tamaño completo
        private async void OnImageTapped(object sender, EventArgs e)
        {
            Debug.WriteLine("Imagen tocada");

            if (sender is Image image)
            {
                var imageSource = image.Source;

                // Verifica si la imagen es un URI (URL)
                if (imageSource is UriImageSource uriImageSource)
                {
                    // Obtener todas las imágenes
                    var imagenes = _lugar.Imagenes;  // Asumiendo que _lugar.Imagenes es la lista de URLs de las imágenes

                    // Crear un Image para el zoom
                    var zoomImage = new Image
                    {
                        Source = imageSource,
                        Aspect = Aspect.AspectFit,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };

                    // Crear un PinchGestureRecognizer para manejar el zoom
                    var pinchGestureRecognizer = new PinchGestureRecognizer();
                    pinchGestureRecognizer.PinchUpdated += (s, pinchArgs) =>
                    {
                        // Obtener la escala del gesto
                        if (pinchArgs.Status == GestureStatus.Running)
                        {
                            zoomImage.Scale = pinchArgs.Scale;
                        }
                    };

                    zoomImage.GestureRecognizers.Add(pinchGestureRecognizer);

                    // Crear el CarouselView o CollectionView con zoom
                    var carouselView = new CarouselView
                    {
                        ItemsSource = imagenes,
                        ItemTemplate = new DataTemplate(() =>
                        {
                            var img = new Image
                            {
                                Aspect = Aspect.AspectFit,
                                VerticalOptions = LayoutOptions.FillAndExpand,
                                HorizontalOptions = LayoutOptions.FillAndExpand
                            };

                            img.SetBinding(Image.SourceProperty, ".");
                            img.GestureRecognizers.Add(pinchGestureRecognizer); // Agregar el gesto de zoom

                            return img;
                        }),
                        BackgroundColor = Color.Black,
                        HeightRequest = 400
                    };

                    // Crear un modal para mostrar el CarouselView con el zoom
                    var modalImage = new ContentPage
                    {
                        BackgroundColor = Color.Black,
                        Content = new Grid
                        {
                            Children =
                    {
                        carouselView,  // Mostrar el CarouselView con las imágenes y zoom
                        new Button
                        {
                            Text = "Cerrar",
                            BackgroundColor = Color.Transparent,
                            TextColor = Color.White,
                            HorizontalOptions = LayoutOptions.End,
                            VerticalOptions = LayoutOptions.Start,
                            Command = new Command(async () => await Navigation.PopModalAsync())
                        }
                    }
                        }
                    };

                    await Navigation.PushModalAsync(modalImage);
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo cargar la imagen.", "OK");
                }
            }
        }

        public double Latitud { get; set; }
        public double Longitud { get; set; }
        private async void OnVerEnMapaClicked(object sender, EventArgs e)
        {
            // Abrir MapPage con coordenadas
            var mapPage = new MapPage();
            mapPage.SetLocation(Latitud, Longitud);
            await Navigation.PushAsync(mapPage);
        }

        private async void OnContactarWhatsAppClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_lugar.NumeroWhatsApp))
            {
                await DisplayAlert("Error", "Número de WhatsApp no disponible.", "OK");
                return;
            }

            var uri = new Uri($"https://wa.me/{_lugar.NumeroWhatsApp}");
            await Launcher.OpenAsync(uri);
        }
    }
}
