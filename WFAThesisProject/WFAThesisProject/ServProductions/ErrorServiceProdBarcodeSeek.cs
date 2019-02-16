using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceProdBarcodeSeek : Exception
    {
        private string message;
        public ErrorServiceProdBarcodeSeek(string message) : base(message)
        {
            this.message = message;
        }
    }
}
