using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.GeneralExceptions
{
    public class ErrorServiceRequGetTheProdPool :Exception
    {
        public ErrorServiceRequGetTheProdPool(string message) : base(message)
        {

        }
    }
}
