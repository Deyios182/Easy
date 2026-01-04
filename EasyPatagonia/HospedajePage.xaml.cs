using Xamarin.Forms;
using EasyPatagonia.Models;
using EasyPatagonia.Services;

namespace EasyPatagonia
{
    public partial class HospedajePage : ContentPage
    {
        public HospedajePage()
        {
            InitializeComponent();
            // Carga limpia desde el Servicio
            hospedajeListView.ItemsSource = DatosService.ObtenerSoloHospedaje();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            if (e.SelectedItem is Empresa empresa)
            {
                // CORRECCIÓN: Usamos EmpresaDetallePage
                await Navigation.PushAsync(new EmpresaDetallePage(empresa));

                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}