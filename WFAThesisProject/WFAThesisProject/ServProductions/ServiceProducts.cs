using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServProductions;

namespace WFAThesisProject
{
    public class ServiceProducts
    {
        private ProductsModelReadIn modelReadingInDatas;
        private ProductsModelStrippingTable modelQuantities;
        private ProductsModelQualityTable modelQualities;
        private ProductsModelSheets modelSheets;
        private Form parentMain;
        private UserConnDetails dbci;
        private string userId;
        private List<ProductFullRow> prodFullList;
        private List<ProductQualityPart> prodPartList;
        private DataTable table;

        public ServiceProducts(UserConnDetails dbci, Form parentMainWin, string userId)
        {
            this.parentMain = parentMainWin;
            this.dbci = dbci;
            this.userId = userId;
        }


        #region handle the process of prodQuantity table
        /// <summary>
        /// reads in the production strippings
        /// </summary>
        /// <param name="mode">true = act / false = history</param>
        /// <returns>readed in datas</returns>
        public DataTable getTableOfProductsFullTable(bool mode)
        {
            modelReadingInDatas = new ProductsModelReadIn(dbci, parentMain);
            table = new DataTable();
            table.Columns.Add("Srsz.",typeof(int));
            table.Columns.Add("Terméknév", typeof(string));   //name, typeof(integer)
            table.Columns.Add("Kiszerelés", typeof(int));
            table.Columns.Add("Mértékegység", typeof(string));
            table.Columns.Add("Veszély", typeof(int));
            table.Columns.Add("Termékkód", typeof(string));
            table.Columns.Add("Helye", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            try
            {
                prodFullList = modelReadingInDatas.getProductsFullList(mode);
                foreach (ProductFullRow cont in prodFullList)
                {
                    table.Rows.Add(cont.strippId, cont.productName, cont.productStripping, cont.productQantUnit, cont.productDanger,
                        cont.productBarcode, cont.productPlace, cont.productQuantity);
                }

                return table;
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceProd(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProd("Ismeretlen hiba történt (ServProdQuantDT) " + e.Message);
            }
        }
        /// <summary>
        /// gets the list of the full-palet productions
        /// </summary>
        /// <returns>list of productions in ProdFullRow</returns>
        public ProductFullRow getFullistContainerOfProduction(int stripId)
        {
            try
            {
                foreach(ProductFullRow rec in prodFullList)
                {
                    if (rec.strippId == stripId)
                        return rec;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceProd("A listaelem keresésnél hiba történt (ServProdQuantSeek) " + e.Message);
            }
            throw new ErrorServiceProd("A listaelem keresése sikertelen (ServProdQuantSeek)");
        }
        /// <summary>
        /// gets the username, who deleted a specific record in the 'raktmennyiseg' table
        /// </summary>
        /// <param name="indexOfRecord">the index of the record</param>
        /// <returns>full name of a user</returns>
        public string getWhoModifiedTheQuantityRecord(int indexOfRecord)
        {
            try
            {
                modelReadingInDatas = new ProductsModelReadIn(dbci, parentMain);
                return modelReadingInDatas.getWhoModifiedRecord(indexOfRecord);
            }
            catch (ErrorServiceWhoModified e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }



        /// <summary>
        /// makes a change in 'raktmennyiseg' table, creates a new record
        /// </summary>
        /// <param name="row">the recors is needed to create</param>
        public void setNewRecProdQuantity(ProductStrippingPart row)
        {
            try
            {
                modelQuantities = new ProductsModelStrippingTable(dbci, parentMain);
                modelQuantities.createNewProdQuantityRecord(row, userId);
            }
            catch (ErrorServiceNewRecord e)
            {
                throw new ErrorServiceProd(e.Message);
            }

        }
        /// <summary>
        /// makes a change in 'raktmennyiseg' table, modify a record
        /// by the original indexer and original stripping
        /// the indexer mustn't changes!
        /// </summary>
        /// <param name="row">the content of record with new parameters</param>
        /// <param name="oldStripping">the old stripping of the record</param>
        public void setModifyRecProdQuantity(ProductStrippingPart row, string oldStripping)
        {
            try
            {
                modelQuantities = new ProductsModelStrippingTable(dbci, parentMain);
                modelQuantities.modifyProdQuantityRecord(row, oldStripping, userId);
            }
            catch (ErrorServiceUpdateRecord e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }
        /// <summary>
        /// makes a change in 'raktMennyiseg' table, delete a record
        /// </summary>
        /// <param name="index">the record index</param>
        /// <param name="userId">who delets it</param>
        public void setDeleteRecProdQuantity(string index, string stripping)
        {
            try
            {
                modelQuantities = new ProductsModelStrippingTable(dbci, parentMain);
                modelQuantities.deleteProdQuantityRecord(index, stripping, userId);
            }
            catch (ErrorServiceDeleteRecord e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }

        /// <summary>
        /// makes a change in 'raktmennyiseg' table, undelet a record
        /// this nullifies the value of who-deleted in 'termek_metorles' field
        /// </summary>
        /// <param name="index">the record index</param>
        public void setUndeleteRecProdQuantity(string index, string stripping)
        {
            try
            {
                modelQuantities = new ProductsModelStrippingTable(dbci, parentMain);
                modelQuantities.renewProdQuantityRecord(index, stripping, userId);
            }
            catch (ErrorServiceRenewRecord e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }


        #endregion

        #region handle the processes the prodQuality table

        /// <summary>
        /// request the content the productQuality content
        /// </summary>
        /// <param name="mode">mode true = active / false = passive records</param>
        /// <returns>DataTable result of the collecting</returns>
        public DataTable getTableOfProductsPartTable(bool mode)
        {
            try
            {
                //modelQualities = new ProductsModelQualityTable(,);
                modelReadingInDatas = new ProductsModelReadIn(dbci, parentMain);
                prodPartList = modelReadingInDatas.getProductsPartList(mode);
                table = new DataTable();
                table.Columns.Add("Srsz.", typeof(int));
                table.Columns.Add("Terméknév", typeof(string));   //name, typeof(integer)
                table.Columns.Add("Mértékegység", typeof(string));
                table.Columns.Add("Veszély", typeof(int));
                table.Columns.Add("Beszállítója", typeof(string));
                table.Columns.Add("Leírás", typeof(string));
                //table.Columns.Add("Módosítás", typeof(string));

                foreach (ProductQualityPart cont in prodPartList)
                {
                    table.Rows.Add(cont.productQualId, cont.productName, cont.productQantUnit, cont.productDanger,
                        cont.productSubcontr, cont.productDescr
                        /*modelQualities.getWhoModifiedQuality(cont.productModifiedBy)*/);
                }

                return table;
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceProd(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProd("Ismertlen hiba történt (ServProdDT) " + e.Message);
            }
        }
        /// <summary>
        /// gets the element of the chosen DataTable row
        /// </summary>
        /// <returns>container of 'raktminoseg' talbe</returns>
        public ProductQualityPart getPartContainerOfChosenProductions(int prodId)
        {
            try
            {
                foreach(ProductQualityPart prod in prodPartList)
                {
                    if (prod.productQualId == prodId)
                    {
                        return prod;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceProd("A listaelem keresésnél hiba történt (ServProdSeek) " + e.Message);
            }
            throw new ErrorServiceProd("A listaelem keresése sikertelen (ServProdSeek)");
        }
        /// <summary>
        /// gets the username, who deleted a specific record in the 'raktminoseg' table
        /// </summary>
        /// <param name="indexOfRecord">the index of the record</param>
        /// <returns>full name of a user</returns>
        public string getWhoModifiedTheRecord(int indexOfRecord)
        {
            try
            {
                modelReadingInDatas = new ProductsModelReadIn(dbci, parentMain);
                return modelReadingInDatas.getWhoModifiedRecord(indexOfRecord);
            }
            catch (ErrorServiceWhoModified e)
            {
                throw new ErrorServiceProd(e.Message);
            }


        }
        /// <summary>
        /// make change in raktminoseg - create new record - some value is emty! productIndex as well
        /// name; subcontr; descr; unit; 
        /// </summary>
        /// <param name="row">the spec datas to sotre in DB</param>
        public void setNewRecProdQuality(ProductQualityPart row)
        {
            try
            {
                modelQualities = new ProductsModelQualityTable(dbci, parentMain);
                modelQualities.createNewProdQualityRecord(row, userId);
            }
            catch (ErrorServiceNewRecord e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }
        /// <summary>
        /// make change in raktminoseg - modify the spec. record
        /// ProdPartRow - the productIndex musn't change!
        /// </summary>
        /// <param name="row">record content, that is needed to change</param>
        public void setModifyRecProdQuality(ProductQualityPart row)
        {
            try
            {
                modelQualities = new ProductsModelQualityTable(dbci, parentMain);
                modelQualities.modifyProdQualityRecord(row, userId);
            }
            catch (ErrorServiceUpdateRecord e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }
        /// <summary>
        /// make change in raktminoseg - delete the spec. record
        /// </summary>
        /// <param name="index">which is needed</param>
        public void setDeleteRecProdQuality(string index)
        {
            try
            {
                modelQualities = new ProductsModelQualityTable(dbci, parentMain);
                modelQualities.deleteProdQualityRecord(index, userId);
            }
            catch (ErrorServiceDeleteRecord e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }
        /// <summary>
        /// make a change in reaktminoseg - undelete the spec. record
        /// </summary>
        /// <param name="index">the unique key to renew the record</param>
        public void setUndeleteRecProdQuality(string index)
        {
            try
            {
                modelQualities = new ProductsModelQualityTable(dbci, parentMain);
                modelQualities.renewProdQualityRecord(index, userId);
            }
            catch (ErrorServiceRenewRecord e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }
        #endregion

        #region forTheProdSideWindow

        public List<string> getListOfSubcontr()
        {
            modelReadingInDatas = new ProductsModelReadIn(dbci, parentMain);
            return modelReadingInDatas.getSubcontrList();
        }


        public bool checkBarcodeUniquity(string text)
        {
            modelQuantities = new ProductsModelStrippingTable(dbci, parentMain);
            return modelQuantities.checkBarcodeUniquity(text);
        }
        /*
        public bool checkPlacecodeUniquity(string text)
        {
            return modelQuantities.checkPlaceCodeUniquity(text);
        }
        */
        #endregion

        #region handle the processes of safetySheetManagement
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetName">the name of the desired sheet</param>
        public void getTheSaftyDataSheet(string sheetName)
        {
            try
            {
                modelSheets = new ProductsModelSheets(dbci.input, dbci.output);
                modelSheets.seeSheet(sheetName);
            }
            catch (ErrorServiceProdDownlSafetySheet e)
            {
                throw new ErrorServiceProd(e.Message);
            }
            catch (ErrorServiceProdManageSafetySheet e)
            {
                throw new ErrorServiceProd(e.Message);
            }
        }
        #endregion
    }
}
