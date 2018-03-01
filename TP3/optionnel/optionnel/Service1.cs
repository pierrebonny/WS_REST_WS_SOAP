using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace optionnel
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public string GetData(int time)
        {
            return string.Format("You entered: {0}", time);
        }

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] {
","
                    });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] =
                                null
                                ;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return csvData;
        }

        private JArray doRequest()
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=Toulouse&apiKey=b154bc54d7081fcf4106a4b2f5fd170d72d74d30");
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
            return j;
        }

        private void toCsv(JArray j)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn(DateTime.Now.ToString(), typeof(String)));
            string[] stringToFind = { "55", "195", "156"};
            string bikes = "";

            //browsing all Json Array elements to find the asked one
            foreach (JObject item in j)
            {
                string number = (string)item.SelectToken("number");

                if (number.Contains(stringToFind[0])|| number.Contains(stringToFind[1]) || number.Contains(stringToFind[2]))
                {
                    bikes = (string)item.SelectToken("available_bikes");
                    if (bikes != null)
                    {
                        

                    }
                }
            }
        }

                        /*public CompositeType GetDataUsingDataContract(CompositeType composite)
                        {
                            if (composite == null)
                            {
                                throw new ArgumentNullException("composite");
                            }
                            if (composite.BoolValue)
                            {
                                composite.StringValue += "Suffix";
                            }
                            return composite;
                        }*/
                    }
}
