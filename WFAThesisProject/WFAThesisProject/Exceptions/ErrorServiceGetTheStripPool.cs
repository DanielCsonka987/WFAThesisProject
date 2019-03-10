using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.GeneralExceptions
{
    public class ErrorServiceGetTheStripPool :Exception
    {
        public ErrorServiceGetTheStripPool(string message) : base(message)
        {

        }
    }
}
