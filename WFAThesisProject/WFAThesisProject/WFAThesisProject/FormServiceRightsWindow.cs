using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class FormServiceRightsWindow : MetroFramework.Forms.MetroForm
    {

        public FormServiceRightsWindow(Form parent, RightLevels rights, UserConnDetails dbci)
        {
            InitializeComponent();
        }
    }
}
