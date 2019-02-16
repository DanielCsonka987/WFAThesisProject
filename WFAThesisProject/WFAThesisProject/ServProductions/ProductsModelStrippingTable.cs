using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    class ProductsModelStrippingTable
    {
        private InterfaceMySQLStartDBConnect startDB;
        private InterfaceMySQLDBChannel mdi;
        private List<KeyValuePair<string, string>> parameters;

        public ProductsModelStrippingTable(UserConnDetails dbci, Form parent)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci, parent);
        }

        #region selectors
        //prepared
        private string queryBarcodeIsUnique = "SELECT COUNT(termek_kod) FROM raktmennyiseg WHERE termek_kod=@kod";
        /// <summary>
        /// checks out in 'raktmennyiseg' table the uniquity of barcode
        /// </summary>
        /// <param name="text">barcode that is needed with store the product</param>
        /// <returns>result of seeking - true already exists / false unique barcode</returns>
        public bool checkBarcodeUniquity(string text)
        {
            try
            {
                KeyValuePair<string, string> seekBarcode = new KeyValuePair<string, string>("@kod", text);
                mdi.openConnection();
                string result = mdi.execPrepScalarQueryInStringWithKVP(queryBarcodeIsUnique, seekBarcode);
                mdi.closeConnection();
                if (result == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceProdBarcodeSeek("Adatbázis felé a kérés megalkotása siekrtelen (ModProdBar) "
                    + e.Message);
            }
        }

        #endregion

        #region the table changers
        //prepared
        private string queryProductsNewRowQuantity =
            "INSERT INTO raktmennyiseg (termek_min_id, termek_kod, termek_kiszerel, termek_mennyiseg, termek_hely," +
            " termek_medatum, termek_memodosit, termek_meerveny) VALUES" +
            " (@termekId, @kod, @kiszerel, @mennyi, @hely, CURDATE(), @userId, 1)";
        /// <summary>
        /// create new reocord in 'raktmennyiseg' table
        /// </summary>
        /// <param name="modif">set of ProductionPartRow is needed to create</param>
        public void createNewProdQuantityRecord(ProductStrippingPart newRow, string userId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> recordId = new KeyValuePair<string, string>("@termekId", newRow.productIndex.ToString());
                KeyValuePair<string, string> barcode = new KeyValuePair<string, string>("@kod", newRow.productBarcode);
                KeyValuePair<string, string> stripping = new KeyValuePair<string, string>("@kiszerel", newRow.productStripping.ToString());
                KeyValuePair<string, string> quantity = new KeyValuePair<string, string>("@mennyi", newRow.productQuantity.ToString());
                KeyValuePair<string, string> placeing = new KeyValuePair<string, string>("@hely", newRow.productPlace);
                KeyValuePair<string, string> who = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(recordId);
                parameters.Add(barcode);
                parameters.Add(stripping);
                parameters.Add(quantity);
                parameters.Add(placeing);
                parameters.Add(who);
            }
            catch (Exception e)
            {
                throw new ErrorServiceNewRecord("Adatbátzis felé a kérés megalkotása sikertelen (ModProdQualNewRec): " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryProductsNewRowQuantity, parameters, 6);
            mdi.closeConnection();
        }
        //prepared
        private string queryProductsModifyRowQuantity =
            "UPDATE raktmennyiseg SET termek_kod=@kod, termek_kiszerel=@ujKiszerel, termek_mennyiseg=@mennyiseg," +
            " termek_hely=@hely, termek_medatum=CURDATE(), termek_memodosit=@userId, termek_meerveny=1" +
            " WHERE termek_min_id=@termekId AND termek_kiszerel=@regiKiszerel";
        /// <summary>
        /// modify a record in 'raktmennyiseg' table with ProductPartRow - index the definiton which
        /// </summary>
        /// <param name="modifRow">set of ProductPartElement with the new paramteres, index is remains!</param>
        public void modifyProdQuantityRecord(ProductStrippingPart modifRow, string oldStr, string userId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();

                KeyValuePair<string, string> barcode = new KeyValuePair<string, string>("@kod", modifRow.productBarcode);
                KeyValuePair<string, string> newStrip = new KeyValuePair<string, string>("@ujKiszerel", modifRow.productStripping.ToString());
                KeyValuePair<string, string> quantity = new KeyValuePair<string, string>("@mennyiseg", modifRow.productQuantity.ToString());
                KeyValuePair<string, string> recordId = new KeyValuePair<string, string>("@termekId", modifRow.productIndex.ToString());
                KeyValuePair<string, string> recordOldStrip = new KeyValuePair<string, string>("@regiKiszerel", oldStr);
                KeyValuePair<string, string> placeing = new KeyValuePair<string, string>("@hely", modifRow.productPlace);
                KeyValuePair<string, string> who = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(barcode);
                parameters.Add(newStrip);
                parameters.Add(quantity);
                parameters.Add(recordId);
                parameters.Add(placeing);
                parameters.Add(recordOldStrip);
                parameters.Add(who);
            }
            catch (Exception e)
            {
                throw new ErrorServiceUpdateRecord("Adatbátzis felé a kérés megalkotása sikertelen (ModProdModRec): " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryProductsModifyRowQuantity, parameters, 7);
            mdi.closeConnection();
        }
        //prepared
        private string queryProductDeleteRowQuantity =
            "UPDATE raktmennyiseg SET termek_medatum=CURDATE(), termek_memodosit=@userId, termek_meerveny=0" +
            " WHERE termek_min_id=@termekId AND termek_kiszerel=@kiszerel";
        /// <summary>
        /// delete a record in 'raktmennyiseg'
        /// </summary>
        /// <param name="indexOfRec">the record definition, which</param>
        /// <param name="userId">the id who did it</param>
        public void deleteProdQuantityRecord(string indexOfRec, string kiszerel, string userId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> recordInex = new KeyValuePair<string, string>("@termekId", indexOfRec);
                KeyValuePair<string, string> recordStrip = new KeyValuePair<string, string>("@kiszerel", kiszerel);
                KeyValuePair<string, string> who = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(recordInex);
                parameters.Add(recordStrip);
                parameters.Add(who);
            }
            catch (Exception e)
            {
                throw new ErrorServiceDeleteRecord("Adatbátzis felé a kérés megalkotása sikertelen (ModProdDelRec): " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryProductDeleteRowQuantity, parameters, 3);
            mdi.closeConnection();
        }
        //prepared
        private string queryProductRenewRowQuantity =
            "UPDATE raktmennyiseg SET termek_medatum=CURDATE(), termek_memodosit=@userId, termek_meerveny=1" +
            " WHERE termek_min_id=@termekId AND termek_kiszerel=@kiszerel";
        private string queryProductCheckOutItsQualityIsActive = 
            "SELECT COUNT(*) FROM raktminoseg WHERE termek_min_id=@termekId AND termek_mierveny=0";
        private string queryProductRenewQualityOfQunatity =
            "UPDATE raktminoseg SET termek_midatum=CURDATE(), termek_mimodosit=@userId, termek_mierveny=1" +
            " WHERE termek_min_id=@termekId";
        /// <summary>
        /// re-activate a record in 'raktmennyiseg' and checks out if the quality part is active -> if not activates
        /// </summary>
        /// <param name="indexOfRec">the record definition, which</param>
        /// <param name="strippingRec">the record stripping, which directly</param>
        /// <param name="userId">who made the change</param>
        public void renewProdQuantityRecord(string indexOfRec, string strippingRec, string userId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> recordInex = new KeyValuePair<string, string>("@termekId", indexOfRec);
                KeyValuePair<string, string> recordStrip = new KeyValuePair<string, string>("@kiszerel", strippingRec);
                KeyValuePair<string, string> who = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(recordInex);
                parameters.Add(recordStrip);
                parameters.Add(who);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRenewRecord("Adatbátzis felé a kérés megalkotása sikertelen (ModProdRenewRec1): " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryProductRenewRowQuantity, parameters, 3);
            string result = mdi.execPrepScalarQueryInStringWithKVP(queryProductCheckOutItsQualityIsActive,
                parameters[0]);
            if (result != "0")
            {
                try
                {
                    parameters.RemoveAt(1);
                }
                catch (Exception e)
                {
                    throw new ErrorServiceRenewRecord("Adatbátzis minőségi elem frissítése sikertelen (ModProdRenewRec2): " + e.Message);
                }
                mdi.execPrepDMQueryWithKVPList(queryProductRenewQualityOfQunatity, parameters, 2);
            }
            mdi.closeConnection();
        }

        #endregion
    }
}
