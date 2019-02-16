using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACreateInventoryQuantityTable
{
    class CreateQuantityTableDatas
    {
        private static string[] room = { "I", "II", "III", "IV" };
        private static string[] frame_alphabets = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K" , "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "z"};
        private static int[] shelf = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private static int[] place = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static int[] strippings = { 100, 250, 500, 1000 };
        private static Random rnd = new Random();
        private static List<string> listOfRecords;

        #region part-datas creators and a tester of uniquity
        /// <summary>
        /// creates the list of sql-based datas, to fill in DB easy
        /// </summary>
        /// <param name="amount">full amount of recID</param>
        /// <param name="max">max strippings of products</param>
        /// <returns></returns>
        public static List<string> createrecords(int amount, int max)
        {
            listOfRecords = new List<string>();
            rnd = new Random();
            int counterForStrippID = 1;
            for (int i = 1; i <= amount; i++)
            {
                int range = rnd.Next(1, max);     //number of strippings, randomly
                string row = "";
                for (int j = 0; j < range; j++)     //create each different strippings with same ID
                {
                    row = "(" + counterForStrippID + ", ";  //the general strippings ID = DB primary key
                    row += i.ToString() + ", '";          //id of product
                    row += createABarcode(i) + "', ";    //unique barcode
                    row += strippings[j] + ", ";        //stripping unique in the same ID
                    row += rnd.Next(0, 32) + ", '";    //amount
                    row += createAPlacing() + "', ";    //unique placing
                    row += " '" + createADate(i) + "', ";   //date when altered it last time
                    row += "3, ";                       //specific user, who altered/created it

                    if (rnd.Next(0, 10) < 8)        //=> little chance the stripping is already deleted
                        row += "1)";    //active, used record
                    else
                        row += "0)";    //is deleted

                    if (i == amount && j == (range - 1))
                        row += ";";     //end of the last record
                    else
                        row += ",";     //normal end of the record
                    listOfRecords.Add(row);
                    counterForStrippID++;
                }
            }
            return listOfRecords;
        }

        /// <summary>
        /// creates a barcode - depends on the needs - with each subcontractor has unique standard
        /// </summary>
        /// <param name="id">the ID of record -> type of barcode depend on subcontractor</param>
        /// <returns>the unique barcode</returns>
        private static string createABarcode(int id)
        {
            string result = "";
            do
            {
                if (id < 93)    //till 92, based on needs
                {
                    result = rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() +
                        rnd.Next(0, 10).ToString() + "-" +
                        rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() +
                        frame_alphabets[rnd.Next(0, 26)] + rnd.Next(0, 10).ToString();
                }
                else if (id > 92 && id < 123)   //from 93 and till 122, based on needs
                {
                    result = rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() +
                        rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString()
                        + "-" +
                        rnd.Next(0, 10).ToString() + "-" + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString()
                        + "-" + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString();
                }
                else if (id > 122)      //from 123, based on needs
                {
                    result = frame_alphabets[rnd.Next(0, 26)] + frame_alphabets[rnd.Next(0, 26)] + frame_alphabets[rnd.Next(0, 26)] + "-" +
                        rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString()
                        + rnd.Next(0, 10).ToString() + "-" +
                        rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString() + rnd.Next(0, 10).ToString();
                }
            } while (needReGenPlaceBarc(result));
            return result;

        }
        /// <summary>
        /// creates a placing-code - characterised with the theoretic company's standard
        /// </summary>
        /// <returns></returns>
        private static string createAPlacing()
        {
            string result = "";
            do
            {
                result = room[rnd.Next(0, 4)] + "/" + frame_alphabets[rnd.Next(0, 11)] + "/" + shelf[rnd.Next(0, 12)] +
                    "." + place[rnd.Next(0, 10)];
            } while (needReGenPlaceBarc(result));
            return result;
        }
        /// <summary>
        /// revise the uniquty of the data-part -> barcode or placing-code
        /// </summary>
        /// <param name="res">the created data, is needed to revise</param>
        /// <returns>true = need another / false = good, unique</returns>
        private static bool needReGenPlaceBarc(string res)
        {
            foreach (string s in listOfRecords)
            {
                if (s.IndexOf(res) > 0)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// gives a date, here is the date of theoretic record insertion
        /// </summary>
        /// <param name="i">the ID of record -> characterised by subcontractors</param>
        /// <returns>the date in string</returns>
        private static string createADate(int id)
        {
            string result = "";
            if (id < 93)                //till 92, based on needs
                result = "2017-12-01";
            else if (id > 92 && id < 123)   //from 93 and till 122, based on needs
                result = "2018-01-03";
            else if (id > 122)          //from 123, based on needs
                result = "2018-03-22";
            return result;
        }
        #endregion
    }
}
