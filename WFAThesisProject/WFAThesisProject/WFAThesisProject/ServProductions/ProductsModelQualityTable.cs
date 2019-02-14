using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    class ProductsModelQualityTable
    {
        private InterfaceMySQLStartDBConnect startDB;
        private InterfaceMySQLDBChannel mdi;
        private List<KeyValuePair<string, string>> parameters;

        public ProductsModelQualityTable(UserConnDetails dbci, Form parent)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci, parent);
        }

        #region the table changers
        //prepared
        private string queryProductsNewRowQuality =
            "INSERT INTO raktminoseg (termek_nev, beszallito_id, termek_leir, termek_egyseg, termek_veszely," +
            " termek_biztons, termek_midatum, termek_mimodosit, termek_mierveny)" +
            " VALUES (@nev, @beszallito, @leiras, @menyegys, @veszely, @adatlap, CURDATE(), @userId, 1)";
        /// <summary>
        /// create new reocord in 'raktminoseg' table
        /// </summary>
        /// <param name="modif">set of ProductionPartRow is needed to create</param>
        public void createNewProdQualityRecord(ProductQualityPart row, string userId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> name = new KeyValuePair<string, string>("@nev", row.productName);
                KeyValuePair<string, string> subcon = new KeyValuePair<string, string>("@beszallito", row.productSubcontr);
                KeyValuePair<string, string> descr = new KeyValuePair<string, string>("@leiras", row.productDescr);
                KeyValuePair<string, string> unit = new KeyValuePair<string, string>("@menyegys", row.productQantUnit);
                KeyValuePair<string, string> dange = new KeyValuePair<string, string>("@veszely", row.productDanger.ToString());
                KeyValuePair<string, string> sheet = new KeyValuePair<string, string>("@adatlap", row.productSheet);
                KeyValuePair<string, string> who = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(name);
                parameters.Add(subcon);
                parameters.Add(descr);
                parameters.Add(dange);
                parameters.Add(sheet);
                parameters.Add(unit);
                parameters.Add(who);
            }
            catch (Exception e)
            {
                throw new ErrorServiceNewRecord("Adatbátzis felé a kérés megalkotása sikertelen (ModProdQualNewRec): " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryProductsNewRowQuality, parameters, 7);
            mdi.closeConnection();
        }
        //prepared
        private string queryProductsModifyRowQuality =
            "UPDATE raktminoseg SET termek_nev=@nev, beszallito_id=@beszallito, termek_leir=@leiras, termek_egyseg=@menyegyseg," +
            " termek_veszely=@veszely, termek_biztons=@adatlap, termek_midatum=CURDATE(), termek_mimodosit=@userId, termek_mierveny=1" +
            " WHERE termek_min_id=@termekId";
        /// <summary>
        /// modify a record in 'raktminoseg' table with ProductPartRow - index the definiton which
        /// </summary>
        /// <param name="modif">set of ProductPartElement with the new paramteres, index is remains!</param>
        public void modifyProdQualityRecord(ProductQualityPart modif, string userId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> id = new KeyValuePair<string, string>("@termekId", modif.productIndex.ToString());
                KeyValuePair<string, string> name = new KeyValuePair<string, string>("@nev", modif.productName);
                KeyValuePair<string, string> subcon = new KeyValuePair<string, string>("@beszallito", modif.productSubcontr);
                KeyValuePair<string, string> descr = new KeyValuePair<string, string>("@leiras", modif.productDescr);
                KeyValuePair<string, string> unit = new KeyValuePair<string, string>("@menyegyseg", modif.productQantUnit);
                KeyValuePair<string, string> sheet = new KeyValuePair<string, string>("@adatlap", modif.productSheet);
                KeyValuePair<string, string> dange = new KeyValuePair<string, string>("@veszely", modif.productDanger.ToString());
                KeyValuePair<string, string> who = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(id);
                parameters.Add(name);
                parameters.Add(subcon);
                parameters.Add(descr);
                parameters.Add(unit);
                parameters.Add(sheet);
                parameters.Add(dange);
                parameters.Add(who);
            }
            catch (Exception e)
            {
                throw new ErrorServiceUpdateRecord("Adatbátzis felé a kérés megalkotása sikertelen (ModProdQualModRec): " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryProductsModifyRowQuality, parameters, 8);
            mdi.closeConnection();
        }
        //prepared
        private string queryProductDeletRowQuantity =
            "UPDATE raktminoseg SET termek_midatum=CURDATE(), termek_mierveny=0, termek_mimodosit=@userId WHERE termek_min_id=@termekId";
        private string queryProductDeletStripOfQuality =
            "UPDATE raktmennyiseg SET termek_medatum=CURDATE(), termek_meerveny=0, termek_memodosit=@userId WHERE termek_min_id=@termekId";
        /// <summary>
        /// delete a record in 'raktminoseg'
        /// </summary>
        /// <param name="indexOfRec">the record definition, which</param>
        /// <param name="userId">the id who did it</param>
        public void deleteProdQualityRecord(string indexOfRec, string userId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> recordInex = new KeyValuePair<string, string>("@termekId",indexOfRec);
                KeyValuePair<string, string> who = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(recordInex);
                parameters.Add(who);
            }
            catch (Exception e)
            {
                throw new ErrorServiceDeleteRecord("Adatbátzis felé a kérés megalkotása sikertelen (ModProdQualDelRec): " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryProductDeletRowQuantity, parameters, 2);
            mdi.execPrepDMQueryWithKVPList(queryProductDeletStripOfQuality, parameters, 2);
            mdi.closeConnection();
        }
        //prepared
        private string queryProductRenewRowQuality =
            "UPDATE raktminoseg SET termek_midatum=CURDATE(), termek_mierveny=1, termek_mimodosit=@userId WHERE termek_min_id=@termekId";
        /// <summary>
        /// re-activate a record in 'raktminoseg'
        /// </summary>
        /// <param name="indexOfRec">the record definition, which</param>
        public void renewProdQualityRecord(string indexOfRec, string userId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> recordInex = new KeyValuePair<string, string>("@termekId", indexOfRec);
                KeyValuePair<string, string> who = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(recordInex);
                parameters.Add(who);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRenewRecord("Adatbátzis felé a kérés megalkotása sikertelen (ModProdQualRenewRec): " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryProductRenewRowQuality, parameters, 2);
            mdi.closeConnection();
        }

        #endregion

    }
}
