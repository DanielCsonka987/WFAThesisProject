using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACreateInventoryQuantityTable
{
    class CreateRequirementTableDatas
    {
        private static Random rnd;
        private static List<string> listOfRecords;
        private static string[] digits = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12",
        "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "28", "30"};

        //(`keres_datum`, `termek_min_id`, `termek_kiszerel`, `user_id`, `keres_mennyiseg`, " +
        //  "`keres_teljesit`, `keres_modosit`, `keres_erveny`)

        public static List<string> createrequirements(int amount, List<string[]> tempDatas )
        {
            listOfRecords = new List<string>();
            int actTempObject;
            string whoAsked = "";
            rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                string row = "";
                actTempObject = rnd.Next(0, tempDatas.Count);  //choose a random row from temp to create a spec record
                string[] dates = giveADatePair();
                whoAsked = rnd.Next(0, 2) == 1 ? "6" : "8";     //here these are the two test-user, random choosing

                row = "('" + dates[0] + "', ";                  //gives the id and a startdate
                row += tempDatas[actTempObject][0] + ", ";      //gives the stripping recordId
                row += whoAsked + ", ";                         //who asked that                    
                row += rnd.Next(1, 30) + ", ";                   //gives an amount

                int recordState = rnd.Next(0, 10);
                row += recordState < 6 ? "'" + dates[1] + "', 3, 2)" :    //case of given out, so it is "historic,fullfiled" - 70%
                                                     // - 30% no date, special case
                    (recordState == 7 || recordState == 8  ? "'', 0, 1)" :   //still active, under process, no 2nd date - 20%
                                (rnd.Next(0, 10) > 5 ? "''," + whoAsked + ", 0)" :  //it called-off by requester - 5 %
                                                        "'', 3, 3)"));      //it cancelled directly by store-keeper - 5%


                row += (i + 1 == amount) ? ";" : ",";
                listOfRecords.Add(row);
  
            }

            return listOfRecords;
        }

        private static string[] giveADatePair()
        {
            string[] dates = new string[2];
            string trunk = rnd.Next(2018, 2020).ToString() + "-" + digits[rnd.Next(0, 12)] + "-";
            int day = rnd.Next(1, 30);
            dates[0] = trunk + digits[day-1];
            dates[1] = trunk + digits[day];
            return dates;
        }
    }
}
