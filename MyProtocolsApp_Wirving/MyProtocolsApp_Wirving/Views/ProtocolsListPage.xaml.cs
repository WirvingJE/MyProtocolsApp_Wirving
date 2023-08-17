using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProtocolsApp_Wirving.ViewModels;

namespace MyProtocolsApp_Wirving.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProtocolsListPage : ContentPage
    {
        ProtocolViewModel protocolViewModel;

        public ProtocolsListPage()
        {
            InitializeComponent();

            BindingContext = protocolViewModel = new ProtocolViewModel();
            LoadProtocolist();

        }

        private async void LoadProtocolist()
        {

            LvList.ItemsSource = await protocolViewModel.GetProtocolsAsync(GlobalObjects.MyLocalUser.IDUsuario);

        }




    }
}