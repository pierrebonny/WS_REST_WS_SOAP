using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleClient
{
    class Service1CallbackSink : ServiceReference1.IService1Callback
    {
        public void availableBikesRecovered(string station, string city, string result)
        {
            Console.WriteLine("City ...: {0}", city);
            Console.WriteLine("Station ...: {0}", station);
            Console.WriteLine("Available Bikes ......: {0}", result);
        }

        public void availableBikesRecoveringFinished()
        {
            Console.WriteLine("availableBikes recovering completed");
        }
    }
}
