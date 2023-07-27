using MyProtocolsApp_Wirving.ViewModels;
using MyProtocolsApp_Wirving.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyProtocolsApp_Wirving
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
