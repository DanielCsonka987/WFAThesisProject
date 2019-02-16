using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceRenewRecord : Exception
    {
        private string message;
        public ErrorServiceRenewRecord(string message) : base(message)
        {
            this.message = message;
        }
    }
}
