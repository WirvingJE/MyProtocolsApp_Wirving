using MyProtocolsApp_Wirving.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProtocolsApp_Wirving.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        //el VM funciona como puente entre el modelo y la vista 
        //en sentido teórico el vm "siente" los cambios de la vista 
        //y los pasa al modelo de forma automática, o viceversa
        //según se use en uno o dos sentidos. 

        

        //primero en formato de funciones clásicas
        public User MyUser { get; set; }

        public UserRole MyUserRole { get; set; }

        public UserDTO MyUserDTO { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
            MyUserRole = new UserRole();
            MyUserDTO = new UserDTO();
        }

        //funciones 

        //funcion que carga los datos del objeto de usuario global 
        public async Task<UserDTO> GetUserDataAsync(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDTO = new UserDTO();

                userDTO = await MyUserDTO.GetUserInfo(pEmail);

                if (userDTO == null) return null;

                return userDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }


        public async Task<bool> UpdateUser(UserDTO pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUserDTO = pUser;

                bool R = await MyUserDTO.UpdateUserAsync();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }


        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            
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

        public async Task<List<UserRole>> GetUserRolesAsync()
        {
            try
            {
                List<UserRole> roles = new List<UserRole>();

                roles = await MyUserRole.GetAllUserRolesAsync();

                if (roles == null)
                {
                    return null;
                }

                return roles;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //función de creación de usuario nuevo 
        public async Task<bool> AddUserAsync(string pEmail,
                                             string pPassword,
                                             string pName,
                                             string pBackUpEmail,
                                             string pPhoneNumber,
                                             string pAddress,
                                             int pUserRoleID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                // MyUser = new User();

                MyUser.Email = pEmail;
                MyUser.Password = pPassword;
                MyUser.Name = pName;
                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.Address = pAddress;
                MyUser.UserRoleId = pUserRoleID;

                bool R = await MyUser.AddUserAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }






    }
}
