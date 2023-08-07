using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace MyProtocolsApp_Wirving.Models
{
    
        public class User
        {
            
            public RestRequest Request { get; set; }

            //en es

            public int UserId { get; set; }
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string Name { get; set; } = null!;
            public string BackUpEmail { get; set; } = null!;
            public string PhoneNumber { get; set; } = null!;
            public string? Address { get; set; }
            public bool? Active { get; set; }
            public bool? IsBlocked { get; set; }
            public int UserRoleId { get; set; }

            public virtual UserRole? UserRole { get; set; }

            public User()
            {

            }

          
            public async Task<bool> ValidateUserLogin()
            {
                try
                {
                     

                    string RouteSufix = string.Format("Users/ValidateLogin?username={0}&password={1}",
                                                                           this.Email, this.Password);
                    //armamos la ruta completa al endpoint en el API 
                    string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                    RestClient client = new RestClient(URL);

                    Request = new RestRequest(URL, Method.Get);

                    //agregamos mecanismo de seguridad, en este caso API key
                    Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                    //ejecutar la llamada al API 
                    RestResponse response = await client.ExecuteAsync(Request);

                    //saber si las cosas salieron bien 
                    HttpStatusCode statusCode = response.StatusCode;

                    if (statusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    throw;
                }

            }



        }
    }
