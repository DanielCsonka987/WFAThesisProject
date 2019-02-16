using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public partial class ServiceProductsWinController
    {

        /// <summary>
        /// part of the NEW record creations both in quantity and quality managing
        /// fills up the mCmbBxSubcontr
        /// </summary>
        private void fillAndAdjustSubcontr()
        {
            List<string> subcontrList = serviceProducts.getListOfSubcontr();
            for (int i = 0; i < subcontrList.Count; i++)
            {
                cmbbSubcontr.Items.Add(subcontrList[i]);
            }
        }
        /// <summary>
        /// part of almost purpose-mode of the window - except NEW case managing
        /// fills up the mCmbBxSubcontr and chooses the good ont
        /// </summary>
        /// <param name="subcontr"></param>
        private void fillAndAdjustSubcontr(string subcontr)
        {
            List<string> subcontrList = serviceProducts.getListOfSubcontr();
            for (int i = 0; i < subcontrList.Count; i++)
            {
                cmbbSubcontr.Items.Add(subcontrList[i]);
                if (subcontrList[i] == subcontr)
                {
                    cmbbSubcontr.SelectedText = subcontrList[i];
                    cmbbSubcontr.SelectedIndex = i;
                }


            }
        }
    }
}
