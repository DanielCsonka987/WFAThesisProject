using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public class ProductsModelReadIn
    {
        private string querySubcontrList = "SELECT beszallito_id FROM beszallito";

        private InterfaceMySQLStartDBConnect startDB;
        private InterfaceMySQLDBChannel mdi;

        private List<ProductFullRow> productQuantityList;
        private List<ProductQualityPart> productQualityList;
        private List<KeyValuePair<string, string>> parameters;

        public ProductsModelReadIn(UserConnDetails dbci, Form parent)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci, parent);
        }

        private string queryProductsFullTableAct =
        "SELECT raktminoseg.termek_nev, raktminoseg.beszallito_id, raktminoseg.termek_leir, raktminoseg.termek_egyseg," +   //0-3
        " raktminoseg.termek_biztons, raktminoseg.termek_veszely, raktminoseg.termek_min_id, raktmennyiseg.termek_quant_id," +     //4-7
        " raktmennyiseg.termek_kiszerel, raktmennyiseg.termek_mennyiseg, raktmennyiseg.termek_kod, raktmennyiseg.termek_hely," +    //8-11
        " raktmennyiseg.termek_medatum, raktmennyiseg.termek_memodosit, raktmennyiseg.termek_meerveny" +    //12-14
        " FROM raktminoseg, raktmennyiseg" +
        " WHERE raktminoseg.termek_min_id = raktmennyiseg.termek_min_id" +
        " AND raktminoseg.termek_mierveny = 1 AND raktmennyiseg.termek_meerveny = 1" +
        " ORDER BY raktminoseg.termek_min_id, raktminoseg.termek_nev, raktmennyiseg.termek_kiszerel";
        private string queryProdtsFullTableDeleted =
        "SELECT raktminoseg.termek_nev, raktminoseg.beszallito_id, raktminoseg.termek_leir, raktminoseg.termek_egyseg," +
        " raktminoseg.termek_biztons, raktminoseg.termek_veszely, raktminoseg.termek_min_id, raktmennyiseg.termek_quant_id," +
        " raktmennyiseg.termek_kiszerel, raktmennyiseg.termek_mennyiseg, raktmennyiseg.termek_kod, raktmennyiseg.termek_hely," +
        " raktmennyiseg.termek_medatum, raktmennyiseg.termek_memodosit, raktmennyiseg.termek_meerveny" +
        " FROM raktminoseg, raktmennyiseg" +
        " WHERE raktminoseg.termek_min_id = raktmennyiseg.termek_min_id" +
        " AND raktmennyiseg.termek_meerveny = 0" +
        " ORDER BY raktminoseg.termek_min_id, raktminoseg.termek_nev, raktmennyiseg.termek_kiszerel";
        /// <summary>
        /// get the content of product datas from DB to List of ProductElement-s
        /// </summary>
        /// <param name="mode">mode of method - true = active / false = deleted</param>
        /// <returns>list of product-elements</returns>
        public List<ProductFullRow> getProductsFullList(bool mode)
        {
            mdi.openConnection();
            List<string[]> tableContent;
            if (mode)
                tableContent = mdi.executeQueryGetStringArrayListOfRows(queryProductsFullTableAct);
            else
                tableContent = mdi.executeQueryGetStringArrayListOfRows(queryProdtsFullTableDeleted);
            mdi.closeConnection();
            try
            {
                productQuantityList = new List<ProductFullRow>();
                foreach (string[] record in tableContent)
                {
                    productQuantityList.Add(fullRecordToListProdFullElem(record));
                }
                return productQuantityList;
            }
            catch (Exception e)
            {
                throw new ErrorServiceCreateDataList("Termékek adtlista megalkotása sikertelen (ModProdList): " + e.Message);
            }
        }
        /// <summary>
        /// part of the product list collector - saves each row
        /// </summary>
        /// <param name="record">string[] of a record</param>
        /// <returns>datas in a single product-element</returns>
        private ProductFullRow fullRecordToListProdFullElem(string[] record)
        {
            ProductFullRow row = new ProductFullRow();

            row.productName = record[0];
            row.productSubcontr = record[1];
            row.productDescr = record[2];
            row.productQantUnit = record[3];
            row.productSheet = record[4];
            row.productDanger = Convert.ToInt32(record[5]);
            row.producQualId = Convert.ToInt32(record[6]);
            row.strippId = Convert.ToInt32(record[7]);
            row.productStripping = Convert.ToInt32(record[8]);
            row.productQuantity = Convert.ToInt32(record[9]);
            row.productBarcode = record[10];
            row.productPlace = record[11];
            row.productModifiedThen = record[12];
            row.productModifiedBy = Convert.ToInt32(record[13]);
            row.productValidity = record[14] == "1" ? true : false;

            return row;
        }
        
        private string queryProductsPartTableAct =
        "SELECT raktminoseg.termek_nev, raktminoseg.beszallito_id, raktminoseg.termek_leir, raktminoseg.termek_egyseg," +   //0-3
        " raktminoseg.termek_biztons, raktminoseg.termek_veszely, raktminoseg.termek_min_id, raktminoseg.termek_mimodosit," +   //4-7
        " raktminoseg.termek_midatum, raktminoseg.termek_mierveny" +    //8-9
        " FROM raktminoseg WHERE raktminoseg.termek_mierveny = 1";
        
        private string queryProductsPartTableDeleted =
            "SELECT raktminoseg.termek_nev, raktminoseg.beszallito_id, raktminoseg.termek_leir, raktminoseg.termek_egyseg," +
            " raktminoseg.termek_biztons, raktminoseg.termek_veszely, raktminoseg.termek_min_id, raktminoseg.termek_mimodosit," +
            " raktminoseg.termek_midatum, raktminoseg.termek_mierveny" +
            " FROM raktminoseg WHERE raktminoseg.termek_mierveny = 0";
        //CAST(datefield as char) as date
        /*
        private string queryProductsPartTableAct =
        "SELECT raktminoseg.termek_nev, raktminoseg.beszallito_id, raktminoseg.termek_leir, raktminoseg.termek_egyseg," +   //0-3
            " raktminoseg.termek_biztons, raktminoseg.termek_veszely, raktminoseg.termek_min_id, raktminoseg.termek_mimodosit," +   //4-7
            " CAST(raktminoseg.termek_midatum as char) as date, raktminoseg.termek_mierveny" +    //8-9
            " FROM raktminoseg WHERE raktminoseg.termek_mierveny = 1";
            */
        /// <summary>
        /// get the content of product datas from DB to List of ProductPartElement-s
        /// from `raktminoseg` table
        /// </summary>
        /// <param name="mode">mode of method - true = active / false = deleted</param>
        /// <returns>list of product-elements</returns>
        public List<ProductQualityPart> getProductsPartList(bool mode)
        {
            mdi.openConnection();
            List<string[]> tableContent;
            if (mode)
                tableContent = mdi.executeQueryGetStringArrayListOfRows(queryProductsPartTableAct);
            else
                tableContent = mdi.executeQueryGetStringArrayListOfRows(queryProductsPartTableDeleted);
            mdi.closeConnection();
            try
            {
                productQualityList = new List<ProductQualityPart>();
                foreach (string[] record in tableContent)
                {
                    productQualityList.Add(recordToListProdPartElem(record));
                }
                return productQualityList;
            }
            catch (Exception e)
            {
                throw new ErrorServiceCreateDataList("Termékek adtlista megalkotása sikertelen (ModProdList): " + e.Message);
            }
        }
        /// <summary>
        /// part of the product list collector - saves each row
        /// </summary>
        /// <param name="record">string[] of a record</param>
        /// <returns>datas in a single product-element</returns>
        private ProductQualityPart recordToListProdPartElem(string[] record)
        {
            ProductQualityPart row = new ProductQualityPart();

            row.productName = record[0];        //name
            row.productSubcontr = record[1];    //subcontr
            row.productDescr = record[2];       //description
            row.productQantUnit = record[3];    //quantity unit
            row.productSheet = record[4];       //datasheet
            row.productDanger = Convert.ToInt32(record[5]); //danger number
            row.productQualId = Convert.ToInt32(record[6]);  //index of table (prim.key)

            row.productModifiedBy = Convert.ToInt32(record[7]); //user_id of profile
            row.productModifiedThen = record[8];                //when changed the record
            row.productValidity = record[9] == "1"? true : false;    //is it activ or passive
            /*if (record[9] == "1")
                row.productValidity = true;
            else
                row.productValidity = false;*/
            return row;
        }

        /// <summary>
        /// gets the all subcontractor from the 'beszallito' table
        /// </summary>
        /// <returns>list of subcontractors 'beszallito_id'</returns>
        public List<string> getSubcontrList()
        {
            mdi.openConnection();
            List<string> list = mdi.executeQueryGetOneFieldToList(querySubcontrList);
            mdi.closeConnection();
            if (list == null)
            {
                throw new ErrorServiceProductGetSubcontr("Beszállítók adatlista megalkotása sikertelen (ModProdListPart)");
            }
            return list;
        }

        //prepared
        private string queryWhoChangedTheRecord = "SELECT vez_nev, ker_nev FROM felhasznadatok WHERE user_id=@userId";
        /// <summary>
        /// gets from any record the user_id, who has deleted it - if it has not 0 here
        /// </summary>
        /// <param name="indexOfUser">index of spec. record</param>
        /// <returns>the name of the user, who deleted</returns>
        public string getWhoModifiedRecord(int indexOfUser)
        {
            string userName = "";
            string[] result;
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> userId = new KeyValuePair<string, string>("@userId", indexOfUser.ToString());
                parameters.Add(userId);
                mdi.openConnection();
                result = mdi.execPrepQueryOneRowInStringArrWithKVPList(queryWhoChangedTheRecord, parameters, 1);
                mdi.closeConnection();
            }
            catch (Exception e)
            {
                mdi.closeConnection();
                throw new ErrorServiceWhoModified("A rekord törlője kereséséhez kérés megalkotása sikertelen (ModProdListQual) "
                    +e.Message);
            }
            if (result == null)
            {
                throw new ErrorServiceWhoModified("A rekord módosítójának visszakeresése sikertelen (ModProdListQual)");
            }
            foreach (string s in result)
                userName += s + " ";
            return userName;
        }
    }
}
