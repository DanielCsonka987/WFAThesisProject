using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace WFAThesisProject
{
    public class ManageIOConnFileController
    {
        private Form parentWindow;
        private UserConnDetails userConnDetails;
        private ModelManageIOConnFile modelManagIOConn;
 
        /// <summary>
        /// constructor, 
        public ManageIOConnFileController(Form parent)
        {
            this.parentWindow = parent;
            modelManagIOConn = new ModelManageIOConnFile();
        }
        /// <summary>
        /// tries to find DB connection informations in the object
        /// </summary>
        /// <param name="dbci">the connection-info carrier</param>
        /// <returns>needness of asking connection parameters by user</returns>
        public bool initialDBConnectInfo(UserConnDetails dbci)
        {
            if (dbci == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// read the connection details of xml file to have DB connection
        /// </summary>
        /// <param name="ucd"></param>
        /// <param name="parent"></param>
        public UserConnDetails getTheConnInfos(Form parent)
        {
            try
            {
                modelManagIOConn.reviseXmlFileExists();
                modelManagIOConn.readConnDatas();
                userConnDetails = modelManagIOConn.getConnInfos();
            }
            catch (ErrorXmlFileRead e)
            {
                errorHandle(e.getMessage());
            }
            catch (Exception)
            {
                errorHandle("Ismeretlen fájlkezelési hiba történt! Kapcsolódási információk betöltése megszakadt!");
            }
            return userConnDetails;
        }
        /// <summary>
        /// writes out the connection infos
        /// </summary>
        /// <param name="ucd">the proper details to XML files</param>
        /// <param name="parent">the form that manages this</param>
        public void setTheConnInfos(UserConnDetails ucd, Form parent)
        {
            try
            {
                modelManagIOConn.writeConnDatas(ucd);
            }

            catch (ErrorXmlFileWrite e)
            {
                errorHandle(e.getMessage());
            }
            catch (Exception)
            {
                errorHandle("Ismeretlen fájlkezelési hiba történt! Kapcsolódási információk betöltése megszakadt!");
            }
        }



        /// <summary>
        /// error handle method, creates MetroFramework MessageBox message for user(s)
        /// </summary>
        /// <param name="message">errormessage in string</param>
        private void errorHandle(string message)
        {
            MetroFramework.MetroMessageBox.Show(parentWindow, message, "Figyelmeztetés",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information, 200);
        }

        #region for unit-tests
        /// <summary>
        /// constructor for Unit-test
        /// </summary>
        /// <param name="ucd"></param>
        /// <param name="mode"></param>
        public ManageIOConnFileController(UserConnDetails ucd, bool mode)
        {
            try
            {
                modelManagIOConn = new ModelManageIOConnFile();
                if (mode)
                {
                    modelManagIOConn.writeConnDatas(ucd);
                }
                else
                {
                    modelManagIOConn.reviseXmlFileExists();
                    modelManagIOConn.readConnDatas();
                    userConnDetails = modelManagIOConn.getConnInfos();
                }
            }
            catch (ErrorXmlFileWrite e)
            {
                errorHandle(e.getMessage());
            }
            catch (ErrorXmlFileRead e)
            {
                errorHandle(e.getMessage());
            }
            catch (Exception)
            {
                errorHandle("Ismeretlen fájlkezelési hiba történt! Kapcsolódási információk betöltése megszakadt!");
            }
        }
        #endregion
    }
}
