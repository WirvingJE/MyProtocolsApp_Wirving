﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProtocolsApp_Wirving.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage ()
        {
            InitializeComponent();

            LoadUserName();
        }
        private void LoadUserName()
		{

           
                LblUserName.Text = GlobalObjects.MyLocalUser.Nombre.ToUpper();
            

        }
       

    }
}