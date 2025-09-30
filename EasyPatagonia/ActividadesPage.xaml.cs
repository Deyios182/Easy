using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EasyPatagonia
{
    public partial class ActividadesPage : ContentPage
    {
        public ActividadesPage()
        {
            InitializeComponent();

            // Crear lista de actividades con WhatsApp y imágenes de Internet
            var actividades = new List<Lugar>
            {
                new Lugar {
                    Nombre = "Tours Santuario Capillas de Mármol",
                    Descripcion = "Realiza un paseo en bote hasta las Capillas de Marmol",
                    Direccion = "Puerto Rio Tranquilo",
                    Servicio = "Tour Simple 1 hora 30 minutos)\nEn este tour en bote podrás conocer las formaciones más icónicas del santuario, incluyendo las cavernas de Puerto Río Tranquilo, las formaciones de mármol, y las reconocidas figuras de la Tortuga de Mármol, la Trompa del Elefante y la Cabeza del Perro. El recorrido termina en los sectores de Túnel, Catedral y Capilla de Mármol.\nValor: $20.000 por persona\nIncluye: Manta de agua y chaleco salvavidas.\n\nTour Full(2 horas 30 minutos)\nEste tour recorre todo lo mencionado en el tour simple y añade la majestuosidad de la Isla Panichini, visitando barcos abandonados y un bote hundido. Durante el recorrido, conocerás sobre la gran época minera en el Lago General Carrera.Luego, seguimos por la orilla de la isla Panichini para visitar las cavernas de Puerto Sánchez, la extensión de cavernas de mármol más larga del mundo.\nValor: $30.000 por persona",
                    Latitud = -46.625996,
                    Longitud = -72.672474,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://denomades.imgix.net/destinos/coyhaique/602/navegacion-capilla-de-marmol-en-coyhaique-con-denomades.jpg?w=907&h=494&fit=crop&q=100",
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTO_6ITtAdXaQlBDIL1DsRkDmlMjGvtoossDg&s",
                        "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Cabeza_de_perro%2C_capilla_de_M%C3%A1rmol.JPG/1200px-Cabeza_de_perro%2C_capilla_de_M%C3%A1rmol.JPG",
                        "https://megaconstrucciones.net/images/naturales/foto2/marmol-catedral.jpg",
                        "https://megaconstrucciones.net/images/naturales/foto2/marmol-catedral-4.jpg"
                    },
                    Logo = "https://i.imgur.com/bRSWE4P.png"  // <-- Agregar URL del logo
                },
                new Lugar {
                    Nombre = "Pesca en el lago Toro",
                    Descripcion = "Disfruta de pesca deportiva en el lago Toro.",
                    Direccion = "Lago Toro, Torres del Paine",
                    Latitud = -51.9000,
                    Longitud = -72.6000,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://link-a-imagen15.com",
                        "https://link-a-imagen16.com"
                    },
                    Logo = "https://your-image-url.com/logo-tour.jpg"  // <-- Agregar URL del logo
                },
                new Lugar {
                    Nombre = "Rafting en el río Serrano",
                    Descripcion = "Experimenta rafting en aguas bravas.",
                    Direccion = "Parque Torres del Paine",
                    Latitud = -51.8000,
                    Longitud = -72.7000,
                    NumeroWhatsApp = "+56989838218",  // Tu número de WhatsApp
                    Imagenes = new List<string>
                    {
                        "https://link-a-imagen17.com",
                        "https://link-a-imagen18.com"
                    },
                    Logo = "https://your-image-url.com/logo-tour.jpg"  // <-- Agregar URL del logo
                }
            };

            // Asignar la lista de actividades al ListView
            actividadListView.ItemsSource = actividades;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var lugarSeleccionado = (Lugar)e.SelectedItem;

                // Navegar a la página de detalles con el lugar seleccionado
                await Navigation.PushAsync(new DetallePage(lugarSeleccionado));

                // Desmarcar el elemento seleccionado
                actividadListView.SelectedItem = null;
            }
        }
    }
}
