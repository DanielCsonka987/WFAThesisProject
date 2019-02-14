using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorPersonalDetailsManage :Exception
    {
        private string message;
        public ErrorPersonalDetailsManage(string message) :base(message)
        {
            this.message = message;
        }
    }
}
