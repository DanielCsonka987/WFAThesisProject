using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceUpdateRecord : Exception
    {
        private string message;
        public ErrorServiceUpdateRecord(string message) : base(message)
        {
            this.message = message;
        }
    }
}
