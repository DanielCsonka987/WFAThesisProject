using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServProductions
{
    public class ErrorServiceProd :Exception
    {
        public ErrorServiceProd(string message) : base(message)
        {

        }
    }
}
