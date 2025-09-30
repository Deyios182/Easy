using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System;
using Xamarin.Essentials;

namespace EasyPatagonia
{
    public partial class MapPage : ContentPage
    {
        private double latitude;
        private double longitude;

        public MapPage()
        {
            InitializeComponent();

            // Coordenadas predeterminadas (Puerto Natales)
            latitude = -46.625996;
            longitude = -72.672474; 
                   

            // Establecer ubicación inicial en el mapa
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(latitude, longitude),
                Distance.FromMiles(10)));
        }

        public void SetLocation(double latitud, double longitud)
        {
            // Guardar las coordenadas para usarlas más tarde
            latitude = latitud;
            longitude = longitud;

            // Mover el mapa y agregar un pin en la nueva ubicación
            var position = new Position(latitud, longitud);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(10)));

            map.Pins.Clear();
            var pin = new Pin
            {
                Label = "Ubicación seleccionada",
                Position = position,
                Type = PinType.Place
            };
            map.Pins.Add(pin);
        }

        private async void OnComoLlegarClicked(object sender, EventArgs e)
        {
            try
            {
                // Validar que las coordenadas sean válidas
                if (latitude == 0 && longitude == 0)
                {
                    await DisplayAlert("Error", "No se encontró la ubicación.", "OK");
                    return;
                }

                // Construir la URL para abrir Google Maps
                var location = $"{latitude},{longitude}";
                var url = $"https://www.google.com/maps/dir/?api=1&destination={location}";

                // Abrir Google Maps
                await Launcher.OpenAsync(url);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un problema: {ex.Message}", "OK");
            }
        }
    }
}
