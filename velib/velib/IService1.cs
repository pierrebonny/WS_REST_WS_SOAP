﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace velibService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetAvailableBikes(String station, String city);

        [OperationContract]
        List<String> GetAllCities();

        [OperationContract]
        List<String> GetAllStations(String city);

        // TODO: ajoutez vos opérations de service ici
    }
}
