using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class UserConnDetails
    {
        /// <summary>
        /// host url address
        /// </summary>
        public string host { get; set; }
        /// <summary>
        /// port which through possible the communication
        /// </summary>
        public string port { get; set; }
        /// <summary>
        /// name of the DataBase
        /// </summary>
        public string db { get; set; }
        /// <summary>
        /// username defined by DBMS
        /// </summary>
        public string user { get; set; }
        /// <summary>
        /// user password defined by DBMS
        /// </summary>
        public string pwd { get; set; }
        /// <summary>
        /// folder of PC, where PDF-s are downloaded
        /// </summary>
        public string output { get; set; }
        /// <summary>
        /// url of the SafetyDataSheets of productons
        /// </summary>
        public string input { get; set; }
        /// <summary>
        /// gerenral constructor
        /// </summary>
        public UserConnDetails() { }
        /// <summary>
        /// data-structure to handle the informations of DB connections
        /// </summary>
        /// <param name="host">host address</param>
        /// <param name="port">portnumber to DB</param>
        /// <param name="db">name of DB</param>
        /// <param name="user">name of the user</param>
        /// <param name="pwd">password of the user</param>
        /// <param name="outputFilesDest">the store of pdf-s on PC</param>
        /// <param name="safetyFilesPath">the path url of the SafetyDocument</param>
        public UserConnDetails(string host, string port, string db, string user, string pwd,
            string outputFilesDest, string safetyFilesPath)
        {
            this.host = host;
            this.port = port;
            this.db = db;
            this.user = user;
            this.pwd = pwd;
            this.output = outputFilesDest;
            this.input = safetyFilesPath;
        }
    }
}
