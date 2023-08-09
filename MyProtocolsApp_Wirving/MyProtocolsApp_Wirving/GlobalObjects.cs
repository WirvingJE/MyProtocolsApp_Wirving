using MyProtocolsApp_Wirving.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_Wirving
{
    public static class GlobalObjects
    {
        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        //crear el objeto local (global) de usuario 
        public static UserDTO MyLocalUser = new UserDTO();

    }
}
