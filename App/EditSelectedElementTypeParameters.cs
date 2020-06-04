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
    class EditSelectedElementTypeParameters : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Reference selected;

            try
            {
                selected = uidoc.Selection.PickObject(ObjectType.LinkedElement, "Select Element from Links");
            }
            catch { return Result.Cancelled; }

            ElementId id = selected.ElementId;

            ElementId linkid = selected.LinkedElementId;

            RevitLinkInstance linkinstance = doc.GetElement(id) as RevitLinkInstance;

            Link link = new Link(doc, linkinstance);

            Element linkedelement = link.Document.GetElement(linkid);

            if (!linkedelement.CanHaveTypeAssigned()) { return Result.Failed; }

            ElementId typeId = linkedelement.GetTypeId();

            ElementType type = link.Document.GetElement(typeId) as ElementType;

            ParametersDialog dialog = new ParametersDialog();

            dialog.FamilyDropDown.Items.Add(type.FamilyName);
            dialog.FamilyDropDown.Text = type.FamilyName;
            dialog.FamilyDropDown.Enabled = false;

            dialog.TypeDropDown.Items.Add(type.Name);
            dialog.TypeDropDown.Text = type.Name;
            dialog.TypeDropDown.Enabled = false;

            dialog.LinkDropDown.Items.Add(link.Title);
            dialog.LinkDropDown.Text = link.Title;
            dialog.LinkDropDown.Enabled = false;

            DataGridView datagrid = dialog.ParametersDataGrid;

            Units units = doc.GetUnits();

            Parameters.GetElementTypeParameters(type, units, datagrid);

            DialogResult result = dialog.ShowDialog();

            if(result != DialogResult.OK) { return Result.Cancelled; }            

            Dictionary<string, string> paramdict = new Dictionary<string, string>();

            for(int i=0; i< datagrid.Rows.Count; i++)
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

            if(paramdict.Keys.Count == 0) { return Result.Cancelled; }

            if(!link.Open(uiapp)) { return Result.Failed; }

            Transaction t1 = new Transaction(link.OpenDocument, "Assign Parameters");

            List<string[]> results = new List<string[]> { };

            string title = link.Title;

            try
            {
                t1.Start();

                type = link.OpenDocument.GetElement(typeId) as ElementType;

                foreach (string parameter in paramdict.Keys)
                {
                    string r = Parameters.ChangeTypeParameter(type, units, parameter, paramdict[parameter]);

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
