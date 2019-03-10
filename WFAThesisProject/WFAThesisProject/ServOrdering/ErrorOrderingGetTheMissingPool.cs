using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class ErrorOrderingGetTheMissingPool : Exception
    {
        public ErrorOrderingGetTheMissingPool(string message) : base(message)
        {

        }
    }
}
