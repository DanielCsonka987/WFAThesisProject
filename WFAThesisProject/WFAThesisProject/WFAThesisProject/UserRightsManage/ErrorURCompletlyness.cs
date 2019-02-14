using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserRightsManage
{
    public class ErrorUserRightCompletlyness : Exception
    {
        private string message;
        public ErrorUserRightCompletlyness(string message) :base(message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
