using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace consoleClient
{
    class Program
    {
        static void Main(string[] args){
            Service1CallbackSink objsink = new Service1CallbackSink();
            InstanceContext iCntxt = new InstanceContext(objsink);

            ServiceReference1.Service1Client objClient = new ServiceReference1.Service1Client(iCntxt);
            objClient.SuscribeStationEvent("156", "toulouse");
            String answer = objClient.GetAvailableBikes("156", "toulouse");
            Console.WriteLine("Vous avez bien souscrit");


            Console.WriteLine(answer);
            Console.ReadLine();
            /*Service1Client client = new Service1Client();
            Console.WriteLine("tapez vos commandes ou help pour obtenir de l'aide");
            string entry = "";
            while (!entry.Equals("exit"))
            {
                entry = Console.ReadLine();
                Console.WriteLine(returnInfos(entry,client));                
            }*/
            

        }

        //This method calls the web service to retrieve ask informations
        private static string returnInfos(string command,ServiceReference1.Service1Client client)
        {
            string[] splittedCommand = command.ToLower().Split(' ');
            switch (splittedCommand[0])
            {
                case "help":
                    return "Obtenir la liste des villes : tapez cities\n" +
                           "Afficher la liste des stations d'une ville : tapez stations puis un espace puis le nom de la ville\n" +
                           "Obtenir la liste des stations disponibles : tapez bikes puis un espace puis le nom de la ville encore un espace et le nom de la station\n"+
                           "Quitter la console : exit";
                case "cities":
                    string[] cities = client.GetAllCities();
                    string result = "\n";
                    for(int i = 0; i < cities.Length; i++)
                    {
                        result += cities[i] + "\n";
                    }
                    return result;
                case "stations":
                    string[] stations = client.GetAllStations(splittedCommand[1]);
                    string result1 = "\n";
                    for (int i = 0; i < stations.Length; i++)
                    {
                        result1 += stations[i] + "\n";
                    }
                    return result1;
                case "bikes":
                    string station = "";
                    for (int i = 2; i < splittedCommand.Length; i++)
                    {
                        station += splittedCommand[i] + " ";
                    }
                    station = station.Remove(station.Length - 1);
                    return client.GetAvailableBikes(station.ToUpper(), splittedCommand[1]);
                default:
                    return "commande non reconnue";
            }
        }

    }
}
