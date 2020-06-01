using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RemoteDataManager.CompareParameters;

namespace RemoteDataManager
{
    public partial class CompareParametersDialog : Form
    {
        public CompareParametersDialog()
        {
            InitializeComponent();

            this.CategoryDropDown.DataSource = CompareParameters.Categories;

            this.CategoryDropDown.SelectedItem = CompareParameters.Categories.First();
        }

        private void CategoryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> families = new List<string>();

            foreach(RemoteType type in CompareParameters.Types)
            {
                if(type.Category == this.CategoryDropDown.SelectedItem.ToString())
                {
                    families.Add(type.Family);
                }
            }

            List<string> uniquefamilies = families.Distinct().ToList();

            this.FamilyDropDown.DataSource = uniquefamilies;

            this.FamilyDropDown.SelectedItem = uniquefamilies.First();
        }

        private void FamilyDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> symbols = new List<string>();

            foreach (RemoteType type in CompareParameters.Types)
            {
                if (type.Category == this.CategoryDropDown.SelectedItem.ToString() && type.Family == this.FamilyDropDown.SelectedItem.ToString())
                {
                    symbols.Add(type.Name);
                }
            }

            List<string> uniquetypes = symbols.Distinct().ToList();

            this.FamilyDropDown.DataSource = uniquetypes;

            this.FamilyDropDown.SelectedItem = uniquetypes.First();
        }

        private void TypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
