using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

//Console alkalmazás esetén
//To add reference in c# program right click in your project folders shown in 
//solution explorer on add references-> .Net -> select System.Windows.Forms. 
using System.Windows.Forms;

namespace WFAThesisProject
{
    class InterfaceMySQLDBChannel
    {
        private MySqlConnection connection;
        private MySqlDataAdapter dataAdapter;
        private MySqlCommandBuilder commandBuilder;
        private MySqlDataReader dataReader;

        private string server;
        private string database;
        private string username;
        private string password;
        private string port;

        // hiba MYSQL utasításokban
        private string errorMessage;

        // hiba megjelenjen-e a program futása közben
        private bool errorToUserInterface;
        // hiba grafikus interfacen jelenjen meg vagy nem (ha nem akkor konzolon)
        private bool errorToGraphicalUserInterface;
        // hiba grafikus MetroFramework Form-on jelenjen meg vagy nem (ha nem akkor a többi közül valamelyik)
        private bool errorToMetroGraphicalUserInterface;
        //MetroFrameWork esetén tárolja a célablakot, ahol meg kell jeleníteni az üzenetet
        private Form parentWindowsForms;

        /// <summary>
        /// basic constructor with no connection information
        /// </summary>
        public InterfaceMySQLDBChannel()
        {
            server = string.Empty;
            database = string.Empty;
            username = string.Empty;
            password = string.Empty;
            port = string.Empty;

            errorMessage = string.Empty;

            errorToUserInterface = false;
            errorToGraphicalUserInterface = false;
            errorToMetroGraphicalUserInterface = false;
        }

        #region adjustin connective datas and execute the connection via AdatbaseClass

        /// <summary>
        /// sets if it is needed the errors in console
        /// </summary>
        /// <param name="etui">needness in boolean</param>
        public void setErrorToUserInterface(bool etui)
        {
            errorToUserInterface=etui;
        }

        /// <summary>
        /// sets if it is needed the errors in old WinFrom
        /// </summary>
        /// <param name="etgui">needness in boolean</param>
        public void setErrorToGraphicalUserInterface(bool etgui)
        {
            errorToGraphicalUserInterface=etgui;
        }
        public void setErrorToMetroGraphicalUserInterface(bool etmgi, System.Windows.Forms.Form form)
        {
            errorToMetroGraphicalUserInterface = true;
            parentWindowsForms = form;
        }
        /// <summary>
        /// it sets the connection datas to the DB
        /// </summary>
        /// <param name="server">server address</param>
        /// <param name="database">managed DB name</param>
        /// <param name="port">used port number</param>
        public void setConnectionServerData(string server, string database, string port)
        {
            this.server = server;
            this.database = database;
            this.port = port;
        }

        /// <summary>
        /// it sets the connection datas to manage the database with
        /// </summary>
        /// <param name="username">needed username</param>
        /// <param name="password">needed password</param>
        public void setConnectionUserData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// execute the connection process with the given connection datas
        /// </summary>
        /// <returns>the resutl of process in boolean</returns>
        public bool makeConnectionToDatabase()
        {
            if (isEmptyOneParameter())
            {
                connection = null;
                return false;
            }
            string connectionString = "SERVER=" + server + ";"
                                    + "DATABASE=" + database + ";"
                                    + "UID=" + username + ";"
                                    + "PASSWORD=" + password + ";"
                                    + "PORT=" + port + ";"
                                    + "convert zero datetime=True;";
            try
            {
                connection = new MySqlConnection(connectionString);
                return true;
            }
            catch (MySqlException)
            {
                setErrorDataAndShow("Adatbázis kapcsolat nem jött létre (General).");
            }
            return true;

        }
        #endregion

        #region built in error handle
        /// <summary>
        /// it handles and show the errors under console environment
        /// </summary>
        private void writeErrorToConsoleUserInterface()
        {
            Console.WriteLine("Hiba az adatbázis művelet közben:");
            Console.WriteLine(errorMessage);
        }
        /// <summary>
        /// it handles and show the errors under GUI environment
        /// it is stronger than the console one
        /// </summary>
        private void writeErrorToGgrapichalUserInterface()
        {
            MessageBox.Show(
                "Adatábzis hiba: "+errorMessage,                
                "Adatbázis hiba...",
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error
           );
        }
        /// <summary>
        /// it handles and show the errors under Metro GUI environment
        /// </summary>
        private void writeErrorToMetroGrapuicalUserInterface()
        {
            MetroFramework.MetroMessageBox.Show(
                parentWindowsForms, "Adatábzis hiba: "+errorMessage, 
                "Adatbázis hiba..", MessageBoxButtons.OK, MessageBoxIcon.Error, 200);
            throw new ErrorDBMetroProblem();
        }
        /// <summary>
        /// it sets the mode which way show the hendling of exceptions
        /// </summary>
        /// <param name="message"></param>
        private void setErrorDataAndShow(string message)
        {
            errorMessage = message;
            if (errorToUserInterface)
            {
                if (errorToMetroGraphicalUserInterface)
                    writeErrorToMetroGrapuicalUserInterface();
                else if (errorToGraphicalUserInterface)
                    writeErrorToGgrapichalUserInterface();
                else
                    writeErrorToConsoleUserInterface();
            }
        }
        #endregion

        #region testers of the connection and datas to do it

        /// <summary>
        /// it is testing the sent connection datas of our
        /// it is the part of the coordinativ methods
        /// </summary>
        /// <returns>the result of test in boolean</returns>
        private bool isEmptyOneParameter()
        {
            bool answer = false;
            if (server == string.Empty)
                answer = true;
            else if (database == string.Empty)
                answer = true;
            else if (username == string.Empty)
                answer = true;
           /* else if (password == string.Empty)
                answer = true;*/
            if (answer == true)
                setErrorDataAndShow("Valamelyik kapcsolati paraméter üres (General)");
            return answer;
        }

        /// <summary>
        /// it tests the existence of connection
        /// it is the part of alomst everityong
        /// </summary>
        /// <returns>the result of the process in boolean</returns>
        private bool isConnectionExsist()
        {
            if (connection == null)
            {
                setErrorDataAndShow("A kapcsolat nem létezik (General).");
                return false;
            }
            else
                return true;
        }
        #endregion

        #region methods for manage connections directly
        /// <summary>
        /// opens the connection with DB via connecting informations
        /// </summary>
        /// <returns></returns>
        public bool openConnection()
        {
            if (!isConnectionExsist())
                return false;
            else
            {
                //ha már nyitva van a kapcsolat ne nyissa meg mégegyszer
                if ((connection != null) && (connection.State == ConnectionState.Open))
                    return true;
                else
                {
                    try
                    {
                        connection.Open();
                        return true;
                    }
                    catch (MySqlException me)
                    {
                        //http://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                        switch (me.Number)
                        {
                            case 0:
                                    //Cannot connect to server.  Contact administrator"
                                    setErrorDataAndShow("Adatbázis kapcsolat nem jött létre (DBMS). "+me.Message);
                                break;
                            case 1045:
                                    //Invalid username/password, please try again"
                                    setErrorDataAndShow("A megadott jelszó vagy felhasználónév nem megfelelő (DBMS).");     
                                break;
                            case 1042:
                                    //Message: Can't get hostname for your address 
                                    setErrorDataAndShow("A megadott host elérhetetlen (DBMS).");
                                break;
                            default:
                                setErrorDataAndShow("Adatbázis kapcsolat nem jött létre (DBMS).\n" +
                                                    me.Message/*+me.Number*/
                                                    );
                                break;                            
                        }
                        connection = null;
                        return false;
                    }
                }
            }          
        }

        /// <summary>
        /// closes the connection with DB
        /// </summary>
        /// <returns>the resutl of process in boolean</returns>
        public bool closeConnection()
        {
            if (!isConnectionExsist())
                return false;
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                setErrorDataAndShow("Adatbázis bezárás hiba.\n" + e.Message/*+me.Number*/);
                return false;
            }
        }
        #endregion

        #region testers of queries executablity

        /// <summary>
        /// it is testing the sent query, about its executivity, is still there the connection
        /// it is part of every executeQuery method
        /// </summary>
        /// <param name="query">the query in string</param>
        /// <returns>the resul of testing in boolean</returns>
        private bool isExecutableQuery(string query)
        {
            if (query == string.Empty)
            {
                return false;
            }
            if (!isConnectionExsist())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// it is testing the sent parameter list in prepared method executions
        /// it is part of every executeQueryPrepared
        /// </summary>
        /// <param name="param">the list of KeyValuePair-s</param>
        /// <param name="paramNum">the number of parameter-pairs</param>
        /// <returns></returns>
        private bool isPreparedParamCompletness(List<KeyValuePair<string, string>> param, int paramNum)
        {
            if (param.Count == 0 || param.Count != paramNum)
            {
                return false;
            }
            foreach (KeyValuePair<string, string> row in param )
            {
                if (row.Key == string.Empty || row.Value == string.Empty)
                    return false;
            }
            if (!isConnectionExsist())
            {
                return false;
            }
            return true;
        }
        #endregion

        #region normal query methods 7 - ScalarQuery, string[], listOfoneField, dataTable, listOfArrayRows, DMQuery, updateDataTable


        /// <summary>
        /// execute a query, where we can get a simple or a field of information
        /// </summary>
        /// <param name="query">the query in string</param>
        /// <returns>answer in simple string</returns>
        public string executeScalarQueryInString(string query)
        //example query: SELECT Count(*) FROM table
        {
            string scalar = string.Empty;
            try
            {
                if (!isConnectionExsist())
                    return string.Empty;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecScalar). Lekérdezést nem lehet végrehajtani.\n");
                    return scalar;
                }
                if (!isExecutableQuery(query))
                {
                    return scalar;
                }

                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    //Execute command
                    scalar = cmd.ExecuteScalar().ToString();
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecScalar).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return scalar;
            }
            catch (ErrorDBMetroProblem) { return string.Empty; }

        }

        /// <summary>
        /// execute a query, where we can get a simple or a row of information
        /// if it gats multiple rows, always the last one returns
        /// </summary>
        /// <param name="query">the query in string</param>
        /// <returns>answer in simple string[]</returns>
        public string[] executeQueryGetFullRowToArr(string query)
        {

            string[] rowValue = null;
            try
            {
                if (!isConnectionExsist())
                    return rowValue;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecScalarArr). Lekérdezést nem lehet végrehajtani.\n");
                    return rowValue;
                }
                if (!isExecutableQuery(query))
                {
                    return rowValue;
                }

                MySqlCommand cmd;
                MySqlDataReader dataReader = null;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        rowValue = new string[dataReader.FieldCount];
                        for(int i = 0; i < dataReader.FieldCount; i++)
                        {
                            rowValue[i] = dataReader.GetString(i);
                        }
                    }

                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecScalarArr).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return rowValue;
            }
            catch (ErrorDBMetroProblem) { return rowValue; }
        }

        /// <summary>
        /// execute a query, where we need a column of field-data
        /// </summary>
        /// <param name="query">the query in string</param>
        /// <returns>answer in list of strings</returns>
        /// 
        public List<string> executeQueryGetOneFieldToList(string query)
        //example query: SELECT orszag FROM orszagok
        {
            List<string> list = new List<string>();
            try
            {
                if (!isConnectionExsist())
                    return list;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecFieldList). Lekérdezést nem lehet végrehajtani.\n");
                    return list;
                }
                if (!isExecutableQuery(query))
                {
                    return list;
                }
                MySqlDataReader dataReader = null;
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader[0] + "");
                    }
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecFieldList).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                    if (dataReader != null)
                    {
                        //close Data Reader
                        dataReader.Close();
                    }
                }
                //return list to be displayed
                return list;
            }
            catch (ErrorDBMetroProblem) { return list; }
        }

        /// <summary>
        /// execute a query, where we need a table of datas, possibly lots of rows with several fields
        /// </summary>
        /// <param name="query">the query in string</param>
        /// <returns>answer on DataTable type</returns>
        public DataTable executeQueryGetToDataTable(string query)
        //example query: SELECT orszag,fovaros,gdp FROM orszagok WHERE foldr_hely=\"Nyugat-Európa\"
        {
            DataTable dt = new DataTable();
            try
            {
                if (!isConnectionExsist())
                    return dt;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecDT). Lekérdezést nem lehet végrehajtani.\n");
                    return dt;
                }
                // using System.Data;
                if (!isExecutableQuery(query))
                {
                    return dt;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    if (cmd == null)
                        return dt;
                    dataAdapter = new MySqlDataAdapter(cmd);
                    commandBuilder = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.Fill(dt);

                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecDT).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return dt;
            }
            catch (ErrorDBMetroProblem) { return dt; }
        }

        /// <summary>
        /// execute a query, where we need a list or rows, possibly lots of rows in a string array
        /// the order of the fields depend on the query !! it is doesn'T mark those !!
        /// </summary>
        /// <param name="query">the query in string</param>
        /// <returns>the resutl of query in list of string arrays, separates the fields</returns>
        public List<string[]> executeQueryGetStringArrayListOfRows(string query)
        //example query: SELECT orszag,fovaros,gdp FROM orszagok WHERE foldr_hely=\"Nyugat-Európa\"
        {
            List<string[]> dataContainer = new List<string[]>();
            try
            {
                if (!isConnectionExsist())
                    return dataContainer;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecSAL). Lekérdezést nem lehet végrehajtani.\n");
                    return dataContainer;
                }
                // using System.Data;
                if (!isExecutableQuery(query))
                {
                    return dataContainer;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    MySqlDataReader mydataread = cmd.ExecuteReader();

                    if(!mydataread.HasRows)
                    {
                        mydataread.Close();
                        return dataContainer;
                    }
                    else
                    {
                        while (mydataread.Read())
                        {
                            string[] row = new string[mydataread.FieldCount];
                            for (int i = 0; i < mydataread.FieldCount; i++)
                            {
                                if (mydataread.GetString(i) == string.Empty)
                                    row[i] = "";
                                else
                                   row[i] = mydataread.GetString(i);
                            }
                            dataContainer.Add(row);
                        }
                        mydataread.Close();
                    }
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecSAL).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return dataContainer;
            }
            catch (ErrorDBMetroProblem) { return dataContainer; }
        }

        /// <summary>
        /// execute a query, where is no need to get answer datas
        /// </summary>
        /// <param name="query">the query in string</param>
        public void executeDMQuery(string query)
        //example query: UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'
        //example query: INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')
        //example query: DELETE FROM tableinfo WHERE name='John Smith'
        {
            try
            {
                if (!isConnectionExsist())
                    return;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecDM). Lekérdezést nem lehet végrehajtani.\n");
                    return;
                }
                if (!isExecutableQuery(query))
                {
                    return;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    //Execute command
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis módosítás hiba (ExecDM).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
            }
            catch (ErrorDBMetroProblem) { }
        }

        /// <summary>
        /// execute changes in DB via our DataTable content
        /// use it with the same instant of the MySqlDatabaseInterface
        /// but open-close are no problem!
        /// </summary>
        /// <param name="dt">the DataTable of our with changes</param>
        public void updateChangesInTable(DataTable dt)
        {
            try
            {
                try
                {
                    dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                    dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                    dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                    dataAdapter.Update(dt);
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis frissítési hiba.\n" + me.Message/*+me.Number*/);
                }
                catch (Exception e)
                {
                    setErrorDataAndShow("Adatbázis frissítési hiba.\n" + e.Message/*+me.Number*/);
                }
                finally
                {
                }
            }
            catch (ErrorDBMetroProblem) { }
        }
        #endregion

        #region prepared query methods 10 - oneField, dataTable, DMQuery, ScalarQuery, List<string[]>, string[]

        /// <summary>
        /// execute a query, where we need a table of datas, possibly lots of rows with several fields
        /// prepared version!! it works with List<KeyValuePair<string-string> !!
        /// put in the list key without @ !!
        /// </summary>
        /// <param name="query">the query in string</param>
        /// <param name="param">the list of key-value pares in string</param>
        /// <param name="paramNum"/>the number of paramteres</param>
        /// <returns>answer on DataTable type</returns>
        public DataTable execPrepQueryGetToDataTable(string query, List<KeyValuePair<string, string>> param, int paramNum)
        //example query: SELECT orszag,fovaros,gdp FROM orszagok WHERE foldr_hely=\"Nyugat-Európa\"
        {
            DataTable dt = new DataTable();
            try
            {
                if (!isConnectionExsist())
                    return dt;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepDT). Lekérdezést nem lehet végrehajtani.\n");
                    return dt;
                }
                // using System.Data;
                if (!isExecutableQuery(query))
                {
                    return dt;
                }
                if (!isPreparedParamCompletness(param, paramNum))
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepDT). Lekérdezést nem lehet végrehajtani.\n");
                    return dt;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    for (int i = 0; i < param.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@" + param[i].Key, param[i].Value);
                    }
                    dataAdapter = new MySqlDataAdapter(cmd);
                    commandBuilder = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.Fill(dt);
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepDT).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return dt;
            }
            catch (ErrorDBMetroProblem) { return dt; }
        }
        /// <summary>
        /// execute a query, where is no need to get answer datas
        /// prepared version!! it works with List<KeyValuePair<string-string>> !!
        /// </summary>
        /// <param name="query">the query in string</param>
        /// <param name="param"/>the list of key-value pares in string</param>
        /// <param name="paramNum"/>the number of paramteres</param>
        public void execPrepDMQueryWithKVPList(string query, List<KeyValuePair<string, string>> param, int paramNum)
        //example query: UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'
        //example query: INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')
        //example query: DELETE FROM tableinfo WHERE name='John Smith'
        {
            try
            {
                if (!isConnectionExsist())
                    return;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepDM). Lekérdezést nem lehet végrehajtani.\n");
                    return;
                }
                if (!isExecutableQuery(query))
                {
                    return;
                }
                if (!isPreparedParamCompletness(param, paramNum))
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepDM). Lekérdezést nem lehet végrehajtani.\n");
                    return;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    //Execute command
                    cmd.Prepare();
                    for (int i = 0; i < param.Count; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i].Key, param[i].Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis módosítás hiba (ExecPrepDM).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
            }
            catch (ErrorDBMetroProblem) { }
        }
        /// <summary>
        /// execute a query, where is no need to get answer datas
        /// prepared version!! it works with KeyValuePair<string-string> !!
        /// </summary>
        /// <param name="query">the query to execute</param>
        /// <param name="param">the paramerer Key-value-Pair</param>
        public void execPrepDMQueryWithKVP(string query, KeyValuePair<string, string> param)
        //example query: UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'
        //example query: INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')
        //example query: DELETE FROM tableinfo WHERE name='John Smith'
        {
            try
            {
                if (!isConnectionExsist())
                    return;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepDM). Lekérdezést nem lehet végrehajtani.\n");
                    return;
                }
                if (!isExecutableQuery(query))
                {
                    return;
                }
                if (param.Key == null || param.Value == null)
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepDM). Lekérdezést nem lehet végrehajtani.\n");
                    return;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    //Execute command
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis módosítás hiba (ExecPrepDM).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
            }
            catch (ErrorDBMetroProblem) { }
        }
        /// <summary>
        /// execute a query, where w can get a simple or a row of information
        /// prepared version!! it works with List<KeyValuePair<string-string>> !!
        /// put in the list key without @ !!
        /// </summary>
        /// <param name="query">the query that is needed to</param>
        /// <param name="param">the list of key-value pares in string</param>
        /// <param name="paramNum"/>the number of paramteres</param>
        /// <returns>the result of query in string</returns>
        public string execPrepScalarQueryInStringWithKVPList(string query, List<KeyValuePair<string, string>> param, int paramNum)
        {
            string scalar = string.Empty;
            try
            {
                if (!isConnectionExsist())
                    return string.Empty;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepScalKVPList). Lekérdezést nem lehet végrehajtani.\n");
                    return scalar;
                }
                if (!isExecutableQuery(query))
                {
                    return scalar;
                }
                if (!isPreparedParamCompletness(param, paramNum))
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepScalKVPList). Lekérdezést nem lehet végrehajtani.\n");
                    return scalar;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    for (int i = 0; i < param.Count; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i].Key, param[i].Value);
                    }
                    //Execute command
                    scalar = cmd.ExecuteScalar().ToString();
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepScalKVPList).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return scalar;
            }
            catch (ErrorDBMetroProblem) { return string.Empty; }
        }
        /// <summary>
        /// execute a query, where w can get a simple or a row of information
        /// prepared version!! it works with only one KeyValuePair<string-string> !!
        /// put in the list key without @ !!
        /// </summary>
        /// <param name="query">the query that is needed to</param>
        /// <param name="param">the list of key-value pares in string</param>
        /// <param name="paramNum"/>the number of paramteres</param>
        /// <returns>the result of query in string</returns>
        public string execPrepScalarQueryInStringWithKVP(string query, KeyValuePair<string, string> param)
        {
            string scalar = string.Empty;
            try
            {
                if (!isConnectionExsist())
                    return string.Empty;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepScalKVP). Lekérdezést nem lehet végrehajtani.\n");
                    return scalar;
                }
                if (!isExecutableQuery(query))
                {
                    return scalar;
                }
                if (param.Key == null || param.Value == null)
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepScalKVP). Lekérdezést nem lehet végrehajtani.\n");
                    return scalar;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                    //Execute command
                    scalar = cmd.ExecuteScalar().ToString();
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepScalKVP).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return scalar;
            }
            catch (ErrorDBMetroProblem) { return string.Empty; }
        }
        /// <summary>
        /// execute a query that returns many row of fields -> creates a List of string arrays
        /// it gives back possibly mutiple rows content!
        /// prepared version!! it works with List<KeyValuePair<string-string>> !!
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="paramNum"/>the number of paramteres</param>
        /// <returns></returns>
        public List<string[]> execPrepQueryInListStringArrWithKVPList(string query, List<KeyValuePair<string, string>> param, int paramNum)
        {
            List<string[]> multipleValue = new List<string[]>();
            try
            {
                if (!isConnectionExsist())
                    return multipleValue;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepLSA). Lekérdezést nem lehet végrehajtani.\n");
                    return multipleValue;
                }
                if (!isExecutableQuery(query))
                {
                    return multipleValue;
                }
                if (!isPreparedParamCompletness(param, paramNum))
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepLSA). Lekérdezést nem lehet végrehajtani.\n");
                    return multipleValue;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    for (int i = 0; i < param.Count; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i].Key, param[i].Value);
                    }
                    //Execute command
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string[] record = new string[dataReader.FieldCount];
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            record[i] = dataReader.GetString(i);
                        }
                        multipleValue.Add(record);
                    }
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepLSA).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return multipleValue;
            }
            catch (ErrorDBMetroProblem) { return multipleValue; }
        }
        /// <summary>
        /// execute a query that returns many row of fields -> creates a List of string arrays
        /// it gives back possibly mutiple rows content!
        /// prepared version!! it works with KeyValuePair<string-string> !!
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<string[]> execPrepQueryInListStringArrWithKVP(string query, KeyValuePair<string, string> param)
        {
            List<string[]> multipleValue = new List<string[]>();
            try
            {
                if (!isConnectionExsist())
                    return multipleValue;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepLSA). Lekérdezést nem lehet végrehajtani.\n");
                    return multipleValue;
                }
                if (!isExecutableQuery(query))
                {
                    return multipleValue;
                }
                if (param.Key == null || param.Value == null)
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepLSA). Lekérdezést nem lehet végrehajtani.\n");
                    return multipleValue;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                    //Execute command
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string[] record = new string[dataReader.FieldCount];
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            record[i] = dataReader.GetString(i);
                        }
                        multipleValue.Add(record);
                    }
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepLSA).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return multipleValue;
            }
            catch (ErrorDBMetroProblem) { return multipleValue; }
        }
        /// <summary>
        /// execute a query that returns ONLY ONE row of fields -> creates a string array
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="paramNum"/>the number of paramteres</param>
        /// <returns></returns>
        public string[] execPrepQueryOneRowInStringArrWithKVPList(string query, List<KeyValuePair<string, string>> param, int paramNum)
        {
            string[] rowValue = null;
            try
            {
                if (!isConnectionExsist())
                    return rowValue;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepSaKVPList). Lekérdezést nem lehet végrehajtani.\n");
                    return rowValue;
                }
                if (!isExecutableQuery(query))
                {
                    return rowValue;
                }
                if (!isPreparedParamCompletness(param, paramNum))
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepSaKVPList). Lekérdezést nem lehet végrehajtani.\n");
                    return rowValue;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    for (int i = 0; i < param.Count; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i].Key, param[i].Value);
                    }
                    //Execute command
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        rowValue = new string[dataReader.FieldCount];
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            rowValue[i] = dataReader.GetString(i);
                        }
                    }

                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepSaKVPList).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return rowValue;
            }
            catch (ErrorDBMetroProblem) { return rowValue; }
        }
        /// <summary>
        /// execute a query that returns ONLY ONE row of fields -> creates a string array
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="paramNum"/>the number of paramteres</param>
        /// <returns></returns>
        public string[] execPrepQueryOneRowInStringArrWithKVP(string query, KeyValuePair<string, string> param)
        {
            string[] rowValue = null;
            try
            {
                if (!isConnectionExsist())
                    return rowValue;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepSaKVP). Lekérdezést nem lehet végrehajtani.\n");
                    return rowValue;
                }
                if (!isExecutableQuery(query))
                {
                    return rowValue;
                }
                if (param.Key == null || param.Value == null)
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepSaKVP). Lekérdezést nem lehet végrehajtani.\n");
                    return rowValue;
                }
                MySqlCommand cmd;
                try
                {
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                    //Execute command
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        rowValue = new string[dataReader.FieldCount];
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            rowValue[i] = dataReader.GetString(i);
                        }
                    }

                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepSaKVP).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                }
                return rowValue;
            }
            catch (ErrorDBMetroProblem) { return rowValue; }
        }
        /// <summary>
        /// executes a query that gives back list of strings, that covers a column of datas
        /// it uses some KVP to define paramters
        /// </summary>
        /// <param name="query">the query is needed</param>
        /// <param name="param">the list of paramters</param>
        /// <param name="paramNum">the amount of paramters</param>
        /// <returns>list of strings the covers a field of rows</returns>
        public List<string> execPrepGetOneColumnToListWithKVPList(string query, List<KeyValuePair<string, string>>param, int paramNum)
        //example query: SELECT orszag FROM orszagok
        {
            List<string> list = new List<string>();
            try
            {
                if (!isConnectionExsist())
                    return list;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepOneColumn). Lekérdezést nem lehet végrehajtani.\n");
                    return list;
                }
                if (!isExecutableQuery(query))
                {
                    return list;
                }
                if (!isPreparedParamCompletness(param, paramNum))
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepOneColumn). Lekérdezést nem lehet végrehajtani.\n");
                    return list;
                }
                MySqlDataReader dataReader = null;
                MySqlCommand cmd;
                try
                {
                    //Create Command
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    for (int i = 0; i < param.Count; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i].Key, param[i].Value);
                    }
                    //Create a data reader and Execute the command
                    dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader[0] + "");
                    }
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepOneColumn).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                    if (dataReader != null)
                    {
                        //close Data Reader
                        dataReader.Close();
                    }
                }
                //return list to be displayed
                return list;
            }
            catch (ErrorDBMetroProblem) { return list; }
        }
        /// <summary>
        /// executes a query that gives back list of strings, that covers a column of datas
        /// it uses only one KVP to define paramter
        /// </summary>
        /// <param name="query">the query is needed</param>
        /// <param name="param">the paramter in KVP</param>
        /// <returns>list of strings the covers a field of rows</returns>
        public List<string> execPrepGetOneColumnToListWithKVP(string query, KeyValuePair<string, string> param)
        //example query: SELECT orszag FROM orszagok
        {
            List<string> list = new List<string>();
            try
            {
                if (!isConnectionExsist())
                    return list;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva (ExecPrepOneColumn). Lekérdezést nem lehet végrehajtani.\n");
                    return list;
                }
                if (!isExecutableQuery(query))
                {
                    return list;
                }
                if (param.Key == null || param.Value == null)
                {
                    setErrorDataAndShow("Lekérdezési információk sérültek (ExecPrepOneColumn). Lekérdezést nem lehet végrehajtani.\n");
                    return list;
                }
                MySqlDataReader dataReader = null;
                MySqlCommand cmd;
                try
                {
                    //Create Command
                    cmd = new MySqlCommand(query, connection);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                    //Create a data reader and Execute the command
                    dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader[0] + "");
                    }
                }
                catch (MySqlException me)
                {
                    setErrorDataAndShow("Adatbázis lekérdezés hiba (ExecPrepOneColumn).\n" + me.Message/*+me.Number*/);
                }
                finally
                {
                    if (dataReader != null)
                    {
                        //close Data Reader
                        dataReader.Close();
                    }
                }
                //return list to be displayed
                return list;
            }
            catch (ErrorDBMetroProblem) { return list; }
        }
        #endregion

    }
}
