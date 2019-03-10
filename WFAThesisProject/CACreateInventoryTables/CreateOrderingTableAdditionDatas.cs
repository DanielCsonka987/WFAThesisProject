using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACreateInventoryQuantityTable
{
    class CreateOrderingTableAdditionDatas
    {
        private static Random rnd;
        private static List<string> listOfRecords;


        // (`beszerzes_id`, `termek_quant_id`, `user_id`, `beszerzes_mennyiseg`, `beszerzes_datum`," +
        //  " `beszerzes_teljesites`, `beszerzes_modosit`, `beszerzes_erveny`)

        public static List<string> createorderingadditon(List<string[]> tempStoreContent, int recordAmount)
        {
        listOfRecords = new List<string>();
            rnd = new Random();
            for (int i = 0; i < recordAmount; i++)
            {
                int strictProduct = rnd.Next(1, 143);   //it creates which random striping is about the ordering
                string row = "";
                row += "(" + tempStoreContent[strictProduct][0] + ", ";   //the product DB stripping ID -> 
                                        //refers to 'termek_min_id', 'termek_kiszerel' and 'beszallito_id'
                row += "3, ";                   //who wants order that
                row += rnd.Next(1,30).ToString() + ", "; //the amountrandom
                row += "'2017-11-12', ";        //record start
                row += "'2017-12-";             //ordering arrives
                row += rnd.Next(1, 31).ToString() + "', ";    //the day of the arriving

                row += "3, ";                   //who made the last modification

                int stateDef = rnd.Next(0,5);
                row += stateDef == 0 ? "0)" :    //cancelled order by store-keeper
                            (stateDef == 1 ?  "1)" :  //active, not ordered
                                (stateDef == 2 ? "2)" :   //active, ordered
                                    (stateDef == 3 ? "4)" :     //not arrived till deadline, still waiting
                                                    "5)"   //nor arrived till deadline, cancelled by storekeeper
                                                        )));   //nor arrived till deadline, cancelled by subcontractor
                row += (i + 1 == recordAmount) ? ";" : ",";
                listOfRecords.Add(row);

            }
            return listOfRecords;
        }
    }
}
