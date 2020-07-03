using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
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

            Units units = doc.GetUnits();

            Reference selected;

            try
            {
                selected = uidoc.Selection.PickObject(ObjectType.LinkedElement, "Select Element from Links");
            }
            catch { return Result.Cancelled; }

            ElementId id = selected.ElementId;

            ElementId linkid = selected.LinkedElementId;

            RevitLinkInstance linkinstance = doc.GetElement(id) as RevitLinkInstance;

            RemoteLink link = new RemoteLink(doc, linkinstance);

            Element linkedelement = link.Document.GetElement(linkid);

            if (!linkedelement.CanHaveTypeAssigned()) { return Result.Failed; }

            ElementId typeId = linkedelement.GetTypeId();

            ElementType type = link.Document.GetElement(typeId) as ElementType;

            RemoteType remotetype = new RemoteType(type, typeId, units);

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

            DrawDatagrid(datagrid, remotetype);

            DialogResult result = dialog.ShowDialog();

            if (result != DialogResult.OK) { return Result.Cancelled; }

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

            if (!link.Open(uiapp)) { return Result.Failed; }

            Transaction t1 = new Transaction(link.OpenDocument, "Assign Parameters");

            List<string[]> results = new List<string[]> { };

            string title = link.Title;

            try
            {
                t1.Start();

                foreach (string parameter in paramdict.Keys)
                {
                    string r = remotetype.EditParameter(link.OpenDocument, parameter, paramdict[parameter]);

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

            Link.GetResults(resultsdatagrid, results);

            resultsdialog.LinkDropDown.Items.Add(title);
            resultsdialog.LinkDropDown.Text = title;

            resultsdialog.ShowDialog();

            return Result.Succeeded;
        }
        internal static void DrawDatagrid(DataGridView datagrid, RemoteType remotetype)
        {
            foreach (RemoteParameter remoteparameter in remotetype.Parameters)
            {
                int index = datagrid.Rows.Add();
                datagrid.Rows[index].Cells["ParameterColumn"].Value = remoteparameter.Name;
                datagrid.Rows[index].Cells["TypeColumn"].Value = remoteparameter.Type;
                datagrid.Rows[index].Cells["ValueColumn"].Value = remoteparameter.Value;
            }
        }
    }
}
