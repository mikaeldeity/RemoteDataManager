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

namespace RemoteDataManager
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    class EditGlobalParameters : IExternalCommand
    {
        internal static Dictionary<string, Document> LinksDict = new Dictionary<string, Document>();

        internal static Units Units;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Units = doc.GetUnits();

            IList<Element> links = new FilteredElementCollector(doc).OfClass(typeof(RevitLinkInstance)).ToElements();

            LinksDict = new Dictionary<string, Document>();

            foreach (RevitLinkInstance li in links)
            {
                RevitLinkType linktype = doc.GetElement(li.GetTypeId()) as RevitLinkType;

                if (RevitLinkType.IsLoaded(doc, linktype.Id))
                {
                    if (!LinksDict.ContainsKey(li.GetLinkDocument().Title))
                    {
                        LinksDict.Add(li.GetLinkDocument().Title, li.GetLinkDocument());
                    }
                }                
            }

            //DISPLAY WINDOW

            GlobalParametersDialog dialog = new GlobalParametersDialog();

            string[] linkarray = LinksDict.Keys.ToArray();

            DataGridView datagrid = dialog.ParametersDataGrid;

            Document linkdoc = LinksDict[linkarray.First()];
            
            dialog.LinkDropDown.Items.AddRange(linkarray);
            dialog.LinkDropDown.Text = linkarray.First();            

            GetLinkGlobalParameters(linkdoc, Units, datagrid);

            var result = dialog.ShowDialog();            

            if(result != DialogResult.OK) { return Result.Cancelled; }

            linkdoc = LinksDict[dialog.LinkDropDown.Text];

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

            RevitLinkType link = null;

            foreach (RevitLinkInstance li in links)
            {
                if(li.GetLinkDocument().Title == linkdoc.Title)
                {
                    link = doc.GetElement(li.GetTypeId()) as RevitLinkType;
                }
            }

            if(link == null) { return Result.Failed; }

            //OPEN LINK

            string linkdocpath = linkdoc.PathName;

            string temppath = Path.GetTempPath() + "RemoteParameters\\";

            try
            {
                if (linkdoc.IsWorkshared)
                {
                    link.UnloadLocally(new SaveModifiedLinksForWorkshared());
                    linkdoc = Utilities.CreateLocal(uiapp, linkdocpath, temppath);
                }
                else
                {
                    link.Unload(new SaveModifiedLinks());
                    linkdoc = uiapp.Application.OpenDocumentFile(linkdocpath);
                }
            }
            catch (Exception e)
            {
                TaskDialog.Show("Error", e.Message);
                return Result.Failed;
            }

            Transaction t1 = new Transaction(linkdoc, "Assign Parameters");

            List<string[]> results = new List<string[]> { };

            string title = linkdoc.Title;

            try
            {
                t1.Start();

                foreach (string parameter in paramdict.Keys)
                {
                    string r = ChangeGlobalParameter(linkdoc, Units, parameter, paramdict[parameter]);

                    results.Add(new string[] { parameter, r });
                }

                t1.Commit();

                if (linkdoc.IsWorkshared)
                {
                    Utilities.SyncDocument(linkdoc);

                    linkdoc.Close(false);

                    Directory.Delete(temppath, true);
                }
                else
                {
                    linkdoc.Close(true);
                }
            }
            catch (Exception e)
            {
                if (t1.HasStarted())
                {
                    t1.RollBack();
                }

                linkdoc.Close(false);

                if (Directory.Exists(temppath))
                {
                    Directory.Delete(temppath, true);
                }

                TaskDialog.Show("Error", e.Message);

                return Result.Failed;
            }

            link.Reload();

            Results resultsdialog = new Results();

            var resultsdatagrid = resultsdialog.ResultsDatagrid;

            Utilities.GetResults(resultsdatagrid, results);

            resultsdialog.LinkDropDown.Items.Add(title);
            resultsdialog.LinkDropDown.Text = title;

            resultsdialog.ShowDialog();

            //TaskDialog.Show("Remote Parameters", "Completed");

            return Result.Succeeded;
        }
        internal static void GetLinkGlobalParameters(Document linkdoc, Units units, DataGridView datagrid)
        {
            datagrid.Rows.Clear();

            IList<ElementId> globalparamids = GlobalParametersManager.GetGlobalParametersOrdered(linkdoc);            

            foreach (ElementId gid in globalparamids)
            {
                GlobalParameter parameter = linkdoc.GetElement(gid) as GlobalParameter;
                if (!GlobalParametersManager.IsValidGlobalParameter(linkdoc, parameter.Id)) { continue; }
                if (parameter.IsDrivenByFormula) { continue; }

                int index = datagrid.Rows.Add();
                datagrid.Rows[index].Cells["IdColumn"].Value = parameter.Id.IntegerValue;
                datagrid.Rows[index].Cells["ParameterColumn"].Value = parameter.Name;
                if (parameter.GetValue().GetType() == typeof(StringParameterValue))
                {
                    StringParameterValue dvalue = parameter.GetValue() as StringParameterValue;
                    datagrid.Rows[index].Cells["TypeColumn"].Value = "Text";
                    datagrid.Rows[index].Cells["ValueColumn"].Value = dvalue.Value;
                }
                else if (parameter.GetValue().GetType() == typeof(IntegerParameterValue))
                {
                    IntegerParameterValue dvalue = parameter.GetValue() as IntegerParameterValue;
                    datagrid.Rows[index].Cells["TypeColumn"].Value = "Integer";
                    datagrid.Rows[index].Cells["ValueColumn"].Value = dvalue.Value.ToString();
                }
                else if (parameter.GetValue().GetType() == typeof(DoubleParameterValue))
                {
                    UnitType utype = parameter.GetDefinition().UnitType;
                    DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;

                    DoubleParameterValue dvalue = parameter.GetValue() as DoubleParameterValue;
                    datagrid.Rows[index].Cells["TypeColumn"].Value = "Number";
                    datagrid.Rows[index].Cells["ValueColumn"].Value = UnitUtils.ConvertFromInternalUnits(dvalue.Value, dunit).ToString();
                }
                else if(parameter.GetValue().GetType() == typeof(ElementIdParameterValue))
                {
                    ElementIdParameterValue dvalue = parameter.GetValue() as ElementIdParameterValue;
                    datagrid.Rows[index].Cells["TypeColumn"].Value = "Element";
                    if(dvalue.Value.ToString() != "-1")
                    {
                        string elementname = linkdoc.GetElement(dvalue.Value).Name;
                        datagrid.Rows[index].Cells["ValueColumn"].Value = elementname;
                    }
                }
            }
        }
        private static string ChangeGlobalParameter(Document doc, Units units, string name, string value)
        {
            try
            {
                IList<ElementId> globalparamids = GlobalParametersManager.GetGlobalParametersOrdered(doc);

                foreach (ElementId gid in globalparamids)
                {
                    GlobalParameter parameter = doc.GetElement(gid) as GlobalParameter;
                    if (!GlobalParametersManager.IsValidGlobalParameter(doc, parameter.Id)) { continue; }
                    if (parameter.IsDrivenByFormula) { continue; }
                    if (parameter.Name == name)
                    {
                        if (parameter.GetValue().GetType() == typeof(StringParameterValue))
                        {
                            StringParameterValue dvalue = parameter.GetValue() as StringParameterValue;
                            dvalue.Value = value;
                            parameter.SetValue(dvalue);
                        }
                        else if (parameter.GetValue().GetType() == typeof(IntegerParameterValue))
                        {
                            if(value == "Yes")
                            {
                                value = "1";
                            }
                            else
                            {
                                value = "0";
                            }
                            IntegerParameterValue dvalue = parameter.GetValue() as IntegerParameterValue;
                            dvalue.Value = int.Parse(value);
                            parameter.SetValue(dvalue);
                        }
                        else if (parameter.GetValue().GetType() == typeof(DoubleParameterValue))
                        {
                            DoubleParameterValue dvalue = parameter.GetValue() as DoubleParameterValue;
                            UnitType utype = parameter.GetDefinition().UnitType;
                            DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;
                            double dp = double.Parse(value);
                            dvalue.Value = UnitUtils.ConvertToInternalUnits(dp, dunit);
                            parameter.SetValue(dvalue);
                        }
                        else if (parameter.GetValue().GetType() == typeof(ElementIdParameterValue))
                        {
                            ElementIdParameterValue dvalue = parameter.GetValue() as ElementIdParameterValue;

                            ElementId mat = Utilities.FindMaterialByName(doc, value);

                            if (mat != null)
                            {
                                dvalue.Value = mat;
                                parameter.SetValue(dvalue);
                            }

                        }
                    }
                }
                return value;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
        }        
    }
}
