using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserNamePasswordManage
{
    public class ErrorLogPassContent : Exception
    {
        private string message;
        private string wrongUsername;
        /// <summary>
        /// the part of loggingIn and userPesonalManagement - unaccaptable content of password
        /// </summary>
        /// <param name="message"></param>
        public ErrorLogPassContent(string pwd,  string message) :base(message)
        {
            this.message = message;
            this.wrongUsername = pwd;
        }
        public string getMessage()
        {
            return message;
        }
        public string getWrongPwd()
        {
            return wrongUsername;
        }
    }
}
