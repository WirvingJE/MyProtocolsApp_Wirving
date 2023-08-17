using MyProtocolsApp_Wirving.Models;
using MyProtocolsApp_Wirving.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProtocolsApp_Wirving.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordValidationPage : ContentPage
    {
        UserViewModel viewModel;
        public PasswordValidationPage()
        {
            

            BindingContext = viewModel = new UserViewModel();
           

           

        }

        private void LoadUserInfo()
        {
            TxtPassword.Text = GlobalObjects.MyLocalUser.Contrasennia;

        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            

            if (ValidateFields())
            {
             
                UserDTO BackupLocaluser = new UserDTO();
                BackupLocaluser = GlobalObjects.MyLocalUser;

                try
                {
                    GlobalObjects.MyLocalUser.Contrasennia = TxtNewPassword.Text.Trim();

                    var answer = await DisplayAlert("???", "Are you sure to continue updating password info?", "Yes", "No");

                    if (answer)
                    {
                       bool R = await viewModel.UpdatePassword(GlobalObjects.MyLocalUser);

                        if (R)
                        {
                            await DisplayAlert(":)", "Password Updated!!!", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Something went wrong...", "OK");
                            await Navigation.PopAsync();
                        }

                    }

                }
                catch (Exception)
                {
                 
                    GlobalObjects.MyLocalUser = BackupLocaluser;
                    throw;
                }



            }
        }
        private bool ValidateFields()
        {
            bool R = false;
            if (TxtNewPassword.Text != null && !string.IsNullOrEmpty(TxtNewPassword.Text.Trim()) &&
                TxtConfirmNewPassword.Text != null && !string.IsNullOrEmpty(TxtConfirmNewPassword.Text.Trim())
)
            {
                //en este caso están todos los datos requeridos 

                R = true;
            }
            else
            {
                
                if (TxtNewPassword.Text == null || string.IsNullOrEmpty(TxtNewPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The New Password is required", "OK");
                    TxtNewPassword.Focus();
                    return false;
                }
           
                if (TxtConfirmNewPassword.Text == null || string.IsNullOrEmpty(TxtConfirmNewPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The Confirm New Password is required", "OK");
                    TxtConfirmNewPassword.Focus();
                    return false;
                }


            }

            return R;
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}