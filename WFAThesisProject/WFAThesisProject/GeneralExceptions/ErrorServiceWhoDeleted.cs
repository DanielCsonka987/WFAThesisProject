using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceWhoDeleted : Exception
    {
        private string message;
        public ErrorServiceWhoDeleted(string message) : base(message)
        {
            this.message = message;
        }
    }
}
