using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class ErrorOrderingSetBookedAsArrived :Exception
    {
        public ErrorOrderingSetBookedAsArrived(string message) : base(message)
        {

        }
    }
}
