using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServProfileManage
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
