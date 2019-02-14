using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ProductsModelSheets
    {
        private string downloadPathOfSheets;
        private string locallyStorePathOfSheets;
        /// <summary>
        /// constructor of production safety-datasheet downloader/opener
        /// </summary>
        /// <param name="externalSheet">resource of these datasheet</param>
        /// <param name="locallySheet">destination in PC, where these are stored locally</param>
        public ProductsModelSheets(string externalSheet, string locallySheet)
        {
            this.downloadPathOfSheets = externalSheet;
            this.locallyStorePathOfSheets = "";
        }
        /// <summary>
        /// manages the downloading and/or opening the specific sheet - depends of the necessity
        /// </summary>
        /// <param name="sheetName">name of the desired sheet</param>
        public void seeSheet(string sheetName)
        {
            try
            {
                if (File.Exists(locallyStorePathOfSheets + sheetName))
                {
                    Process.Start(locallyStorePathOfSheets + sheetName);
                }
                else
                {
                    checkTheSheetNeedsToDownload(sheetName);
                    Process.Start(locallyStorePathOfSheets + sheetName);
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceProdManageSafetySheet("Az adatlap megnyitása sikertelen (ModSheet) " + e.Message);
            }
        }

        private void checkTheSheetNeedsToDownload(string sheetName)
        {
            try
            {
                WebClient server = new WebClient();
                server.DownloadFile(downloadPathOfSheets + sheetName, sheetName);

            }
            catch (Exception e)
            {
                throw new ErrorServiceProdDownlSafetySheet("Az adatlap letöltése sikertelen (ModSheet) " + e.Message);
            }
        }
    }
}
