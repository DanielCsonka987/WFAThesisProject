using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.GeneralExceptions;

namespace WFAThesisProject.ServRequests
{
    class RequestsModelReadIn
    {
        private InterfaceMySQLStartDBConnect startDb;
        private InterfaceMySQLDBChannel mdi;

        private List<string[]> resultUsers;     //doubltly change durring the program-running

        public RequestsModelReadIn(UserConnDetails dbci, Form parent)
        {
            startDb = new InterfaceMySQLStartDBConnect();
            mdi = startDb.kapcsolodas(dbci, parent);
        }
        //tested
        #region readIn active requests
        private string queryGetRequestsActive =
            "SELECT keresek.keres_datum, raktminoseg.termek_min_id, keresek.termek_quant_id, raktminoseg.termek_nev," +
            " raktmennyiseg.termek_kiszerel, raktmennyiseg.termek_hely, raktminoseg.termek_egyseg, felhasznadatok.vez_nev," +
            " felhasznadatok.ker_nev, felhasznadatok.terulet, keresek.keres_mennyiseg, keresek.keres_modosit, keresek.user_id," +
            " raktminoseg.beszallito_id, keresek.keres_id" +
            " FROM keresek, felhasznadatok, raktminoseg, raktmennyiseg" +
            " WHERE felhasznadatok.user_id = keresek.user_id AND raktmennyiseg.termek_quant_id = keresek.termek_quant_id" +
            " AND raktmennyiseg.termek_min_id = raktminoseg.termek_min_id" +
            " AND keresek.keres_erveny=1";
        /// <summary>
        /// reads in the active requests
        /// </summary>
        /// <returns>Kist of RecordActive container</returns>
        public List<RequestRecordActive> getActiveRequests()
        {
            mdi.openConnection();
            List<string[]> result = mdi.executeQueryGetStringArrayListOfRows(queryGetRequestsActive);
            resultUsers = mdi.executeQueryGetStringArrayListOfRows(queryGetThePoolOfUsersWhoModifyedRecord);
            mdi.closeConnection();
            List<RequestRecordActive> rows = new List<RequestRecordActive>();
            try
            {
                foreach (string[] rec in result)
                {
                    rows.Add(convertNormRecord(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceCreateDataList("Kérések adatlista megalkotása sikertelen (ModReqNorm) "+ e.Message);
            }

            return rows;
        }
        /// <summary>
        /// part of the reader method of active requests - converts the string[] into RequestActive type
        /// </summary>
        /// <param name="rec">the string[] is needed to convert</param>
        /// <returns>the RecordActive containger</returns>
        private RequestRecordActive convertNormRecord(string[] rec)
        {
            RequestRecordActive rrac = new RequestRecordActive();
            rrac.keresDatum = rec[0].Substring(0, 10);
            rrac.termekId = Convert.ToInt32(rec[1]);
            rrac.termekQuantId = Convert.ToInt32(rec[2]);
            rrac.termekNev = rec[3];
            rrac.termekKiszerel = Convert.ToInt32(rec[4]);
            rrac.termekHely = rec[5];
            rrac.termekKiszerelEgys = rec[6];

            rrac.userKeroNev = rec[7] + " " + rec[8];
            rrac.userTerulet = rec[9];
            rrac.keresMennyiseg = Convert.ToInt32(rec[10]);
            foreach (string[] u in resultUsers)
            {
                if (u[0] == rec[11])
                {
                    rrac.keresModosNev = u[1] + " " + u[2];
                }
            }
            rrac.userId = Convert.ToInt32(rec[12]);
            rrac.termekBeszall = rec[13];
            rrac.keresId = Convert.ToInt32(rec[14]);
            return rrac;
        }
        #endregion
        //tested
        #region readIn calledOff requests by the orderer
        private string queryGetRequestsCalledOff =  //the orderer cancelled it
            "SELECT keresek.keres_datum, raktmennyiseg.termek_min_id, raktminoseg.termek_nev, keresek.termek_quant_id," +
            " raktmennyiseg.termek_kiszerel, raktminoseg.termek_egyseg, felhasznadatok.vez_nev, felhasznadatok.ker_nev," +
            " felhasznadatok.terulet, keresek.keres_mennyiseg, raktminoseg.beszallito_id, keresek.keres_id" +
            " FROM keresek, felhasznadatok, raktminoseg, raktmennyiseg " +
            " WHERE felhasznadatok.user_id = keresek.user_id AND keresek.termek_quant_id = raktmennyiseg.termek_quant_id" +
            " AND raktmennyiseg.termek_min_id = raktminoseg.termek_min_id" +
            " AND keresek.keres_erveny=0 AND keresek.keres_teljesit = 0 AND keresek.user_id = keresek.keres_modosit";
        /// <summary>
        /// reads in the calledoff requests
        /// </summary>
        /// <returns>list of CalledOf container</returns>
        public List<RequestRecordCalledOff> getCalledOffRequests()
        {
            mdi.openConnection();
            List<string[]> result = mdi.executeQueryGetStringArrayListOfRows(queryGetRequestsCalledOff);
            mdi.closeConnection();
            List<RequestRecordCalledOff> rows = new List<RequestRecordCalledOff>();
            try
            {
                foreach (string[] rec in result)
                {
                    rows.Add(convertCalledOffRecord(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceCreateDataList("Kérések adatlista megalkotása sikertelen (ModReqCalledOff) " + e.Message);
            }

            return rows;
        }
        /// <summary>
        /// part of the reader method of the called off requersts - convert the string[] into RequestCalledOff type
        /// </summary>
        /// <param name="rec">string[] that needed to convert</param>
        /// <returns>RequestCalledOff container</returns>
        private RequestRecordCalledOff convertCalledOffRecord(string[] rec)
        {
            RequestRecordCalledOff rrco = new RequestRecordCalledOff();
            rrco.keresDatum = rec[0].Substring(0, 10);
            rrco.termekId = Convert.ToInt32(rec[1]);
            rrco.termekNev = rec[2];
            rrco.termekQuantId = Convert.ToInt32(rec[3]);
            rrco.termekKiszerel = Convert.ToInt32(rec[4]);
            rrco.termKiszerelEgys = rec[5];
            rrco.userKeroNev = rec[6] + " " + rec[7];
            rrco.userTerulet = rec[8];
            rrco.keresMennyiseg = Convert.ToInt32(rec[9]);
            rrco.termekBeszall = rec[10];
            rrco.keresId = Convert.ToInt32(rec[11]);
            return rrco;
        }
        #endregion
        //tested
        #region readIn givenOut requests
        private string queryGetRequestsGivenOut = //important, who given that out
            "SELECT keresek.keres_datum, raktmennyiseg.termek_min_id, raktminoseg.termek_nev, keresek.termek_quant_id," +
            " raktmennyiseg.termek_kiszerel, raktmennyiseg.termek_hely, raktminoseg.termek_egyseg, felhasznadatok.vez_nev," +
            " felhasznadatok.ker_nev, felhasznadatok.terulet, keresek.keres_mennyiseg, keresek.keres_teljesit," +
            " keresek.keres_modosit, keresek.user_id, raktminoseg.beszallito_id, keresek.keres_id" + 
            " FROM keresek, felhasznadatok, raktminoseg, raktmennyiseg" +
            " WHERE felhasznadatok.user_id = keresek.user_id AND keresek.termek_quant_id = raktmennyiseg.termek_quant_id" +
            " AND raktmennyiseg.termek_min_id = raktminoseg.termek_min_id" +
            " AND keresek.keres_erveny= 2 AND keresek.keres_teljesit > 0";
        /// <summary>
        /// read in the given out requests
        /// </summary>
        /// <returns>list of RequestGivenOut containers</returns>
        public List<RequestRecordGivenOut> getGivenOutRequests()
        {
            mdi.openConnection();
            List<string[]> result = mdi.executeQueryGetStringArrayListOfRows(queryGetRequestsGivenOut);
            resultUsers = mdi.executeQueryGetStringArrayListOfRows(queryGetThePoolOfUsersWhoModifyedRecord);
            mdi.closeConnection();
            List<RequestRecordGivenOut> rows = new List<RequestRecordGivenOut>();
            try
            {
                foreach (string[] rec in result)
                {
                    rows.Add(convertGivenOutRecord(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceCreateDataList("Kérések adatlista megalkotása sikertelen (ModReqGivenOut) " + e.Message);
            }

            return rows;
        }
        /// <summary>
        /// part of the read in given out requests method - converts string[] into RequestGivenOut type
        /// </summary>
        /// <param name="rec">the string[] that is needed to convert</param>
        /// <returns>requestGivenOut containter</returns>
        private RequestRecordGivenOut convertGivenOutRecord(string[] rec)
        {
            RequestRecordGivenOut rrgo = new RequestRecordGivenOut();
            rrgo.keresDatum = rec[0].Substring(0, 10);
            rrgo.termekId = Convert.ToInt32(rec[1]);
            rrgo.termekNev = rec[2];
            rrgo.termekQuantId = Convert.ToInt32(rec[3]);
            rrgo.termekKiszerel = Convert.ToInt32(rec[4]);
            rrgo.termekHely = rec[5];
            rrgo.termeKiszerelEgys = rec[6];
            rrgo.userKeroNev = rec[7] + " " + rec[8];
            rrgo.userTerulet = rec[9];
            rrgo.keresMennyiseg = Convert.ToInt32(rec[10]);
            rrgo.teljesites = rec[11].Substring(0, 10);
            foreach (string[] u in resultUsers)
            {
                if (u[0] == rec[12])
                {
                    rrgo.keresModosNev = u[1] + " " + u[2];
                }
            }
            rrgo.userId = Convert.ToInt32(rec[13]);
            rrgo.termekBeszall = rec[14];
            rrgo.keresId = Convert.ToInt32(rec[15]);
            return rrgo;
        }
        #endregion
        //tested
        #region readIn Direct deleted requests by the store-keeper
        private string quersGetRequestsDierctDeleted=    //important, who deleted
            "SELECT keresek.keres_datum, raktmennyiseg.termek_min_id, raktminoseg.termek_nev, keresek.termek_quant_id," +
            " raktmennyiseg.termek_kiszerel, raktminoseg.termek_egyseg, felhasznadatok.vez_nev, felhasznadatok.ker_nev," +
            " felhasznadatok.terulet, keresek.keres_mennyiseg, keresek.keres_modosit, keresek.user_id," +
            " raktminoseg.beszallito_id, keresek.keres_id" +
            " FROM keresek, felhasznadatok, raktminoseg, raktmennyiseg" +
            " WHERE felhasznadatok.user_id = keresek.user_id AND keresek.termek_quant_id = raktmennyiseg.termek_quant_id" +
            " AND raktmennyiseg.termek_min_id = raktminoseg.termek_min_id" +
            " AND keresek.keres_erveny=3 AND keresek.keres_teljesit = 0";
        /// <summary>
        /// read in the direct deleted requests
        /// </summary>
        /// <returns>list of RequestDeketed type</returns>
        public List<RequestRecordDeleted> getDeletedRequests()
        {
            mdi.openConnection();
            List<string[]> result = mdi.executeQueryGetStringArrayListOfRows(quersGetRequestsDierctDeleted);
            resultUsers = mdi.executeQueryGetStringArrayListOfRows(queryGetThePoolOfUsersWhoModifyedRecord);
            mdi.closeConnection();
            List<RequestRecordDeleted> rows = new List<RequestRecordDeleted>();
            try
            {
                foreach (string[] rec in result)
                {
                    rows.Add(convertDeletedRecord(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceCreateDataList("Kérések adatlista megalkotása sikertelen (ModReqDel) " + e.Message);
            }

            return rows;
        }
        /// <summary>
        /// part of the deleted request by the store-keeper - converts the string[] into RequsestDeleted type
        /// </summary>
        /// <param name="rec">string[] that is needed to convert</param>
        /// <returns>RequestDeleted container</returns>
        private RequestRecordDeleted convertDeletedRecord(string[] rec)
        {
            RequestRecordDeleted rrd = new RequestRecordDeleted();
            rrd.keresDatum = rec[0].Substring(0, 10);
            rrd.termekId = Convert.ToInt32(rec[1]);
            rrd.termekNev = rec[2];
            rrd.termekQuantId = Convert.ToInt32(rec[3]);
            rrd.termekKiszerel = Convert.ToInt32(rec[4]);
            rrd.termekKiszerelEgys = rec[5];
            rrd.userKeroNev = rec[6] + " " + rec[7];
            rrd.userTerulet = rec[8];
            rrd.keresMennyiseg = Convert.ToInt32(rec[9]);
            foreach(string[] u in resultUsers)
            {
                if (u[0] == rec[10])
                {
                    rrd.keresModosNev = u[1] + " " + u[2];
                }
            }
            rrd.userId = Convert.ToInt32(rec[11]);
            rrd.termekBeszall = rec[12];
            rrd.keresId = Convert.ToInt32(rec[13]);
            return rrd;
        }
        #endregion

        #region readIn the datas of products - case of modify an active record
        private string queryGetThePoolOfUsersWhoModifyedRecord =
            "SELECT user_id, vez_nev, ker_nev FROM felhasznadatok";
        /// <summary>
        /// reads in the possible users in the system - who made the modify
        /// </summary>
        private string queryReadingInTheProductsListToRenewAnActiveRequest =
            "SELECT termek_min_id, termek_nev, beszallito_id FROM raktminoseg";
        /// <summary>
        /// reads in the products pool - name and its DB id
        /// </summary>
        /// <returns>list of ProductToChoose container</returns>
        public List<ProductToChoose> getThePoolOfProducts()
        {
            mdi.openConnection();
            List<string[]> result = mdi.executeQueryGetStringArrayListOfRows
                (queryReadingInTheProductsListToRenewAnActiveRequest);
            mdi.closeConnection();
            List<ProductToChoose> rows = new List<ProductToChoose>();
            try
            {
                foreach (string[] arr in result)
                {
                    ProductToChoose prod = new ProductToChoose();
                    prod.termekMinId = Convert.ToInt32(arr[0]);
                    prod.termekNev = arr[1];
                    prod.beszallitoId = arr[2];
                    rows.Add(prod);
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceGetTheProdPool
                    ("A termékek körének lekérdezése sikertelen (ModReqProdPool) " + e.Message);
            }
            return rows;
        }

        private string queryReadingInTheStrippingOfTheChosenProductToRenewAcitveRequest =
            "SELECT termek_kiszerel, termek_quant_id, termek_hely FROM raktmennyiseg" +
            " WHERE termek_min_id=@productMinId";
        /// <summary>
        /// reads in the pool of strippings, that a chosen product has
        /// </summary>
        /// <param name="termekId">the target product name</param>
        /// <returns>DB id of tha targeted product</returns>
        public List<StrippingToChoose> getThePoolOfStrippings(string termekId)
        {
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("@productMinId", termekId);
            mdi.openConnection();
            List<string[]> result = mdi.execPrepQueryInListStringArrWithKVP
                (queryReadingInTheStrippingOfTheChosenProductToRenewAcitveRequest, param);
            mdi.closeConnection();
            List<StrippingToChoose> rows = new List<StrippingToChoose>();
            try
            {
                foreach (string[] arr in result)
                {
                    StrippingToChoose strip = new StrippingToChoose();
                    strip.termekKiszerel = Convert.ToInt32(arr[0]);
                    strip.termekQuantId = Convert.ToInt32(arr[1]);
                    strip.termekHely = arr[2];
                    rows.Add(strip);
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceGetTheStripPool
                    ("Az adott termék kiszereléseinek betöltése sikertelen (ModReqStrPool) " + e.Message);
            }
            return rows;
        }
        #endregion

        private string queryGetTHeActualAmountOfStripping =
            "SELECT termek_mennyiseg FROM raktmennyiseg WHERE termek_quant_id=@kiszerelID";
        /// <summary>
        /// read in the specified amount of the chosen product - case of givingOut-getBack process
        /// </summary>
        /// <param name="termekQuantId">the DB id of the target stripping</param>
        /// <returns>DB id of the stripping is needed to modify</returns>
        public int getTheActualAmountOfTheStripping(string termekQuantId)
        {
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("kiszerelID", termekQuantId);
            mdi.openConnection();
            string result = mdi.execPrepScalarQueryInStringWithKVP(queryGetTHeActualAmountOfStripping,param);
            mdi.closeConnection();
            try
            {
                int amount = Convert.ToInt32(result);
                return amount;
            }
            catch (Exception e)
            {
                throw new ErrorServiceGetTheAmount
                    ("A raktári mennyiség lekérdezése sikertelen (ModelRequProdMove) " + e.Message);
            }
            
        }

    }
}
