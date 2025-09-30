using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EasyPatagonia
{
    public partial class HospedajePage : ContentPage
    {
        public HospedajePage()
        {
            InitializeComponent();

            // Crear lista de hospedajes con WhatsApp y imágenes de Internet
            var hospedajes = new List<Lugar>
            {
                new Lugar {
                    Nombre = "Hotel Patagonia Dreams",
                    Descripcion = "Un hotel acogedor con vistas increíbles.",
                    Direccion = "Puerto Natales",
                    Latitud = -51.7245,
                    Longitud = -72.5022,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://link-a-imagen7.com",
                        "https://link-a-imagen8.com"
                    }
                },
                new Lugar {
                    Nombre = "Cabañas Torres del Paine",
                    Descripcion = "Cabañas rodeadas de naturaleza.",
                    Direccion = "Parque Nacional Torres del Paine",
                    Latitud = -51.7021,
                    Longitud = -72.6562,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://link-a-imagen9.com",
                        "https://link-a-imagen10.com"
                    }
                },
                new Lugar {
                    Nombre = "Hostel Última Esperanza",
                    Descripcion = "Un lugar económico y confortable.",
                    Direccion = "Calle Prat 123, Puerto Natales",
                    Latitud = -51.7298,
                    Longitud = -72.5065,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://link-a-imagen11.com",
                        "https://link-a-imagen12.com"
                    }
                }
            };

            // Asignar la lista de hospedajes al ListView
            hospedajeListView.ItemsSource = hospedajes;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var lugarSeleccionado = (Lugar)e.SelectedItem;

                // Navegar a la página de detalles con el lugar seleccionado
                await Navigation.PushAsync(new DetallePage(lugarSeleccionado));

                // Desmarcar el elemento seleccionado
                hospedajeListView.SelectedItem = null;
            }
        }
    }
}
