﻿using System;
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

            if (EditGlobalParameters.LinksDict[LinkDropDown.Text].Document != null)
            {
                EditGlobalParameters.GlobalParameters = new RemoteGlobalParameters(EditGlobalParameters.LinksDict[LinkDropDown.Text].Document, EditGlobalParameters.Units);

                EditGlobalParameters.DrawDatagrid(ParametersDataGrid, EditGlobalParameters.GlobalParameters);
            }
        }

        private void ParametersDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ParametersDataGrid.BeginEdit(false);
        }
    }
}
