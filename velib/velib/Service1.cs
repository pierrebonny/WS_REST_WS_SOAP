using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace velib
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public List<string> GetAllCities()
        {

            List<string> cities = new List<string>();
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts/?apiKey=b154bc54d7081fcf4106a4b2f5fd170d72d74d30");
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
                Console.WriteLine((string)item.SelectToken("name"));
                cities.Add((string)item.SelectToken("name"));
            }
            return cities;
        }

        public List<string> GetAllStations(string city)
        {
            List<string> stations = new List<string>();
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations/?contract="+city+"&apiKey=b154bc54d7081fcf4106a4b2f5fd170d72d74d30");
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
                stations.Add((string)item.SelectToken("name"));
            }
            return stations;
        }

        public string GetAvailableBikes(string station, string city)
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + firstToUpper(city) + "&apiKey=b154bc54d7081fcf4106a4b2f5fd170d72d74d30");
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
            int number = 0;
            string stationn = "";
            string stringToFind = station.ToUpper();

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

            if (stationn != null)
            {
                return "\n\nStation détectée = " + stationn + "\n\nNombre de vélos disponibles = " + number;
            }
            //else if no station has been detected for the given name
            else
            {
                return "\n\nAucune information n'a été trouvée à propos de : " + stringToFind;
            }
        }
        private String firstToUpper(String s)
        {
            return s[0].ToString().ToUpper() + s.Substring(1).ToLower();
        }
    }
}
