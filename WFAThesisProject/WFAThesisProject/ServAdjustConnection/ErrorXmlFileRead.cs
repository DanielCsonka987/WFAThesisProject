using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorXmlFileRead : Exception
    {
        private string message;
        /// <summary>
        /// the part of the connection information manager 
        /// </summary>
        /// <param name="message">thrown error message in string</param>
        public ErrorXmlFileRead(string message) :base(message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
