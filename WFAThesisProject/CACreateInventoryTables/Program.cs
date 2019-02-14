using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACreateInventoryQuantityTable
{
    class Program
    {
        private static List<string[]> tempStoreContent;
        private static List<string[]> tempRequestsContent;
        private static StreamWriter str;
        private static List<string> theList;

        private static string[] infosForQuantity = { "recordsOfQuantity.txt",
            "INSERT INTO raktmennyiseg (`termek_min_id`,`termek_kod`, `termek_kiszerel`, " +
                 "`termek_mennyiseg`,`termek_hely`, `termek_medatum`, `termek_memodosit`, `termek_meerveny`) VALUES "};
        private static string[] infoForRequir = { "recordsOfRequirments.txt",
            "INSERT INTO keresek (`keres_datum`, `termek_min_id`, `termek_kiszerel`, `user_id`, `keres_mennyiseg`, " +
                "`keres_teljesit`, `keres_modosit`, `keres_erveny`) VALUES "};
        private static string[] infoForOrder = { "recordOfOrdering.txt",
            "INSERT INTO beszerzes (`termek_min_id`, `termek_kiszerel`, `user_id`, `beszerzes_mennyiseg`," +
                " `beszerzes_datum`, `beszerzes_megrendelt`, `beszerzes_teljesites`, `beszerzes_modosit`," +
                " `beszerzes_erveny`) VALUES " };

        static void Main(string[] args)
        {   //these tables are attached to each oter - they user the same 'raktmennyiseg' table
            createTheSpecificTableRecords(tablesType.QUANTITY, infosForQuantity);
            createTheSpecificTableRecords(tablesType.REQUIR, infoForRequir);
            createTheSpecificTableRecords(tablesType.ORDER, infoForOrder);
            Console.ReadKey();
        }

        private enum tablesType { QUANTITY, REQUIR, ORDER};

        private static void createTheSpecificTableRecords(tablesType actMode, string[] sideDatas)
        {
            try
            {
                if (actMode == tablesType.QUANTITY)
                {
                    theList = CreateQuantityTableDatas.createrecords(142, 4);
                    tempStoreContent = getTheSpecificIndexStrippingsAmounts(theList);
                    
                }
                else if (actMode == tablesType.REQUIR)
                {
                    theList = CreateRequirementTableDatas.createrequirements(100, tempStoreContent);
                    tempRequestsContent = getTheContentOfRequests(theList);
                }
                else if (actMode == tablesType.ORDER)
                    theList = CreateOrderingTableDatas.createordering(tempStoreContent, tempRequestsContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("Tábla-alkotási hiba " + e.Message);
            }
            try
            {
                str = new StreamWriter(sideDatas[0]);
                str.WriteLine(sideDatas[1]);
                foreach (string s in theList)
                {
                    str.WriteLine(s);
                }
                Console.WriteLine("Tesztadatok elkészültek");
            }
            catch (Exception e)
            {
                Console.WriteLine("Tábla kiírási hiba " + e.Message);
            }
            finally
            {
                str.Close();
            }
        }

        private static List<string[]> getTheSpecificIndexStrippingsAmounts(List<string> main)
        {
            List<string[]> result = new List<string[]>();
            foreach (string s in main)
            {
                string[] neededFields = new string[3];
                string[] parts = s.Split(',');
                neededFields[0] = parts[0].Substring(1);    //id
                neededFields[1] = parts[2].Substring(1);    //stripping
                neededFields[2] = parts[3].Substring(1);    //amount
                result.Add(neededFields);
            }
            return result;
        }


        private static List<string[]> getTheContentOfRequests(List<string> main)
        {
            List<string[]> result = new List<string[]>();
            foreach (string s in main)
            {
                string[] neededFields = new string[3];
                string[] parts = s.Split(',');
                if (parts[5].Length > 2)
                {
                    neededFields[0] = parts[1].Substring(1);    //id
                    neededFields[1] = parts[2].Substring(1);    //stripping
                    neededFields[2] = parts[4].Substring(1);    //amount
                }
                result.Add(neededFields);
            }
            return result;
        }

    }
}
