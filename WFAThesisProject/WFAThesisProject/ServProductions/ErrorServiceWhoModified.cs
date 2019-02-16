using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceWhoModified : Exception
    {
        private string message;
        public ErrorServiceWhoModified(string message) : base(message)
        {
            this.message = message;
        }
    }
}
