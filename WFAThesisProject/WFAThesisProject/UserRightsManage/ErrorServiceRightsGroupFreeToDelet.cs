using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserRightsManage
{
    public class ErrorServiceRightsGroupFreeToDelet :Exception
    {
        public ErrorServiceRightsGroupFreeToDelet(string message) : base(message)
        {

        }
    }
}
