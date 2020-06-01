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

            ElementType type;

            ElementId id = selected.ElementId;

            ElementId linkid = selected.LinkedElementId;

            RevitLinkInstance linkinstance = doc.GetElement(id) as RevitLinkInstance;

            Document linkdoc = linkinstance.GetLinkDocument();

            string linkdocpath = linkdoc.PathName;

            Element linkedelement = linkdoc.GetElement(linkid);

            ElementId typeId;

            if (linkedelement.CanHaveTypeAssigned())
            {
                typeId = linkedelement.GetTypeId();

                type = linkdoc.GetElement(typeId) as ElementType;
            }
            else { return Result.Failed; }

            //DISPLAY WINDOW

            ParametersDialog dialog = new ParametersDialog();

            dialog.FamilyDropDown.Items.Add(type.FamilyName);
            dialog.FamilyDropDown.Text = type.FamilyName;
            dialog.FamilyDropDown.Enabled = false;

            dialog.TypeDropDown.Items.Add(type.Name);
            dialog.TypeDropDown.Text = type.Name;
            dialog.TypeDropDown.Enabled = false;

            dialog.LinkDropDown.Items.Add(linkdoc.Title);
            dialog.LinkDropDown.Text = linkdoc.Title;
            dialog.LinkDropDown.Enabled = false;

            DataGridView datagrid = dialog.ParametersDataGrid;

            Units units = doc.GetUnits();

            GetElementTypeParameters(type, units, datagrid);

            var result = dialog.ShowDialog();

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

            RevitLinkType link = doc.GetElement(linkinstance.GetTypeId()) as RevitLinkType;

            //OPEN LINK

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

                type = linkdoc.GetElement(typeId) as ElementType;

                foreach (string parameter in paramdict.Keys)
                {
                    string r = ChangeTypeParameter(type, units, parameter, paramdict[parameter]);

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
        internal static void GetElementTypeParameters(ElementType type, Units units, DataGridView datagrid)
        {
            ParameterSet parameters = type.Parameters;

            foreach (Parameter parameter in parameters)
            {
                if (parameter.IsReadOnly) { continue; }

                if (!parameter.IsReadOnly
                    && parameter.Definition.ParameterType != ParameterType.Invalid
                    && parameter.Definition.ParameterType != ParameterType.URL
                    && parameter.Definition.ParameterType != ParameterType.Image
                    )
                {
                    int index = datagrid.Rows.Add();
                    datagrid.Rows[index].Cells["IdColumn"].Value = parameter.Id.IntegerValue;
                    datagrid.Rows[index].Cells["ParameterColumn"].Value = parameter.Definition.Name;
                    datagrid.Rows[index].Cells["TypeColumn"].Value = parameter.Definition.ParameterType.ToString();
                    if (parameter.StorageType == StorageType.Double)
                    {
                        UnitType utype = parameter.Definition.UnitType;
                        DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;
                        datagrid.Rows[index].Cells["ValueColumn"].Value = UnitUtils.ConvertFromInternalUnits(parameter.AsDouble(),dunit).ToString();
                    }
                    else if (parameter.StorageType == StorageType.Integer)
                    {
                        if(parameter.Definition.ParameterType.ToString() == "YesNo")
                        {
                            int b = parameter.AsInteger();

                            if(b == 0)
                            {
                                datagrid.Rows[index].Cells["ValueColumn"].Value = "No";
                            }
                            else
                            {
                                datagrid.Rows[index].Cells["ValueColumn"].Value = "Yes";
                            }                            
                        }
                        else
                        {
                            datagrid.Rows[index].Cells["ValueColumn"].Value = parameter.AsInteger().ToString();
                        }

                        
                    }
                    else if (parameter.StorageType == StorageType.String)
                    {
                        datagrid.Rows[index].Cells["ValueColumn"].Value = parameter.AsString();
                    }
                    else if (parameter.StorageType == StorageType.ElementId && parameter.Definition.ParameterType == ParameterType.Material)
                    {
                        ElementId id = parameter.AsElementId();
                        string elementname = "";
                        if(id.ToString() != "-1")
                        {
                            elementname = type.Document.GetElement(id).Name;
                        }
                        datagrid.Rows[index].Cells["ValueColumn"].Value = elementname;
                    }
                }
            }
        }
        private static string ChangeTypeParameter(ElementType type, Units units, string name, string value)
        {
            try
            {
                Parameter parameter = type.LookupParameter(name);

                if (parameter != null)
                {
                    string paramtype = parameter.Definition.ParameterType.ToString();

                    if (paramtype == "Text" | paramtype == "URL")
                    {
                        parameter.Set(value);
                    }
                    else if (paramtype == "Integer")
                    {
                        int.TryParse(value, out int dp);
                        parameter.Set(dp);
                    }
                    else if (paramtype == "Number")
                    {
                        Double.TryParse(value, out double dp);
                        parameter.Set(dp);
                    }
                    else if (paramtype == "Length")
                    {
                        UnitType utype = parameter.Definition.UnitType;
                        DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;
                        Double.TryParse(value, out double dp);
                        double dp1 = UnitUtils.ConvertToInternalUnits(dp, dunit);
                        parameter.Set(dp1);
                    }
                    else if (paramtype == "Area")
                    {
                        UnitType utype = parameter.Definition.UnitType;
                        DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;
                        Double.TryParse(value, out double dp);
                        double dp1 = UnitUtils.ConvertToInternalUnits(dp, dunit);
                        parameter.Set(dp1);
                    }
                    else if (paramtype == "Volume")
                    {
                        UnitType utype = parameter.Definition.UnitType;
                        DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;
                        Double.TryParse(value, out double dp);
                        double dp1 = UnitUtils.ConvertToInternalUnits(dp, dunit);
                        parameter.Set(dp1);
                    }
                    else if (paramtype == "Angle")
                    {
                        Double.TryParse(value, out double dp);
                        double ap1 = UnitUtils.Convert(dp, DisplayUnitType.DUT_DECIMAL_DEGREES, DisplayUnitType.DUT_RADIANS);
                        parameter.Set(ap1);
                    }
                    else if (paramtype == "Slope")
                    {
                        Double.TryParse(value, out double dp);
                        parameter.Set(dp / 100);
                    }
                    else if (paramtype == "Currency")
                    {
                        Double.TryParse(value, out double dp);
                        parameter.Set(dp);
                    }
                    else if (paramtype == "MassDensity")
                    {
                        UnitType utype = parameter.Definition.UnitType;
                        DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;
                        Double.TryParse(value, out double dp);
                        double mp1 = UnitUtils.ConvertToInternalUnits(dp, dunit);
                        parameter.Set(mp1);
                    }
                    else if (paramtype == "YesNo")
                    {
                        if (value == "Yes")
                        {
                            parameter.Set(1);
                        }
                        else if (value == "No")
                        {
                            parameter.Set(0);
                        }
                    }
                    else if (paramtype == "Material")
                    {
                        ElementId material = Utilities.FindMaterialByName(type.Document, name);
                        if (material != null)
                        {
                            parameter.Set(material);
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
