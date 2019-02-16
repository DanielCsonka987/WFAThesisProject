using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserRightsManage
{
    public class ErrorUserRightLength : Exception
    {
        private string message;
        /// <summary>
        /// the part of the UserRights definition - wrong length of 3NS
        /// </summary>
        /// <param name="message"></param>
        public ErrorUserRightLength(string message) :base(message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
