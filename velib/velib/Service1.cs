using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

namespace velibService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        static Action<String, String, String> m_Event1 = delegate { };
        static Action m_Event2 = delegate { };

        private static Dictionary<string, List<string>> cacheStations = new Dictionary<string,List<string>>();
        private static List<string> cacheCities = new List<string>();

        //Make a request to the JCDecaux server to retrieve all available cities names and returns it as a string list
        public async Task<List<string>> GetAllCities()
        {
            if(cacheCities.Count > 0)
            {
                return cacheCities;
            }
            else
            {
                List<string> cities = new List<string>();
                WebRequest request = await Task.Run(() => WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts/?apiKey=b154bc54d7081fcf4106a4b2f5fd170d72d74d30"));
                // Create a request for the URL. 
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                JArray j = JArray.Parse(responseFromServer);
                Console.WriteLine(responseFromServer);

                //browsing all Json Array elements to find the asked one
                foreach (JObject item in j)
                {
                    cities.Add((string)item.SelectToken("name"));
                }
                cacheCities.AddRange(cities);
                return cities;
            }
            
        }

        //Make a request to the JCDecaux server to retrieve all available stations names for the given city name and returns it as a string list
        public async Task<List<string>> GetAllStations(string city)
        {
            if (cacheStations.ContainsKey(city.ToLower())){
                return cacheStations[city.ToLower()];
            }
            else
            {
                List<string> stations = new List<string>();
                WebRequest request = await Task.Run(() => WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations/?contract=" + city + "&apiKey=b154bc54d7081fcf4106a4b2f5fd170d72d74d30"));
                // Create a request for the URL. 
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                try
                {
                    // Get the response.
                    WebResponse response = request.GetResponse();
                    // Display the status.
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                    // Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    JArray j = JArray.Parse(responseFromServer);
                    Console.WriteLine(responseFromServer);

                    //browsing all Json Array elements to find the asked one
                    foreach (JObject item in j)
                    {
                        stations.Add((string)item.SelectToken("name"));
                    }
                    cacheStations.Add(city.ToLower(),stations);
                    
                    return stations;
                }
                //if the name doesn't exist in the JCDecaux's database
                catch (System.Net.WebException)
                {
                    stations.Add("Nom de station inconnu");
                    return stations;
                }
            }
                        
        }

        public async Task<string> GetAvailableBikes(string station, string city)
        {
            WebRequest request = await Task.Run(() => WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=b154bc54d7081fcf4106a4b2f5fd170d72d74d30"));
            // Create a request for the URL. 
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            try
            {
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                JArray j = JArray.Parse(responseFromServer);
                Console.WriteLine(responseFromServer);
                int number = 0;
                string stationn = "";
                string stringToFind = station;

                //browsing all Json Array elements to find the asked one
                foreach (JObject item in j)
                {
                    string name = (string)item.SelectToken("name");

                    if (stringToFind != null && name.Contains(stringToFind))
                    {
                        number = (int)item.SelectToken("available_bikes");
                        stationn = name;
                        break;
                    }
                }

                reader.Close();
                response.Close();

                //if a station has been detected for the given name
                IService1Events events = OperationContext.Current.GetCallbackChannel<IService1Events>();
                
                if (stationn != null)
                {
                    events.availableBikesRecovered(station, city,number+"");
                    return "\n\nStation = " + stationn + "\n\nNombre de vélos disponibles = " + number;
                }
                //else if no station has been detected for the given name
                else
                {
                    events.availableBikesRecovered(station, city, "unknown station");
                    return "\n\nAucune information n'a été trouvée à propos de : " + stringToFind;
                }
            //if the city or station name doesn't exist in the JCDecaux's database
            }catch (System.Net.WebException){
                return "nom de station ou de ville incorrect";
            }
            
            
        }

        public void SubscribeAvailableBikesRecovered()
        {
            IService1Events subscriber =
            OperationContext.Current.GetCallbackChannel<IService1Events>();
            m_Event1 += subscriber.availableBikesRecovered;
        }

        public void SubscribeAvailableBikesRecoveringFinished()
        {
            IService1Events subscriber =
            OperationContext.Current.GetCallbackChannel<IService1Events>();
            m_Event2 += subscriber.availableBikesRecoveringFinished;
        }
    }
}
