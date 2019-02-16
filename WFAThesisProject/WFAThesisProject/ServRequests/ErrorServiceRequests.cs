using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    class ErrorServiceRequests :Exception
    {
        public ErrorServiceRequests(string message) : base(message)
        {

        }
    }
}
