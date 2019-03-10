using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class ErrorOrderingGetTheCancelledPool :Exception
    {
        public ErrorOrderingGetTheCancelledPool(string message) : base(message)
        {

        }
    }
}
