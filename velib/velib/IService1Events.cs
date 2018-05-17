using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace velibService
{
    interface IService1Events
    {
        [OperationContract(IsOneWay = true)]
        void GetStation(string station, int bikes);
    }
}
