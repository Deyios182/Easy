using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EasyPatagonia
{
    public partial class RestaurantesPage : ContentPage
    {
        public RestaurantesPage()
        {
            InitializeComponent();

            // Crear lista de restaurantes con WhatsApp y imágenes de Internet
            var restaurantes = new List<Lugar>
            {
                new Lugar {
                    Nombre = "La Mesita Grande",
                    Descripcion = "Deliciosa pizza artesanal.",
                    Direccion = "Puerto Natales",
                    Latitud = -51.7250,
                    Longitud = -72.5020,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://link-a-imagen1.com",
                        "https://link-a-imagen2.com"
                    }
                },
                new Lugar {
                    Nombre = "Aldea Restaurante",
                    Descripcion = "Cocina gourmet con productos locales.",
                    Direccion = "Puerto Natales",
                    Latitud = -51.7300,
                    Longitud = -72.5050,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://link-a-imagen3.com",
                        "https://link-a-imagen4.com"
                    }
                },
                new Lugar {
                    Nombre = "Santolla",
                    Descripcion = "Mariscos frescos en un ambiente acogedor.",
                    Direccion = "Calle Blanco 567, Puerto Natales",
                    Latitud = -51.7330,
                    Longitud = -72.5080,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://link-a-imagen5.com",
                        "https://link-a-imagen6.com"
                    }
                }
            };

            // Asignar la lista de restaurantes al ListView
            restauranteListView.ItemsSource = restaurantes;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var lugarSeleccionado = (Lugar)e.SelectedItem;

                // Navegar a la página de detalles con el lugar seleccionado
                await Navigation.PushAsync(new DetallePage(lugarSeleccionado));

                // Desmarcar el elemento seleccionado
                restauranteListView.SelectedItem = null;
            }
        }
    }
}
