using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ProductStrippingPart
    {
        public int productStripping { get; set; }
        public int productQuantity { get; set; }
        public string productPlace { get; set; }
        public string productBarcode { get; set; }

        public int productIndex { get; set; }
        public int productDeletedBy { get; set; }
        public string productModifyedThen { get; set; }
        public bool productValidity { get; set; }
    }
}
