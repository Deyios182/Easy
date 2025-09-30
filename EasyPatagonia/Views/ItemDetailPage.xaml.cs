using EasyPatagonia.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EasyPatagonia.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}