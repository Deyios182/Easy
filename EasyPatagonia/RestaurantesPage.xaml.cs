using Xamarin.Forms;
using EasyPatagonia.Models;
using EasyPatagonia.Services; // Usamos el servicio centralizado

namespace EasyPatagonia
{
    public partial class RestaurantesPage : ContentPage
    {
        public RestaurantesPage()
        {
            InitializeComponent();
            // Carga limpia desde el Servicio
            // Asegúrate de que tu ListView en el XAML se llame x:Name="restauranteListView"
            restauranteListView.ItemsSource = DatosService.ObtenerSoloRestaurantes();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            if (e.SelectedItem is Empresa empresa)
            {
                // CORRECCIÓN: Usamos EmpresaDetallePage (la nueva) en lugar de DetallePage (la vieja)
                await Navigation.PushAsync(new EmpresaDetallePage(empresa));

                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}