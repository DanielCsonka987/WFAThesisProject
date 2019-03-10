using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class OrderingNoted
    {
        public int beszerId { get; set;}
        public int kiszerelId { get; set; }
        public string termekNev { get; set; }
        public string termekKiszer { get; set; }
        public string termekBeszall { get; set; }
        public string termekKod { get; set; }
        public string termekHely { get; set; }

        public string beszerzDatum { get; set; }
        public int beszerzMennyis { get; set; }

        public string redeloNev { get; set; }
        public string modositNev { get; set; }
    }
}
