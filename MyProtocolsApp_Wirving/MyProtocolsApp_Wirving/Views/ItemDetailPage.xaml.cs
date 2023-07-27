using MyProtocolsApp_Wirving.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyProtocolsApp_Wirving.Views
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