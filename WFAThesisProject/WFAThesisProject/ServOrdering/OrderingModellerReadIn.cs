using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.GeneralExceptions;

namespace WFAThesisProject.ServOrdering
{
    class OrderingModellerReadIn
    {
        private InterfaceMySQLDBChannel mdi;
        private InterfaceMySQLStartDBConnect startDB;

        private List<string[]> poolOfUsers;

        public OrderingModellerReadIn(UserConnDetails dbci, Form parentMainWin)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci, parentMainWin);
            getTheUserPoolForTableFilling();
        }

        private string queryForReadInRecords =
            "SELECT beszerzes.beszerzes_id, raktminoseg.termek_nev, raktmennyiseg.termek_quant_id," +
            " raktmennyiseg.termek_kiszerel, felhasznadatok.vez_nev, felhasznadatok.ker_nev," +
            " raktminoseg.beszallito_id, raktmennyiseg.termek_hely, raktmennyiseg.termek_kod," +
            " beszerzes.beszerzes_datum, beszerzes.beszerzes_mennyiseg, " +
            " beszerzes.beszerzes_teljesites, beszerzes.beszerzes_modosit" +
            " FROM raktmennyiseg, raktminoseg, beszerzes, felhasznadatok" +
            " WHERE raktminoseg.termek_min_id = raktmennyiseg.termek_min_id" +
            " AND raktmennyiseg.termek_quant_id = beszerzes.termek_quant_id" +
            " AND felhasznadatok.user_id = beszerzes.user_id" +
            " AND beszerzes.beszerzes_erveny = @erveny";

        #region readIn cancelledOrdering
        /// <summary>
        /// gets the list of OrderingCancelled to show them the user
        /// </summary>
        /// <returns>list of OrderingCancelled</returns>
        public List<OrderingCancelled> getListOfCancelledOrderings()
        {
            List<OrderingCancelled> listCancelled = new List<OrderingCancelled>();
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("@erveny", "0");
            mdi.openConnection();
            List<string[]> rows = mdi.execPrepQueryInListStringArrWithKVP(
                queryForReadInRecords, param);
            mdi.closeConnection();
            try
            {
                foreach (string[] rec in rows)
                {
                    listCancelled.Add(convertCancelledOrdering(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingGetTheCancelledPool("A visszavont rendelések adatlista megalkotása sikertelen (ModOrdNorm) " + e.Message);
            }
            return listCancelled;
        }
        /// <summary>
        /// converter to put the DB record to OrderingCancelled container
        /// </summary>
        /// <param name="rec">DB record</param>
        /// <returns>OrderingCancelled container</returns>
        private OrderingCancelled convertCancelledOrdering(string[] rec)
        {
            OrderingCancelled ocd = new OrderingCancelled();
            ocd.beszerId = Convert.ToInt32(rec[0]);
            ocd.termekNev = rec[1];
            ocd.kiszerelId = Convert.ToInt32(rec[2]);
            ocd.termekKiszer = rec[3];
            ocd.redeloNev = rec[4] + " " + rec[5];
            ocd.termekBeszall = rec[6];
            //no place
            ocd.termekKod = rec[8];
            ocd.beszerzDatum = rec[9].Substring(0, 10);
            ocd.beszerzMennyis = Convert.ToInt32(rec[10]);
            ocd.beszerzLemond = rec[11].Substring(0, 10);
            foreach (string[] user in poolOfUsers)
            {
                if (user[0] == rec[12])
                {
                    ocd.modositNev = user[1] + " " + user[2];
                    break;
                }
            }
            return ocd;
        }

        #endregion

        #region readIn notedOrdering

        /// <summary>
        /// get the list of OrderingNoted to show them the user
        /// </summary>
        /// <returns>list of OrderingNored</returns>
        public List<OrderingNoted> getListOfNotedOrderings()
        {
            List<OrderingNoted> listNote = new List<OrderingNoted>();
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("@erveny", "1");
            mdi.openConnection();
            List<string[]> rows = mdi.execPrepQueryInListStringArrWithKVP(
                queryForReadInRecords, param);
            mdi.closeConnection();
            try
            {
                foreach (string[] rec in rows)
                {
                    listNote.Add(convertNotedOrdering(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingGetTheNotedPool("A előjegyzett rendelések adatlista megalkotása sikertelen (ModOrdNorm) " + e.Message);
            }
            return listNote;
        }
        /// <summary>
        /// converter to put the DB rows to the OrderingNoted container
        /// </summary>
        /// <param name="rec">DB record</param>
        /// <returns>filled OrderingNodted object</returns>
        private OrderingNoted convertNotedOrdering(string[] rec)
        {
            OrderingNoted orn = new OrderingNoted();
            orn.beszerId = Convert.ToInt32(rec[0]);
            orn.termekNev = rec[1];
            orn.kiszerelId = Convert.ToInt32(rec[2]);
            orn.termekKiszer = rec[3];
            orn.redeloNev = rec[4] + " " + rec[5];
            orn.termekBeszall = rec[6];
            orn.termekHely = rec[7];
            orn.termekKod = rec[8];
            orn.beszerzDatum = rec[9].Substring(0, 10);
            orn.beszerzMennyis = Convert.ToInt32(rec[10]);
            //no 2nd date
            foreach (string[] user in poolOfUsers)
            {
                if (user[0] == rec[12])
                {
                    orn.modositNev = user[1] + " " + user[2];
                    break;
                }
            }
            return orn;
        }

        #endregion

        #region readIn bookedOrdering

        /// <summary>
        /// get the list of OrderingBooked to show them the user
        /// </summary>
        /// <returns>list of OrderingBooked</returns>
        public List<OrderingBooked> getListOfBookedOrderings()
        {
            List<OrderingBooked> listBooked = new List<OrderingBooked>();
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("@erveny", "2");
            mdi.openConnection();
            List<string[]> rows = mdi.execPrepQueryInListStringArrWithKVP(queryForReadInRecords, param);
            mdi.closeConnection();
            try
            {
                foreach (string[] rec in rows)
                {
                    listBooked.Add(convertBookedOrdering(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingGetTheBookedPool("A megrendelt rendelések adatlista megalkotása sikertelen (ModOrdNorm) " + e.Message);
            }
            return listBooked;
        }
        /// <summary>
        /// converter to put the DB record into OrderingBooked containger
        /// </summary>
        /// <param name="rec">DB record</param>
        /// <returns>OrderingBooked containger</returns>
        private OrderingBooked convertBookedOrdering(string[] rec)
        {
            OrderingBooked obd = new OrderingBooked();
            obd.beszerId = Convert.ToInt32(rec[0]);
            obd.termekNev = rec[1];
            obd.kiszerelId = Convert.ToInt32(rec[2]);
            obd.termekKiszer = rec[3];
            obd.redeloNev = rec[4] + " " + rec[5];
            obd.termekBeszall = rec[6];
            obd.termekHely = rec[7];
            obd.termekKod = rec[8];
            obd.beszerzDatum = rec[9].Substring(0, 10);
            obd.beszerzMennyis = Convert.ToInt32(rec[10]);
            obd.beszerzRendeles = rec[11].Substring(0, 10);
            obd.rendeloId = Convert.ToInt32(rec[12]);
            foreach (string[] user in poolOfUsers)
            {
                if (user[0] == rec[12])
                {
                    obd.modositNev = user[1] + " " + user[2];
                    break;
                }
            }
            return obd;
        }

        #endregion

        #region readIn arrivedOrdering

        /// <summary>
        /// get the list of OrderingArrived to show them the user
        /// </summary>
        /// <returns>list of OrderingArrived</returns>
        public List<OrderingArrived> getListOfArrivedOrderings()
        {
            List<OrderingArrived> listNote = new List<OrderingArrived>();
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("@erveny", "3");
            mdi.openConnection();
            List<string[]> rows = mdi.execPrepQueryInListStringArrWithKVP(
                queryForReadInRecords, param);
            mdi.closeConnection();
            try
            {
                foreach (string[] rec in rows)
                {
                    listNote.Add(convertArrivedOrdering(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingGetTheArrivedPool("A beérkezett rendelések adatlista megalkotása sikertelen (ModOrdNorm) " + e.Message);
            }
            return listNote;
        }
        /// <summary>
        /// converter to put the DB rows to the OrderingArrived container
        /// </summary>
        /// <param name="rec">DB record</param>
        /// <returns>filled OrderingArrived object</returns>
        private OrderingArrived convertArrivedOrdering(string[] rec)
        {
            OrderingArrived oad = new OrderingArrived();
            oad.beszerId = Convert.ToInt32(rec[0]);
            oad.termekNev = rec[1];
            oad.kiszerelId = Convert.ToInt32(rec[2]);
            oad.termekKiszer = rec[3];
            oad.redeloNev = rec[4] + " " + rec[5];
            oad.termekBeszall = rec[6];
            //no palceing
            oad.termekKod = rec[8];
            oad.beszerzDatum = rec[9].Substring(0, 10);
            oad.beszerzMennyis = Convert.ToInt32(rec[10]);
            oad.beszerzErkezes = rec[11].Substring(0, 10);
            foreach (string[] user in poolOfUsers)
            {
                if (user[0] == rec[12])
                {
                    oad.modositNev = user[1] + " " + user[2];
                    break;
                }
            }
            return oad;
        }

        #endregion

        #region readIn missingOrderin
        /// <summary>
        /// get the list of OrderingMissing to show them the user
        /// </summary>
        /// <returns>list of OrderingMissing</returns>
        public List<OrderingMissing> getListOfMissingOrderings()
        {
            List<OrderingMissing> listNote = new List<OrderingMissing>();
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("@erveny", "4");
            mdi.openConnection();
            List<string[]> rows = mdi.execPrepQueryInListStringArrWithKVP(
                queryForReadInRecords, param);
            mdi.closeConnection();
            try
            {
                foreach (string[] rec in rows)
                {
                    listNote.Add(convertMissingOrdering(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingGetTheMissingPool("A késő rendelések adatlista megalkotása sikertelen (ModOrdNorm) " + e.Message);
            }
            return listNote;
        }
        /// <summary>
        /// converter to put the DB rows to the OrderingArrived container
        /// </summary>
        /// <param name="rec">DB record</param>
        /// <returns>filled OrderingArrived object</returns>
        private OrderingMissing convertMissingOrdering(string[] rec)
        {
            OrderingMissing omg = new OrderingMissing();
            omg.beszerId = Convert.ToInt32(rec[0]);
            omg.termekNev = rec[1];
            omg.kiszerelId = Convert.ToInt32(rec[2]);
            omg.termekKiszer = rec[3];
            omg.redeloNev = rec[4] + " " + rec[5];
            omg.termekBeszall = rec[6];
            //no placeing
            omg.termekKod = rec[8];
            omg.beszerzDatum = rec[9].Substring(0, 10);
            omg.beszerzMennyis = Convert.ToInt32(rec[10]);
            omg.beszMegujitasDatuma = rec[11].Substring(0, 10);
            omg.rendeloId = Convert.ToInt32(rec[12]);
            foreach (string[] user in poolOfUsers)
            {
                if (user[0] == rec[12])
                {
                    omg.modositNev = user[1] + " " + user[2];
                    break;
                }
            }
            return omg;
        }
        #endregion

        #region readIn failedOrdering

        /// <summary>
        /// get the list of OrderingFail to show them the user
        /// </summary>
        /// <returns>list of OrderingFail</returns>
        public List<OrderingFailed> getListOfFailOrderings()
        {
            List<OrderingFailed> listNote = new List<OrderingFailed>();
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("@erveny", "5");
            mdi.openConnection();
            List<string[]> rows = mdi.execPrepQueryInListStringArrWithKVP(queryForReadInRecords, param);
            mdi.closeConnection();
            try
            {
                foreach (string[] rec in rows)
                {
                    listNote.Add(convertFailgOrdering(rec));
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingGetTheFailedPool("A törölt rendelések adatlista megalkotása sikertelen (ModOrdNorm) " + e.Message);
            }
            return listNote;
        }
        /// <summary>
        /// converter to put the DB rows to the OrderingFail container
        /// </summary>
        /// <param name="rec">DB record</param>
        /// <returns>filled OrderingFail object</returns>
        private OrderingFailed convertFailgOrdering(string[] rec)
        {
            OrderingFailed ofd = new OrderingFailed();
            ofd.beszerId = Convert.ToInt32(rec[0]);
            ofd.termekNev = rec[1];
            ofd.kiszerelId = Convert.ToInt32(rec[2]);
            ofd.termekKiszer = rec[3];
            ofd.redeloNev = rec[4] + " " + rec[5];
            ofd.termekBeszall = rec[6];
            //no place
            ofd.termekKod = rec[8];
            ofd.beszerzDatum = rec[9].Substring(0, 10);
            ofd.beszerzMennyis = Convert.ToInt32(rec[10]);
            ofd.beszVeglTorolRend = rec[11].Substring(0, 10);
            foreach (string[] user in poolOfUsers)
            {
                if (user[0] == rec[12])
                {
                    ofd.modositNev = user[1] + " " + user[2];
                    break;
                }
            }
            return ofd;
        }
        #endregion

        #region readIn different pools

        private string queryToGetTheUserPool = "SELECT user_id, vez_nev, ker_nev FROM felhasznadatok";
        /// <summary>
        /// fill up the pool of users to define, who is the lates modifier of the diff records
        /// </summary>
        private void getTheUserPoolForTableFilling()
        {
            mdi.openConnection();
            poolOfUsers = mdi.executeQueryGetStringArrayListOfRows(queryToGetTheUserPool);
            mdi.closeConnection();
        }

        private string queryToGetProductPool = "SELECT termek_min_id, termek_nev, beszallito_id FROM raktminoseg";

        public List<OrderingProdToChoose> getProdPoolOfOrderingChoose()
        {
            List<OrderingProdToChoose> list;
            mdi.openConnection();
            List<string[]> records = mdi.executeQueryGetStringArrayListOfRows(queryToGetProductPool);
            mdi.closeConnection();
            try
            {
                list = new List<OrderingProdToChoose>();
                foreach(string[] rec in records)
                {
                    OrderingProdToChoose optc = new OrderingProdToChoose();
                    optc.termekId = Convert.ToInt32(rec[0]);
                    optc.termekNev = rec[1];
                    optc.beszallitoId = rec[2];
                    list.Add(optc);
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceGetTheProdPool("A terméklista összeállítása sikertelen (ModOrdPoolProd) " + e.Message);
            }
            return list;
        }


        private string queryToGetStrippingsPool =
            "SELECT termek_quant_id, termek_kiszerel, termek_kod, termek_hely FROM raktmennyiseg WHERE " +
            " termek_min_id=@prodQualId";
        /// <summary>
        /// collects the strippin infos of strippings of a chosen product
        /// </summary>
        /// <returns>list of poolOfStrippings container</returns>
        public List<OrderingStrippingToChoose> getStripPoolOfOrderingChoose(string prodId)
        {
            List<OrderingStrippingToChoose> list;
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("@prodQualId",prodId);
            mdi.openConnection();
            List<string[]> records = mdi.execPrepQueryInListStringArrWithKVP(queryToGetStrippingsPool, param);
            mdi.closeConnection();
            try
            {
                list = new List<OrderingStrippingToChoose>();
                foreach (string[] rec in records)
                {
                    OrderingStrippingToChoose ostc = new OrderingStrippingToChoose();
                    ostc.termekQuantId = Convert.ToInt32(rec[0]);
                    ostc.termekkiszerel = Convert.ToInt32(rec[1]);
                    ostc.termekKod = rec[2];
                    ostc.termekHely = rec[3];
                    list.Add(ostc);
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceGetTheProdPool("A kiszereléslista összeállítása sikertelen (ModOrdPoolStrip) " +e.Message);
            }

            return list;
        }

        #endregion
    }
}
