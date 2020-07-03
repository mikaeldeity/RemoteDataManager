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
    internal struct RemoteLink
    {
        internal RemoteLink(Document doc, RevitLinkInstance linkinstance)
        {
            Document = linkinstance.GetLinkDocument();
            Type = doc.GetElement(linkinstance.GetTypeId()) as RevitLinkType;
            Title = Document.Title;
            DocumentPath = Document.PathName;
            IsWorkShared = Document.IsWorkshared;
            IsLoaded = RevitLinkType.IsLoaded(doc, Type.Id);
            TempPath = Path.GetTempPath() + "RemoteParameters\\";
            OpenDocument = null;
        }
        internal string TempPath { get; }
        internal string DocumentPath { get; }
        internal Document Document { get; }
        internal string Title { get; }
        internal RevitLinkType Type { get; }
        internal bool IsLoaded { get; }
        internal bool IsWorkShared { get; }
        internal Document OpenDocument { get; set; }        
        internal bool Open(UIApplication uiapp)
        {
            try
            {
                if (IsWorkShared)
                {
                    Type.UnloadLocally(new SaveModifiedLinksForWorkshared());
                    OpenDocument = CreateLocal(uiapp, DocumentPath);
                }
                else
                {
                    Type.Unload(new SaveModifiedLinks());
                    OpenDocument = uiapp.Application.OpenDocumentFile(DocumentPath);
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
                    if (IsWorkShared)
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
                //OpenDocument = null;

                if (Directory.Exists(TempPath))
                {
                    Directory.Delete(TempPath, true);
                }
                return true;
            }
            catch
            {
                OpenDocument.Close(false);

                //OpenDocument = null;

                if (Directory.Exists(TempPath))
                {
                    Directory.Delete(TempPath, true);
                }

                return false;
            }
        }
        private Document CreateLocal(UIApplication uiapp, string path)
        {
            string modelname = Path.GetFileNameWithoutExtension(path);

            ModelPath modelpath = ModelPathUtils.ConvertUserVisiblePathToModelPath(path);

            Directory.CreateDirectory(TempPath);

            ModelPath targetpath = ModelPathUtils.ConvertUserVisiblePathToModelPath(TempPath + modelname);

            WorksharingUtils.CreateNewLocal(modelpath, targetpath);

            OpenOptions openoptions = new OpenOptions
            {
                DetachFromCentralOption = DetachFromCentralOption.DoNotDetach
            };

            Document doc = uiapp.Application.OpenDocumentFile(targetpath, openoptions);

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
    internal struct RemoteType
    {
        internal RemoteType(ElementType type, ElementId typeId, Units units)
        {
            ElementType = type;
            TypeId = typeId;
            Units = units;
            Link = type.Document.Title;
            Parameters = new List<RemoteParameter>();
            Parameters = GetParameters();
        }
        internal Units Units { get; }
        internal ElementType ElementType { get; }
        internal ElementId TypeId { get; }
        internal string Link { get; }
        internal List<RemoteParameter> Parameters { get;}
        private List<RemoteParameter> GetParameters()
        {
            List<RemoteParameter> remoteparameters = new List<RemoteParameter>();

            ParameterSet parameters = ElementType.Parameters;

            foreach (Parameter parameter in parameters)
            {
                if (parameter.IsReadOnly) { continue; }

                if (!parameter.IsReadOnly
                    && parameter.Definition.ParameterType != ParameterType.Invalid
                    && parameter.Definition.ParameterType != ParameterType.URL
                    && parameter.Definition.ParameterType != ParameterType.Image
                    )
                {
                    remoteparameters.Add(new RemoteParameter(ElementType, parameter, Units));
                }
            }

            return remoteparameters;
        }
        internal string EditParameter(Document doc, string name, string value)
        {
            try
            {
                ElementType type = doc.GetElement(TypeId) as ElementType;

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
                        DisplayUnitType dunit = Units.GetFormatOptions(utype).DisplayUnits;
                        Double.TryParse(value, out double dp);
                        double dp1 = UnitUtils.ConvertToInternalUnits(dp, dunit);
                        parameter.Set(dp1);
                    }
                    else if (paramtype == "Area")
                    {
                        UnitType utype = parameter.Definition.UnitType;
                        DisplayUnitType dunit = Units.GetFormatOptions(utype).DisplayUnits;
                        Double.TryParse(value, out double dp);
                        double dp1 = UnitUtils.ConvertToInternalUnits(dp, dunit);
                        parameter.Set(dp1);
                    }
                    else if (paramtype == "Volume")
                    {
                        UnitType utype = parameter.Definition.UnitType;
                        DisplayUnitType dunit = Units.GetFormatOptions(utype).DisplayUnits;
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
                        DisplayUnitType dunit = Units.GetFormatOptions(utype).DisplayUnits;
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
                        ElementId material = FindMaterialByName(doc, name);
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
        internal ElementId FindMaterialByName(Document doc,string name)
        {
            ICollection<ElementId> collmat = new FilteredElementCollector(ElementType.Document).OfClass(typeof(Material)).ToElementIds();
            foreach (ElementId i in collmat)
            {
                if (name.ToLower() == doc.GetElement(i).Name.ToLower())
                {
                    return i;
                }
            }
            return null;
        }
    }
    internal struct RemoteParameter
    {
        internal RemoteParameter(ElementType type, Parameter parameter, Units units)
        {
            Name = parameter.Definition.Name;
            Type = parameter.Definition.ParameterType.ToString();
            Value = string.Empty;

            if (parameter.StorageType == StorageType.Double)
            {
                UnitType utype = parameter.Definition.UnitType;
                DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;
                Value = UnitUtils.ConvertFromInternalUnits(parameter.AsDouble(), dunit).ToString();
            }
            else if (parameter.StorageType == StorageType.Integer)
            {
                if (parameter.Definition.ParameterType.ToString() == "YesNo")
                {
                    int b = parameter.AsInteger();

                    if (b == 0)
                    {
                        Value = "No";
                    }
                    else
                    {
                        Value = "Yes";
                    }
                }
                else
                {
                    Value = parameter.AsInteger().ToString();
                }


            }
            else if (parameter.StorageType == StorageType.String)
            {
                Value = parameter.AsString();
            }
            else if (parameter.StorageType == StorageType.ElementId && parameter.Definition.ParameterType == ParameterType.Material)
            {
                ElementId id = parameter.AsElementId();
                string elementname = "";
                if (id.ToString() != "-1")
                {
                    elementname = type.Document.GetElement(id).Name;
                }
                Value = elementname;
            }
        }
        internal string Name { get; }
        internal string Type { get; }
        internal string Value { get; }
    }
    internal struct RemoteGlobalParameters
    {
        internal RemoteGlobalParameters(Document doc, Units units)
        {
            GlobalParameters = new List<RemoteGlobalParameter>();
            Units = units;
            IList<ElementId> globalparamids = GlobalParametersManager.GetGlobalParametersOrdered(doc);

            foreach (ElementId gid in globalparamids)
            {
                GlobalParameter parameter = doc.GetElement(gid) as GlobalParameter;
                if (!GlobalParametersManager.IsValidGlobalParameter(doc, parameter.Id)) { continue; }
                if (parameter.IsDrivenByFormula) { continue; }

                GlobalParameters.Add(new RemoteGlobalParameter(parameter, Units));
            }
        }
        internal Units Units { get; }
        internal List<RemoteGlobalParameter> GlobalParameters { get; }
        internal string EditParameter(Document doc, string name, string value)
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
                            DisplayUnitType dunit = Units.GetFormatOptions(utype).DisplayUnits;
                            double dp = double.Parse(value);
                            dvalue.Value = UnitUtils.ConvertToInternalUnits(dp, dunit);
                            parameter.SetValue(dvalue);
                        }
                        else if (parameter.GetValue().GetType() == typeof(ElementIdParameterValue))
                        {
                            ElementIdParameterValue dvalue = parameter.GetValue() as ElementIdParameterValue;

                            ElementId mat = FindMaterialByName(doc,value);

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
        internal ElementId FindMaterialByName(Document doc, string name)
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
    }
    internal struct RemoteGlobalParameter
    {
        internal RemoteGlobalParameter(GlobalParameter parameter, Units units)
        {
            Name = parameter.Name;
            Type = string.Empty;
            Value = string.Empty;

            if (parameter.GetValue().GetType() == typeof(StringParameterValue))
            {
                StringParameterValue dvalue = parameter.GetValue() as StringParameterValue;
                Type = "Text";
                Value = dvalue.Value;
            }
            else if (parameter.GetValue().GetType() == typeof(IntegerParameterValue))
            {
                IntegerParameterValue dvalue = parameter.GetValue() as IntegerParameterValue;
                Type = "Integer";
                Value = dvalue.Value.ToString();
            }
            else if (parameter.GetValue().GetType() == typeof(DoubleParameterValue))
            {
                UnitType utype = parameter.GetDefinition().UnitType;
                DisplayUnitType dunit = units.GetFormatOptions(utype).DisplayUnits;

                DoubleParameterValue dvalue = parameter.GetValue() as DoubleParameterValue;
                Type = "Number";
                Value = UnitUtils.ConvertFromInternalUnits(dvalue.Value, dunit).ToString();
            }
            else if (parameter.GetValue().GetType() == typeof(ElementIdParameterValue))
            {
                ElementIdParameterValue dvalue = parameter.GetValue() as ElementIdParameterValue;
                Type = "Element";
                if (dvalue.Value.ToString() != "-1")
                {
                    string elementname = parameter.Document.GetElement(dvalue.Value).Name;
                    Value = elementname;
                }
            }
        }
        internal string Name { get; }
        internal string Type { get; }
        internal string Value { get; }
    }
    class Link
    {
        internal static Dictionary<string, RemoteLink> GetAllLinks(Document doc)
        {
            Dictionary <string, RemoteLink> linksdict = new Dictionary<string, RemoteLink>();

            IList<Element> links = new FilteredElementCollector(doc).OfClass(typeof(RevitLinkInstance)).ToElements();

            foreach (RevitLinkInstance li in links)
            {
                RemoteLink lk = new RemoteLink(doc, li);

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