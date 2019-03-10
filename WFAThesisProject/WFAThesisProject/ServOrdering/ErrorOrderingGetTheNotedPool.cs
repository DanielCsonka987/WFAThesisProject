using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class ErrorOrderingGetTheNotedPool :Exception
    {
        public ErrorOrderingGetTheNotedPool(string message) : base(message)
        {

        }
    }
}
