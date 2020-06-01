using DB = Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDataManager
{
    public partial class GlobalParametersDialog : Form
    {
        public GlobalParametersDialog()
        {
            InitializeComponent();
        }

        private void LinkDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParametersDataGrid.Rows.Clear();

            DB.Document linkdoc = EditGlobalParameters.LinksDict[LinkDropDown.Text];

            if(linkdoc != null)
            {
                EditGlobalParameters.GetLinkGlobalParameters(linkdoc, EditGlobalParameters.Units, ParametersDataGrid);
            }
        }        
    }
}
