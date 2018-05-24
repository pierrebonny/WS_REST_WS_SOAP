using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleClient
{
    class Service1CallbackSink : ServiceReference1.IService1Callback
    {
        public void GetStation(string city, string station, int bikes)
        {
            Console.WriteLine(station + " - " + bikes);
        }
    }
}
