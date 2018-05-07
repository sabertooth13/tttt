using Newtonsoft.Json.Linq;
using StarWarApi.classes;
using System.Collections.Generic;

namespace StarWarApi
{
    public interface IGetApiResponse
    {
        JObject GetApiRespone(string apiurl);

        List<Vehicle> GetVehicles(IGetApiResponse __getResponser);

    }
}