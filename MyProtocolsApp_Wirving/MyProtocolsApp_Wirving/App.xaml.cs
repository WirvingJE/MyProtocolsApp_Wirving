using MyProtocolsApp_Wirving.Services;
using MyProtocolsApp_Wirving.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProtocolsApp_Wirving
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //definimos la forma de aplilar pagimas en la pantalla 
            MainPage = new NavigationPage(new AppLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
