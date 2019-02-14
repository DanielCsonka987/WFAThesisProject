using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceDeleteRecord :Exception
    {
        private string message;
        public ErrorServiceDeleteRecord(string message) : base(message)
        {
            this.message = message;
        }
    }
}
