using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceProdDownlSafetySheet : Exception
    {
        private string message;
        public ErrorServiceProdDownlSafetySheet(string message) : base(message)
        {
            this.message = message;
        }
    }
}
