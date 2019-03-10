using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServProfileManage
{
    public class ErrorServiceProfileMange :Exception
    {
        public ErrorServiceProfileMange(string message) :base(message)
        {

        }
    }
}
