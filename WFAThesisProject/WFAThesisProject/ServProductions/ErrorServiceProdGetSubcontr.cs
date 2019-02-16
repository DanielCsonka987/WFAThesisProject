using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceProductGetSubcontr : Exception
    {
        private string message;
        public ErrorServiceProductGetSubcontr(string message) :base(message)
        {
            this.message = message;
        }
    }
}
