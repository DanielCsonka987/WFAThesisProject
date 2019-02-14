using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACreateInventoryQuantityTable
{
    class CreateOrderingTableDatas
    {
        private static List<string> listOfRecords;
        //private static Random rnd;

        //(`termek_min_id`, `termek_kiszerel`, `user_id`, `beszerzes_mennyiseg`, `beszerzes_datum`, 
        //`beszerzes_megrendelt`, `beszerzes_teljesites`, `beszerzes_modosit`, `beszerzes_erveny`)

        public static List<string> createordering(List<string[]> tempStore, List<string[]> tempRequests)
        {
            listOfRecords = new List<string>();
            for (int i = 0; i < tempStore.Count; i++)
            {
                int value = 0;
                for (int j = 0; j < tempRequests.Count; j++)    //counting together, how much is requested
                {
                    if (tempRequests[j][0] == tempStore[i][0] &&
                        tempRequests[j][1] == tempStore[i][1])
                    {
                        value += Convert.ToInt32(tempRequests[j][2]);
                    }
                }
                value += Convert.ToInt32(tempStore[i][2]);  //adding the amount of store
                string row = "";
                row += "(" + tempStore[i][0] + ", ";    //the product
                row += tempStore[i][1] + ", ";  //the stripping
                row += "3, ";                   //who ordered
                row += value.ToString() + ", "; //the amount
                row += "'2017-12-12', ";        //ordering start
                row += "1, ";                   //shows, it is already ordered
                row += "'2017-12-23', ";        //ordering arrives
                row += "3, ";                   //who receive
                row += "0)";
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
