using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServRequests
{
    public class RequestRecordActive   //case of Called off and active
    {
        public string keresDatum { get; set; }
        public int termekId { get; set; }
        public string termekNev { get; set; }
        public int termekQuantId { get; set; }       //in case of managing, ex. quick ordering
        public int termekKiszerel { get; set; }
        public string termekKiszerelEgys { get; set; }
        public string termekBeszall { get; set; }

        public string termekHely { get; set; }
        public int keresMennyiseg { get; set; }

        public int userId { get; set; }
        public string userKeroNev { get; set; }
        public string userTerulet { get; set; }

        public string keresModosNev { get; set; }
    }
}
