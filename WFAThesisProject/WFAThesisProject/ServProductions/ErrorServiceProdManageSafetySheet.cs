using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceProdManageSafetySheet : Exception
    {
        private string message;
        public ErrorServiceProdManageSafetySheet(string message) :base(message)
        {
            this.message = message;
        }
    }
}
