using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.LogingIn
{
    public class ErrorServiceLoginAuthentic :Exception
    {
        public ErrorServiceLoginAuthentic(string message) : base(message)
        {

        }
    }
}
