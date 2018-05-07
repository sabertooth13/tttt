using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarWarApi.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StarWarApi
{
    public class ApiRequest : IGetApiResponse
    {
        private static ApiRequest instance = new ApiRequest();

        public ApiRequest() { }

        //Get the only object available
        public static ApiRequest getInstance()
        {
            return instance;
        }
        public JObject GetApiRespone(string apiurl)
        {
            /*
             Makes the HttpWebRequest and gets the response body from the API.
             
             */

            try
            {
                string responseBody = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiurl);
                httpWebRequest.Method = "GeT";
                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    responseBody = reader.ReadToEnd();
                }

                return JObject.Parse(responseBody);
            }
            catch (Exception ex)
            {
                // preferably log it somewhere using Nlog.
                return JObject.Parse("{}");
            }
        }

        public List<Vehicle> GetVehicles(IGetApiResponse __getResponser)
        {
            int i = 1;
            string next = "";

            do
            {
                // Ideally API url's should come from the Web config. 
                string url = string.Format("https://swapi.co/api/starships/?page={0}", i);
                Newtonsoft.Json.Linq.JObject pageNumber = __getResponser.GetApiRespone(url);
                next = pageNumber.SelectToken("next").Value<string>();
                // get JSON result objects into a list
                IList<JToken> results = pageNumber["results"].Children().ToList();

                foreach (JToken result in results)
                {

                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    Vehicle searchResult = result.ToObject<Vehicle>();
                    Vehicles.getInstance().insertVehicle(searchResult);
                }

                i++;
            } while (next != null);

            return Vehicles.getInstance().getVehicles();
        }
    }
}
