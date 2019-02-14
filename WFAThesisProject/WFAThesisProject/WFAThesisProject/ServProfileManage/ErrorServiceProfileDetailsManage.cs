using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ProfileManage
{
    public class ErrorServiceProfileDetailsManage :Exception
    {
        private string message;
        public ErrorServiceProfileDetailsManage(string message) :base(message)
        {
            this.message = message;
        }
    }
}
