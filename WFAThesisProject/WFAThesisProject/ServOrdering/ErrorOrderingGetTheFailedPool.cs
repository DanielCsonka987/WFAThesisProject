using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class ErrorOrderingGetTheFailedPool :Exception
    {
        public ErrorOrderingGetTheFailedPool(string message) : base(message)
        {

        }
    }
}
