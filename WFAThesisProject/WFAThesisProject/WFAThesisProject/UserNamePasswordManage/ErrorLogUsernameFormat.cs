using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserNamePasswordManage
{
    public class ErrorLogUsernameFormat : Exception
    {
        private string message;
        private string wrongName;
        /// <summary>
        /// the part of loggingIn and userPesonalManagement - unaccaptable type of username
        /// </summary>
        /// <param name="message"></param>
        public ErrorLogUsernameFormat(string name, string message) : base(message)
        {
            this.message = message;
            this.wrongName = name;
        }
        public string getMessage()
        {
            return message;
        }
        public string getWrongUsername()
        {
            return wrongName;
        }
    }
}
