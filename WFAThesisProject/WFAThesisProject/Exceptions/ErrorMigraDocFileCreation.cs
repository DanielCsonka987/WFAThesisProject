using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.Exceptions
{
    class ErrorMigraDocFileCreation : Exception
    {
        private string message;
        public ErrorMigraDocFileCreation(string message) :base(message)
        {
            this.message = message;
        }
    }
}
