using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACreateInventoryQuantityTable
{
    class CreateOrderingTableBasicDatas
    {
        private static Random rnd;
        private static List<string> listOfRecords;
        //private static Random rnd;

        // (`beszerzes_id`, `termek_quant_id`, `user_id`, `beszerzes_mennyiseg`, `beszerzes_datum`," +
        //  " `beszerzes_teljesites`, `beszerzes_modosit`, `beszerzes_erveny`)

        public static List<string> createordering(List<string[]> tempStore, List<string[]> tempRequests)
        {
            listOfRecords = new List<string>();
            rnd = new Random();
            for (int i = 0; i < tempStore.Count; i++)
            {
                int value = 0;
                for (int j = 0; j < tempRequests.Count; j++)    //counting together, how much is requested
                {
                    if (tempRequests[j][0] == tempStore[i][0])
                    {
                        value += Convert.ToInt32(tempRequests[j][1]);
                    }
                }
                value += Convert.ToInt32(tempStore[i][1]);  //adding the amount of store, those are 
                                                            //surely ordered and arrived
                string row = "";
                row += "("+tempStore[i][0] + ", ";  //the product DB stripping ID -> refers to 'termek_min_id'
                                                //'termek_kiszerel' and 'beszallito_id'
                row += "3, ";                   //who wants order that
                row += value.ToString() + ", "; //the amount
                row += "'2017-11-12', ";        //record start
                row += "'2017-12-";             //ordering arrives
                row += rnd.Next(1,31).ToString()+ "', ";    //the day of the arriving
                row += "3, ";                   //who made the last modification
                row += "3)";
                row += (i + 1 == tempStore.Count) ? ";" : ",";
                listOfRecords.Add(row);

            }
            return listOfRecords;
        }
        /*
        private static string[] giveADatePair()
        {
            string[] dates = new string[2];
            string trunk = rnd.Next(2018, 2020).ToString() + "-" + rnd.Next(1, 13).ToString() + "-";
            int day = rnd.Next(1, 30);
            dates[0] = trunk + day.ToString();
            dates[1] = trunk + (day + 1).ToString();
            return null;
        }
        */
    }
}
