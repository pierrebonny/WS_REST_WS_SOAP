using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace velibService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract(CallbackContract = typeof(IService1Events))]
    public interface IService1
    {
        [OperationContract]
        Task<string> GetAvailableBikes(String station, String city);

        [OperationContract]
        Task<List<String>> GetAllCities();

        [OperationContract]
        Task<List<String>> GetAllStations(String city);

        [OperationContract]
        void SuscribeStationEvent(string station, string city);
    }
}
