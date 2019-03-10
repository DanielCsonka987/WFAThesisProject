using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ProductFullRow
    {
        public string productName { get; set; }
        public string productSubcontr { get; set; }
        public string productDescr { get; set; }
        public string productQantUnit { set; get; }
        public int productDanger { get; set; }
        public string productSheet { get; set; }

        public int productStripping { get; set; }
        public int productQuantity { get; set; }
        public string productPlace { get; set; }
        public string productBarcode { get; set; }

        public int producQualId { get; set; }
        public int strippId { get; set; }
        public int productModifiedBy { get; set; }
        public string productModifiedThen { get; set; }
        public bool productValidity { get; set; }
    }
}
