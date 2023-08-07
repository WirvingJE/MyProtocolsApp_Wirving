using MyProtocolsApp_Wirving.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProtocolsApp_Wirving.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        
        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
        }

        //funciones 

        //función para validar el ingreso del usuario al app por medio del 
        //login 

        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            

            //control de bloqueo de funcionalidad 
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Password = pPassword;

                bool R = await MyUser.ValidateUserLogin();

                return R;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                return false;

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
