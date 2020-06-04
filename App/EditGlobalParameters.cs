using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace RemoteDataManager
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    class EditGlobalParameters : IExternalCommand
    {
        internal static Dictionary<string, Link> LinksDict;

        internal static Units Units;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Units = doc.GetUnits();

            LinksDict = DocumentUtils.GetAllLinks(doc);

            GlobalParametersDialog dialog = new GlobalParametersDialog();

            string[] linkarray = LinksDict.Keys.ToArray();

            DataGridView datagrid = dialog.ParametersDataGrid;

            Link link = LinksDict[linkarray.First()];

            dialog.LinkDropDown.Items.AddRange(linkarray);
            dialog.LinkDropDown.Text = linkarray.First();            

            Parameters.GetLinkGlobalParameters(link.Document, Units, datagrid);

            var result = dialog.ShowDialog();            

            if(result != DialogResult.OK) { return Result.Cancelled; }

            link = LinksDict[dialog.LinkDropDown.Text];

            Dictionary<string, string> paramdict = new Dictionary<string, string>();

            for (int i = 0; i < datagrid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(datagrid.Rows[i].Cells["EditColumn"].Value) == true)
                {
                    string p = (string)datagrid.Rows[i].Cells["ParameterColumn"].Value;

                    if (datagrid.Rows[i].Cells["ValueColumn"].Value != null)
                    {
                        paramdict.Add(p, datagrid.Rows[i].Cells["ValueColumn"].Value.ToString());
                    }
                    else
                    {
                        paramdict.Add(p, string.Empty);
                    }
                }
            }

            if (paramdict.Keys.Count == 0) { return Result.Cancelled; }

            if(!link.Open(uiapp)) { return Result.Failed; }

            Transaction t1 = new Transaction(link.OpenDocument, "Assign Parameters");

            List<string[]> results = new List<string[]> { };

            string title = link.Title;

            try
            {
                t1.Start();

                foreach (string parameter in paramdict.Keys)
                {
                    string r = Parameters.EditGlobalParameter(link.OpenDocument, Units, parameter, paramdict[parameter]);

                    results.Add(new string[] { parameter, r });
                }

                t1.Commit();

                link.Close(true);
            }
            catch
            {
                if (t1.HasStarted())
                {
                    t1.RollBack();
                }

                link.Close(false);

                return Result.Failed;
            }

            link.Type.Reload();

            Results resultsdialog = new Results();

            var resultsdatagrid = resultsdialog.ResultsDatagrid;

            DocumentUtils.GetResults(resultsdatagrid, results);

            resultsdialog.LinkDropDown.Items.Add(title);
            resultsdialog.LinkDropDown.Text = title;

            resultsdialog.ShowDialog();

            return Result.Succeeded;
        }        
    }
}
