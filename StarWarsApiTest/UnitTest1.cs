using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarApi;
using StarWarApi.classes;

namespace StarWarsApiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestEachStarShip()
        {
            /*
             for this Test , we need to specify the MGLT and Starship ID.
             StrarShip ID should be obtained from https://swapi.co/api/starships/ which displays the list of 
             all ships.
             eg "url": "https://swapi.co/api/starships/15/" shows the StarShip ID.

            Now some the startShip ids that u can use are:-
           
            For the below test i've selected MGLT as 1000,000 as per the question
            and the ShipID that can be testd are
            
            ID ,    Startship  ,             No. Of Stops.(Expected o/p)
            11      Y-wing:                  74
            10      Millennium Falcon:       9
            17      Rebel Transport:         11

             
             */

            int MGLT = 1000000;
            int shipId = 10;
            int NoOfStops = NumberOfStops(MGLT, shipId);
            Assert.AreEqual(9, NoOfStops);
        }


        [TestMethod]
        public void TestEachStarShipFail()
        {
            /*
             ****** THIS TEST WILL FAIL (it is desinged to fail to demontrate a failing test)*****.
             *   MGLT used in this test is 100,000 and not 1000,000 .
             *   So the no of Stops would also change accordingly thus making the test fail.
             alternatively another way we can make this test fail
             is by supplying a Non-Existant ShipID;
             */

            int MGLT = 100000;
            int shipId = 10;
            int NoOfStops = NumberOfStops(MGLT, shipId);
            Assert.AreEqual(9, NoOfStops);
        }

        private static int NumberOfStops(int MGLT, int shipId)
        {
            int NoOfStops = 0;
            Vehicle vehicle = new Vehicle();
            string apiUrl = string.Format("https://swapi.co/api/starships/{0}/", shipId);
            var starShipObj = ApiRequest.getInstance().GetApiRespone(apiUrl);
            vehicle = starShipObj.ToObject<Vehicle>();
            StarShip.getInstance().CalcMGTL(vehicle, MGLT);
            var shipStats = StarShip.getInstance().DisplayFlightInfo();
            if (shipStats.Count > 0)
            {
                NoOfStops = (int)shipStats[0].NoOfStops;
            }
            return NoOfStops;
        }
    }
}
