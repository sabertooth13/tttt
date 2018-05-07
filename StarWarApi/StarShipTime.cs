using StarWarApi.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarWarApi
{
    public class StarShip
    {
        private static StarShip starShipInstance = new StarShip();
        public List<StarShip> ships = new List<StarShip>();
        public int ID { get; set; }
        public string Name { get; set; }
        public double NoOfStops { get; set; }

        public string Comment { get; set; }
        public StarShip()
        {

        }

        public static StarShip getInstance()
        {
            return starShipInstance;
        }

        public void CalcMGTL(Vehicle vehicle, int mgltToTravel)
        {
            // if we make a wrong webRequest and get a null vehicle object we
            // dont have to make any more calculations on it.
            if (vehicle.name == null)
            {
                return;
            }
            
            double NoOfStops = 0;
            string[] MGLT;
            int mglt = 0;
            int shipId = 0;
            
            // if Max_Atmospheric speed is N/A , the ship is not capale to flight and so we can ignore such
            // starships.

            if (vehicle.max_atmosphering_speed.ToUpper() != "N/A")
            {
                if (IsValid(vehicle.MGLT))
                {
                    if (IsValid(vehicle.consumables))
                    {
                        double totTime = calcTimeInHrs(vehicle.consumables);
                        if ((vehicle.MGLT.IndexOf(" ", StringComparison.Ordinal) != -1))
                        {
                            MGLT = vehicle.MGLT.Split(' ');
                            mglt = Int32.Parse(MGLT[0].ToString());
                        }
                        else
                        {
                            mglt = Int32.Parse(vehicle.MGLT);

                        }
                        double singleStrech = mglt * totTime;
                        NoOfStops = ((mgltToTravel / singleStrech) < 0) ? 0 : (mgltToTravel / singleStrech);
                    }
                    if (IsValid(vehicle.url))
                    {
                        shipId = ((IsValid(vehicle.url))? GetShipId(vehicle.url): 0);
                    }

                    StarShip ship = new StarShip()
                    {
                        ID = shipId,
                        Name = vehicle.name,
                        NoOfStops = NoOfStops,

                    };
                    ships.Add(ship);
                }

            }
            else
            {
                if (IsValid(vehicle.url))
                {
                    shipId = ((IsValid(vehicle.url)) ? GetShipId(vehicle.url) : 0);
                }
                StarShip ship = new StarShip()
                {
                    ID = shipId,
                    Name = vehicle.name,
                    Comment = "this starship is incapable of atmospheric flight"

                };
                ships.Add(ship);
            }
        }

        private int GetShipId(string url)
        {
            // ship id is not required field , but then it might help to perform the 
            // unit tests if we know the ship id .
            // https://swapi.co/api/starships/75/ is the url format and only id is the one that is numeric
            // so we can easily extract it out using a simle regex as shown below.
            string resultString = Regex.Match(url, @"\d+").Value;
            return Int32.Parse(resultString);
        }

        public List<StarShip> DisplayFlightInfo()
        {
            return ships;
        }
        private Double calcTimeInHrs(string consumables)
        {

            double totalHrs = 0;
            string[] timeArray;
            int time;

            if ((consumables.IndexOf(" ", StringComparison.Ordinal) != -1))
            {
                timeArray = consumables.Split(' ');
                time = Int32.Parse(timeArray[0].ToString());
                switch (timeArray[1].ToLower().Substring(0, 1))
                {
                    /*
                     sometimes u we find "year" and "years" appearing on the 
                     consumables , insted of writing two conditions for each case
                     checking the start alphabet could be an easy option.
                     */

                    case "y":
                        totalHrs = time * 24 * 365;
                        break;
                    case "m":
                        // 2 months = 2 * 30.5 => 61 days( for convenince)
                        totalHrs = time * 24 * 30.5;
                        break;
                    case "w":
                        totalHrs = time * 24 * 7;
                        break;
                    case "d":
                        totalHrs = time * 24;
                        break;
                    case "h":
                        totalHrs = time;
                        break;
                    default:
                        totalHrs = 0.0;
                        break;
                }
            }
            else
            {
                totalHrs= Convert.ToDouble(consumables); 
            }
            return totalHrs;
        }

        private bool IsValid(string str)
        {
            bool ans = false;

            // we the property is "empty" or "null" or "unknown" , we dont have to it
            // under consideration .
            if (str != "" && str != null && str.ToLower() != "unknown")
                ans = true;
            return ans;
        }
    }
}
