using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class ErrorServiceOrdering :Exception
    {
        public ErrorServiceOrdering(string message) : base(message)
        {

        }
    }
}
