using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.LogingIn
{
    public class ErrorServiceLoginInfoCollect : Exception
    {
        public ErrorServiceLoginInfoCollect(string message) : base(message)
        {

        }
    }
}
