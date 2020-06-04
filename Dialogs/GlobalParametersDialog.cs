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
using Utils;

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

            if(EditGlobalParameters.LinksDict[LinkDropDown.Text].Document != null)
            {
                Parameters.GetLinkGlobalParameters(EditGlobalParameters.LinksDict[LinkDropDown.Text].Document, EditGlobalParameters.Units, ParametersDataGrid);
            }
        }        
    }
}
