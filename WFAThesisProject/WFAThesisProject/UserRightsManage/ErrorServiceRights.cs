using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserRightsManage
{
    public class ErrorServiceRights : Exception
    {
        public ErrorServiceRights(string message) : base(message)
        {

        }
    }
}
