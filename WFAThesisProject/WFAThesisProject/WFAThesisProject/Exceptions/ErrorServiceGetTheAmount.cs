using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.GeneralExceptions
{
    public class ErrorServiceGetTheAmount : Exception
    {
        public ErrorServiceGetTheAmount(string message) : base(message)
        {

        }
    }
}
