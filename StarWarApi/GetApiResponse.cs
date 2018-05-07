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
     public class GetApiResponse
    {
        private readonly IGetApiResponse __getAPiResponse;

        public GetApiResponse(IGetApiResponse getApiResponse)
        {
            __getAPiResponse = getApiResponse;
        }

        public GetApiResponse() : this(new ApiRequest())
        {
        }

        public void GetStopsForEachShip(int MGLT)
        {
          /*
           this methods gets the MGLT from the win form , then calculates the
           no. of stops .
             */
            MegalightCalc calcJourney = new MegalightCalc(MGLT);
            calcJourney.CalcJourneyTime(ApiRequest.getInstance().GetVehicles(__getAPiResponse));
            
        }

        
       
    }
}
