using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
    internal struct Link
    {
        internal Link(Document doc, RevitLinkInstance linkinstance)
        {
            Document = linkinstance.GetLinkDocument();
            Type = doc.GetElement(linkinstance.GetTypeId()) as RevitLinkType;
            Title = Document.Title;
            IsLoaded = RevitLinkType.IsLoaded(doc, Type.Id);
            temppath = Path.GetTempPath() + "RemoteParameters\\";
            OpenDocument = null;
        }
        internal string temppath { get; }
        internal Document Document { get; }
        internal string Title { get; }
        internal RevitLinkType Type { get; }
        internal bool IsLoaded { get; }
        internal Document OpenDocument { get; set; }
        internal bool Open(UIApplication uiapp)
        {
            try
            {
                if (Document.IsWorkshared)
                {
                    Type.UnloadLocally(new SaveModifiedLinksForWorkshared());
                    OpenDocument = CreateLocal(uiapp, Document.PathName);
                }
                else
                {
                    Type.Unload(new SaveModifiedLinks());
                    OpenDocument = uiapp.Application.OpenDocumentFile(Document.PathName);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal bool Close(bool save)
        {
            try
            {
                if (save)
                {
                    if (Document.IsWorkshared)
                    {
                        Sync();

                        OpenDocument.Close(false);
                    }
                    else
                    {
                        OpenDocument.Close(true);
                    }
                }
                else
                {
                    OpenDocument.Close(false);
                }
                OpenDocument = null;

                Directory.Delete(temppath, true);

                return true;
            }
            catch
            {
                OpenDocument.Close(false);

                OpenDocument = null;

                Directory.Delete(temppath, true);

                return false;
            }
        }
        private Document CreateLocal(UIApplication uiapp, string path)
        {
            string modelname = Path.GetFileNameWithoutExtension(path);

            ModelPath modelpath = ModelPathUtils.ConvertUserVisiblePathToModelPath(path);

            Directory.CreateDirectory(temppath);

            ModelPath targetpath = ModelPathUtils.ConvertUserVisiblePathToModelPath(temppath + modelname);

            WorksharingUtils.CreateNewLocal(modelpath, targetpath);

            OpenOptions openOption = new OpenOptions();

            openOption.DetachFromCentralOption = DetachFromCentralOption.DoNotDetach;

            Document doc = uiapp.Application.OpenDocumentFile(targetpath, openOption);

            return doc;
        }
        private void Sync()
        {
            TransactWithCentralOptions transact = new TransactWithCentralOptions();
            SynchLockCallback transCallBack = new SynchLockCallback();
            transact.SetLockCallback(transCallBack);
            SynchronizeWithCentralOptions syncset = new SynchronizeWithCentralOptions();
            RelinquishOptions relinquishoptions = new RelinquishOptions(true)
            {
                CheckedOutElements = true
            };
            syncset.SetRelinquishOptions(relinquishoptions);

            OpenDocument.SynchronizeWithCentral(transact, syncset);
        }        
    }
    class DocumentUtils
    {
        internal static Dictionary<string, Link> GetAllLinks(Document doc)
        {
            Dictionary <string, Link> linksdict = new Dictionary<string, Link>();

            IList<Element> links = new FilteredElementCollector(doc).OfClass(typeof(RevitLinkInstance)).ToElements();

            foreach (RevitLinkInstance li in links)
            {
                Link lk = new Link(doc, li);

                if (lk.IsLoaded)
                {
                    if (!linksdict.ContainsKey(lk.Title))
                    {
                        linksdict.Add(lk.Title, lk);
                    }
                }
            }

            return linksdict;
        }        
        internal static void GetResults(DataGridView datagrid, List<string[]> results)
        {
            foreach(string[] p in results)
            {
                int index = datagrid.Rows.Add();
                datagrid.Rows[index].Cells["ParameterColumn"].Value = p[0];
                datagrid.Rows[index].Cells["ValueColumn"].Value = p[1];                
            }
        }
    }
    class Materials
    {
        internal static ElementId FindMaterialByName(Document doc, string name)
        {
            ICollection<ElementId> collmat = new FilteredElementCollector(doc).OfClass(typeof(Material)).ToElementIds();
            foreach (ElementId i in collmat)
            {
                if (name.ToLower() == doc.GetElement(i).Name.ToLower())
                {
                    return i;
                }
            }
            return null;
        }
        internal static List<string> GetDocumentMaterials(Document doc)
        {
            List<string> materials = new List<string>();
            ICollection<ElementId> collmat = new FilteredElementCollector(doc).OfClass(typeof(Material)).ToElementIds();
            foreach (ElementId i in collmat)
            {
                materials.Add(doc.GetElement(i).Name);
            }
            return materials;
        }
    }
    class Parameters
    {
        internal static string EditTypeParameter(ElementType type, Units units, string name, string value)
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
                        ElementId material = Materials.FindMaterialByName(type.Document, name);
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
        internal static string EditGlobalParameter(Document doc, Units units, string name, string value)
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
                            if (value == "Yes")
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

                            ElementId mat = Materials.FindMaterialByName(doc, value);

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
                        datagrid.Rows[index].Cells["ValueColumn"].Value = UnitUtils.ConvertFromInternalUnits(parameter.AsDouble(), dunit).ToString();
                    }
                    else if (parameter.StorageType == StorageType.Integer)
                    {
                        if (parameter.Definition.ParameterType.ToString() == "YesNo")
                        {
                            int b = parameter.AsInteger();

                            if (b == 0)
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
                        if (id.ToString() != "-1")
                        {
                            elementname = type.Document.GetElement(id).Name;
                        }
                        datagrid.Rows[index].Cells["ValueColumn"].Value = elementname;
                    }
                }
            }
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
                else if (parameter.GetValue().GetType() == typeof(ElementIdParameterValue))
                {
                    ElementIdParameterValue dvalue = parameter.GetValue() as ElementIdParameterValue;
                    datagrid.Rows[index].Cells["TypeColumn"].Value = "Element";
                    if (dvalue.Value.ToString() != "-1")
                    {
                        string elementname = linkdoc.GetElement(dvalue.Value).Name;
                        datagrid.Rows[index].Cells["ValueColumn"].Value = elementname;
                    }
                }
            }
        }
        internal static void GetCombinedElementTypeParameters(List<ElementType> types, Units units, DataGridView datagrid)
        {
            List<string> parameters = new List<string>();

            foreach (ElementType type in types)
            {
                ParameterSet parameterset = type.Parameters;

                foreach (Parameter parameter in parameterset)
                {

                    if (!parameter.IsReadOnly
                    && parameter.Definition.ParameterType != ParameterType.Invalid
                    && parameter.Definition.ParameterType != ParameterType.URL
                    && parameter.Definition.ParameterType != ParameterType.Image
                    && !parameters.Contains(parameter.Definition.Name)
                    )
                    {
                        parameters.Add(parameter.Definition.Name);
                        int row = datagrid.Rows.Add();
                        datagrid.Rows[row].Cells["ParameterColumn"].Value = parameter.Definition.Name;
                        datagrid.Rows[row].Cells["TypeColumn"].Value = parameter.Definition.ParameterType.ToString();
                    }
                }
            }

            foreach (ElementType type in types)
            {
                string link = type.Document.Title;

                int column = datagrid.Columns.Add(link, link);

                ParameterSet parameterset = type.Parameters;

                foreach (Parameter parameter in parameterset)
                {
                    for (int row = 0; row < datagrid.Rows.Count; row++)
                    {
                        if (datagrid.Rows[row].Cells["ParameterColumn"].Value.ToString() == parameter.Definition.Name)
                        {
                            if (parameter.StorageType == StorageType.Double)
                            {
                                UnitType utype = parameter.Definition.UnitType;
                                DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;
                                datagrid.Rows[row].Cells[column].Value = UnitUtils.ConvertFromInternalUnits(parameter.AsDouble(), dunit).ToString();
                            }
                            else if (parameter.StorageType == StorageType.Integer)
                            {
                                if (parameter.Definition.ParameterType.ToString() == "YesNo")
                                {
                                    int b = parameter.AsInteger();

                                    if (b == 0)
                                    {
                                        datagrid.Rows[row].Cells[column].Value = "No";
                                    }
                                    else
                                    {
                                        datagrid.Rows[row].Cells[column].Value = "Yes";
                                    }
                                }
                                else
                                {
                                    datagrid.Rows[row].Cells[column].Value = parameter.AsInteger().ToString();
                                }
                            }
                            else if (parameter.StorageType == StorageType.String)
                            {
                                datagrid.Rows[row].Cells[column].Value = parameter.AsString();
                            }
                            else if (parameter.StorageType == StorageType.ElementId && parameter.Definition.ParameterType == ParameterType.Material)
                            {
                                ElementId id = parameter.AsElementId();
                                string elementname = "";
                                if (id.ToString() != "-1")
                                {
                                    elementname = type.Document.GetElement(id).Name;
                                }
                                datagrid.Rows[row].Cells[column].Value = elementname;
                            }
                        }
                    }
                }
            }
        }
    }
    class SynchLockCallback : ICentralLockedCallback
    {
        public bool ShouldWaitForLockAvailability()
        {
            return false;
        }
    }
    class SaveModifiedLinksForWorkshared : ISaveSharedCoordinatesCallbackForUnloadLocally
    {
        public SaveModifiedLinksOptionsForUnloadLocally GetSaveModifiedLinksOptionForUnloadLocally(RevitLinkType link)
        {
            return SaveModifiedLinksOptionsForUnloadLocally.DoNotSaveLinks;
        }
    }
    class SaveModifiedLinks : ISaveSharedCoordinatesCallback
    {
        public SaveModifiedLinksOptions GetSaveModifiedLinksOption(RevitLinkType link)
        {
            return SaveModifiedLinksOptions.DoNotSaveLinks;
        }
    }
}
