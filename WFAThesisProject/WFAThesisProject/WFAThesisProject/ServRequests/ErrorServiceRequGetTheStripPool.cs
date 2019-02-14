using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.GeneralExceptions
{
    public class ErrorServiceRequOrderGetTheStripPool :Exception
    {
        public ErrorServiceRequOrderGetTheStripPool(string message) : base(message)
        {

        }
    }
}
