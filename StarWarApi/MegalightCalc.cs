using StarWarApi.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarApi
{
    public class MegalightCalc
    {
        private static MegalightCalc instance = new MegalightCalc();
        private int _mglt;
        public MegalightCalc(int mglt)
        {
            _mglt = mglt;
        }
        public MegalightCalc()
        {

        }

        public static MegalightCalc getInstance()
        {
            return instance;
        }

        public void CalcJourneyTime(List<Vehicle> vehicleList)
        {
            foreach (var _vehicle in vehicleList)
            {
                StarShip.getInstance().CalcMGTL(_vehicle, _mglt);

            }
        }

        public DataTable DisplayFlightInfo()
        {
            /*
             The final output result obj is displayed back onto the Winforms.
             */

            DataTable table = new DataTable();
            var result = StarShip.getInstance().DisplayFlightInfo();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("StartShip", typeof(string));
            table.Columns.Add("No of Stops", typeof(string));
            table.Columns.Add("Comments", typeof(string));
            if (result.Count > 0)
            {

                
                string stops;
                foreach (var item in result)
                {
                    if (item.NoOfStops == 0)
                    {
                        stops = "N/A";
                    }
                    else
                    {
                        if (item.NoOfStops.ToString().IndexOf(".", StringComparison.Ordinal) != -1)
                        {
                            int len = item.NoOfStops.ToString().IndexOf(".");
                            stops = item.NoOfStops.ToString().Substring(0,len);
                        }
                        else
                        {
                            stops = item.NoOfStops.ToString();
                        }
                    }

                    table.Rows.Add(item.ID, item.Name, stops, item.Comment);
                   
                }

            }

            return table;
        }
    }
}
