using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class MainController
    {
        private FormServiceRightsWindow rightsWin;

        private void initRightsManagingSerevice(RightLevels rightToManegeRights, Control tileRights)
        {
            tileRights.Click += (e, p) =>
            {
                actServiceForSubEvents = FormMainServiceMode.OPENING;
                if (rightToManegeRights == RightLevels.READ)
                {
                    rightsWin = new FormServiceRightsWindow(mainWindow, false, dbci);
                }
                else if (rightToManegeRights == RightLevels.MODiFY)
                {
                    rightsWin = new FormServiceRightsWindow(mainWindow, true, dbci);
                }
            };
        }

    }
}
