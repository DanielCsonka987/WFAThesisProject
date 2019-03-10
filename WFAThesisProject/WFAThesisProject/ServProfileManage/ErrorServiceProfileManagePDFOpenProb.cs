using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServProfileManage
{
    public class ErrorServiceProfileManagePDFOpenProb :Exception
    {
        public ErrorServiceProfileManagePDFOpenProb(string message) : base(message)
        {

        }
    }
}
