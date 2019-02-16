using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFAThesisProject
{
    class InterfaceMySQLStartDBConnect
    {
        /// <summary>
        /// coordinates the connection end communicarions with the DB under MetroWinForm environment
        /// with the needed connection datas - all must have at least "" content
        /// </summary>
        /// <param name="host">host adress</param>
        /// <param name="port">port number</param>
        /// <param name="database">managed DB name</param>
        /// <param name="user">uername to enter with</param>
        /// <param name="pwd">password to enter with</param>
        /// <param name="consoleErr">is needed console based errors?</param>
        /// <param name="oldFormErr">is needed old WinForm errors?</param>
        /// <param name="metroFormErr">is needed Metro WinFrom errors?</param>
        /// <param name="parentForm">the parent MetroWindow</param>
        /// <returns>MySqlInterface with basic adjusts</returns>
        public InterfaceMySQLDBChannel kapcsolodas(UserConnDetails dbci, System.Windows.Forms.Form parent)
        {
            InterfaceMySQLDBChannel mdi = new InterfaceMySQLDBChannel();
            mdi.setErrorToUserInterface(true);           //ha hiba van, megjeleni - konzolos
            mdi.setErrorToGraphicalUserInterface(true);     //ha hiba van, megjeleni - régebbi Form verzióban
            mdi.setErrorToMetroGraphicalUserInterface(true, parent);    //ha hiba van, megjeleníti - újabb MetroForm-ban
            mdi.setConnectionServerData(dbci.host, dbci.db, dbci.port);    //hely, adatbázis neve, portja
            mdi.setConnectionUserData(dbci.user, dbci.pwd);          //admin név, jelszava
            mdi.makeConnectionToDatabase();             //beállítja az alap kapcsolódási adatokat
            return mdi;
        }
    }
}
