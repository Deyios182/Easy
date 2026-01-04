using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyPatagonia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisionAppPage : ContentPage
    {
        public VisionAppPage()
        {
            InitializeComponent();
        }

        private async void OnExplorarClicked(object sender, EventArgs e)
        {
            // SOLUCIÓN AL ERROR: USAR LA NAVEGACIÓN DIRECTA A LA PESTAÑA RAÍZ

            // El AppShell.xaml usa el nombre "Mapa" como la primera pestaña.
            // La sintaxis segura para navegar directamente a un Tab es: //NombreDelTab

            // GoToAsync lleva al usuario directamente al Tab "Mapa".
            // Esto soluciona el error 'unable to figure out route'
            await Shell.Current.GoToAsync("//Mapa");
        }
    }
}