using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public partial class FormServiceRightsWindow : MetroFramework.Forms.MetroForm
    {
        private UserConnDetails dbci;


        public FormServiceRightsWindow(Form parent, RightLevels rights, UserConnDetails dbci)
        {
            InitializeComponent();
        }
    }
}
