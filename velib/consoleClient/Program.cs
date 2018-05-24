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
            //Console.WriteLine(answer);
            Console.WriteLine("tapez vos commandes ou help pour obtenir de l'aide");
            string entry = "";
            while (!entry.Equals("exit"))
            {
                entry = Console.ReadLine();
                Console.WriteLine(returnInfos(entry,objClient));                
            }
            

        }

        //This method calls the web service to retrieve ask informations
        private static string returnInfos(string command,ServiceReference1.Service1Client objClient)
        {
            string[] splittedCommand = command.ToLower().Split(' ');
            switch (splittedCommand[0])
            {
                case "help":
                    return "Obtenir la liste des villes : tapez cities\n" +
                           "Afficher la liste des stations d'une ville : tapez stations puis un espace puis le nom de la ville\n" +
                           "Obtenir le nombre de vélos disponibles : tapez bikes puis un espace puis le nom de la ville encore un espace et le nom de la station\n"+
                           "Souscrire à une station: tapez subscribe puis un espace puis le nom de la ville encore un espace et le nom de la station\n"+
                           "Quitter la console : exit";
                case "cities":
                    string[] cities = objClient.GetAllCities();
                    string result = "\n";
                    for(int i = 0; i < cities.Length; i++)
                    {
                        result += cities[i] + "\n";
                    }
                    return result;
                case "stations":
                    string[] stations = objClient.GetAllStations(splittedCommand[1]);
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
                    return objClient.GetAvailableBikes(station.ToUpper(), splittedCommand[1]);
                case "subscribe":
                    string station1 = "";
                    for (int i = 2; i < splittedCommand.Length; i++)
                    {
                        station1 += splittedCommand[i] + " ";
                    }
                    station1 = station1.Remove(station1.Length - 1);
                    objClient.SuscribeStationEvent(station1.ToUpper(), splittedCommand[1]);
                    return "vous avez bien souscrit";
                default:
                    return "commande non reconnue";
            }
        }

    }
}
