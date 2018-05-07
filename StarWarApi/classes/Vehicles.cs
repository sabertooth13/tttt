using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarApi.classes
{
   
    public class Vehicles
    {
        private static Vehicles instance = new Vehicles();

        public int count { get; set; }
        public string next { get; set; }

        public string previous { get; set; }

        public Vehicle[] results { get; set; }

        public List<Vehicle> vehicleList = new List<Vehicle>();
        private Vehicles() { }
        

        public static Vehicles getInstance()
        {
            return instance;
        }
       
        public List<Vehicle> getVehicles()
        {
            return vehicleList;
        }

        public void insertVehicle(Vehicle _vehicle)
        {
            vehicleList.Add(_vehicle);
        }
    }
}
