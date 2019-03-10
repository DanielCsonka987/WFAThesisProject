using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.Exceptions
{
    public class ErrorMigraDocFileOpening:Exception
    {
        public ErrorMigraDocFileOpening(string message) : base(message)
        {

        }
    }
}
