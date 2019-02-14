using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorUserRightFormat : Exception
    {
        private string message;
        /// <summary>
        /// the part of the UserRights definition - wrong format of 3NS
        /// </summary>
        /// <param name="message"></param>
        public ErrorUserRightFormat(string message) :base(message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
