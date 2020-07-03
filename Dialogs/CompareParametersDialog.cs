using Autodesk.Revit.DB;
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
using static RemoteDataManager.CompareParameters;

namespace RemoteDataManager
{
    public partial class CompareParametersDialog : System.Windows.Forms.Form
    {
        public CompareParametersDialog()
        {
            InitializeComponent();

            List<string> categories = Database.Keys.ToList();

            categories.Sort();

            this.CategoryDropDown.DataSource = categories;
        }
        private void CategoryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = CategoryDropDown.SelectedItem.ToString();

            List<string> families = CompareParameters.Database[category].Keys.ToList();

            families.Sort();

            this.FamilyDropDown.DataSource = families;
        }
        private void FamilyDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = CategoryDropDown.SelectedItem.ToString();

            string family = FamilyDropDown.SelectedItem.ToString();

            List<string> types = CompareParameters.Database[category][family].Keys.ToList();

            types.Sort();

            this.TypeDropDown.DataSource = types;
        }
        private void TypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypesDatagrid.Rows.Clear();

            while(TypesDatagrid.ColumnCount > 2)
            {
                TypesDatagrid.Columns.RemoveAt(TypesDatagrid.ColumnCount - 1);
            }

            List<RemoteType> types = CompareParameters.Database[CategoryDropDown.SelectedItem.ToString()][FamilyDropDown.SelectedItem.ToString()][TypeDropDown.SelectedItem.ToString()];

            CompareParameters.DrawDatagrid(types, TypesDatagrid);

            //Parameters.GetCombinedElementTypeParameters(types, CompareParameters.Units, TypesDatagrid);

        }

        private void TypesDatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TypesDatagrid.BeginEdit(false);
        }
    }
}
