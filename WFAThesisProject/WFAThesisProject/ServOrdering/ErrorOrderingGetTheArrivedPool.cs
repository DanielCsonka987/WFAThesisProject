using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class ErrorOrderingGetTheArrivedPool :Exception
    {
        public ErrorOrderingGetTheArrivedPool(string message) : base(message)
        {

        }
    }
}
