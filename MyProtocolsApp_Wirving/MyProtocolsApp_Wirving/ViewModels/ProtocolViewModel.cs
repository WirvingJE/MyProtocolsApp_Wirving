using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MyProtocolsApp_Wirving.Models;

namespace MyProtocolsApp_Wirving.ViewModels
{
    public class ProtocolViewModel : BaseViewModel
    {
        public Protocol MyProtocol { get; set; }

        public ProtocolViewModel()
        {
            MyProtocol = new Protocol();
                
        }

        //funciones del vm

        public async Task<ObservableCollection<Protocol>> GetProtocolsAsync(int PUserID)
        {

            if (IsBusy) return null;
            IsBusy = true;

            try
            {

                ObservableCollection<Protocol> protocols = new ObservableCollection<Protocol>();

                MyProtocol.UserId = PUserID;

                protocols = await MyProtocol.GetProtocolListByUserID();

                if (protocols == null)
                {
                    return null;

                }
                return protocols;


            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


    }
}
