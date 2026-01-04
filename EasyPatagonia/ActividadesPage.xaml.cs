using Xamarin.Forms;
using EasyPatagonia.Models;
using EasyPatagonia.Services;

namespace EasyPatagonia
{
    public partial class ActividadesPage : ContentPage
    {
        public ActividadesPage()
        {
            InitializeComponent();
            // Carga limpia desde el Servicio
            empresasListView.ItemsSource = DatosService.ObtenerSoloActividades();
        }

        private async void OnEmpresaSelected(object sender, SelectedItemChangedEventArgs e)
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