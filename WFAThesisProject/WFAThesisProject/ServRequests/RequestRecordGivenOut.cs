using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServRequests
{
    public class RequestRecordGivenOut
    {
        public int keresId { get; set; }
        public string keresDatum { get; set; }
        public int termekId { get; set; }
        public string termekNev { get; set; }
        public string termekHely { get; set; }
        public int termekQuantId { get; set; }
        public int termekKiszerel { get; set; }
        public string termeKiszerelEgys { get; set; }
        public string termekBeszall { get; set; }

        public int keresMennyiseg { get; set; }
        public string teljesites { get; set; }

        public int userId { get; set; }
        public string userKeroNev { get; set; }
        public string userTerulet { get; set; }

        public string keresModosNev { get; set; }    //second-hand defined
    }
}
