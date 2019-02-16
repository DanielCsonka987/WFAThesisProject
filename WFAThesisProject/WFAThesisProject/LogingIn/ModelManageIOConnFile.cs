using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace WFAThesisProject
{
    class ModelManageIOConnFile
    {
        private string path = "connectionConfig.xml";
        private UserConnDetails connDetails;

        public ModelManageIOConnFile()
        {

        }
        /// <summary>
        /// consists of the data writting to xml file to save connection infos
        /// </summary>
        /// <param name="ucd"></param>
        public void writeConnDatas(UserConnDetails ucd)
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Connection");

                    writer.WriteElementString("host", ucd.host);
                    writer.WriteElementString("port", ucd.port);
                    writer.WriteElementString("DBname", ucd.db);
                    writer.WriteElementString("user", ucd.user);
                    writer.WriteElementString("password", ucd.pwd);
                    writer.WriteElementString("pdfOutputOrders", ucd.output);
                    writer.WriteElementString("pdfInputSafeSheets", ucd.input);

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch
            {
                throw new ErrorXmlFileWrite("A kapcsolódási információk nem menthetőek el!");
            }
        }
        /// <summary>
        /// revise the existance of the specific containter of connection details
        /// </summary>
        public void reviseXmlFileExists()
        {
            if (!File.Exists(path))
            {
                throw new ErrorXmlFileRead("A kapcoslati információkat tartalmazó XML file nem található" +
                    "Kérem állítsa be a kapcsolati paramétereket!");
            }
        }
        /// <summary>
        /// consists of the data reading from xml file to gain connection infos
        /// </summary>
        public void readConnDatas()
        {
            try
            {
                List<string> attrib = new List<string>();
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList nodelist = doc.SelectNodes("/Connection");
                foreach (XmlNode node in nodelist)
                {
                    attrib.Add(node.SelectSingleNode("host").InnerText);
                    attrib.Add(node.SelectSingleNode("port").InnerText);
                    attrib.Add(node.SelectSingleNode("DBname").InnerText);
                    attrib.Add(node.SelectSingleNode("user").InnerText);
                    attrib.Add(node.SelectSingleNode("password").InnerText);
                    attrib.Add(node.SelectSingleNode("pdfOutputOrders").InnerText);
                    attrib.Add(node.SelectSingleNode("pdfInputSafeSheets").InnerText);
                }
                connDetails = new UserConnDetails(
                    attrib[0], attrib[1], attrib[2], attrib[3], attrib[4], attrib[5],
                     attrib[6]);

            }
            catch
            {
                throw new ErrorXmlFileRead("A kapcsolódási információk kiolvasása sikertelen!");
            }

        }
        /// <summary>
        /// getter of the collected datas from xml file to have connection infos
        /// when the connection details are not changed
        /// </summary>
        /// <returns></returns>
        public UserConnDetails getConnInfos()
        {
            return connDetails;
        }
    }
}
