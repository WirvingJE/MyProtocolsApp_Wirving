using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_Wirving.Services
{
    public static class APIConnection
    {
        //aca definimos la direcionURL (ya sea IP o nombre de dominio a la que el app debe apuntar
        // por comodidad la ruta completa 

        public static string ProductionPrefixURL = "http://192.168.1.192:45457/api/";
        public static string TestingPrefixURL = "http://192.168.1.192:45457/api/";


        public static string ApiKeyName = "Progra6ApiKey";
        public static string ApiKeyValue = "WirvingProgra6AsdZxc12345";
    }
}
