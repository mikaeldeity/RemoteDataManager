using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDataManager
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    class CompareParameters : IExternalCommand
    {
        internal static Units Units;

        internal static Dictionary<string, Document> LinksDict = new Dictionary<string, Document>();

        internal static List<string> Categories = new List<string>();

        internal static List<string> Families = new List<string>();

        internal static List<RemoteType> Types = new List<RemoteType>();

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
                    LinksDict[li.GetLinkDocument().Title] = li.GetLinkDocument();
                }
            }

            //GET FAMILIES AND CAT

            foreach (string link in LinksDict.Keys)
            {
                Document linkdoc = LinksDict[link];

                //Database[linkdoc.Title] = new Dictionary<string, Dictionary<string, Dictionary<string, ElementType>>>();

                IList<Element> typecollector = new FilteredElementCollector(linkdoc).OfClass(typeof(ElementType)).ToElements();

                foreach(Element el in typecollector)
                {
                    ElementType type = el as ElementType;

                    RemoteType remotetype = new RemoteType(type);

                    Types.Add(remotetype);

                    if (!Categories.Contains(remotetype.Category))
                    {
                        Categories.Add(remotetype.Category);
                    }
                }
            }

            CompareParametersDialog dialog = new CompareParametersDialog();

            dialog.ShowDialog();

            return Result.Succeeded;
        }
        public struct RemoteType
        {
            public RemoteType(ElementType type)
            {
                Name = type.Name;
                Type = type;
                Link = type.Document;
                Family = type.FamilyName;
                Category = Link.GetElement(type.get_Parameter(BuiltInParameter.ELEM_CATEGORY_PARAM).AsElementId()).Name;
            }
            public string Name { get; }
            public ElementType Type { get; }            
            public Document Link { get; }
            public string Family { get; }
            public string Category { get; }
        }
    }
}
