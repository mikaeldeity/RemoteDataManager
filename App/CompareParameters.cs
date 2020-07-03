using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace RemoteDataManager
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    class CompareParameters : IExternalCommand
    {
        internal static Units Units;

        internal static Dictionary<string, RemoteLink> LinksDict;

        internal static Dictionary<string, Dictionary<string, Dictionary<string, List<ElementType>>>> Database;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {            
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Database = new Dictionary<string, Dictionary<string, Dictionary<string, List<ElementType>>>>();

            Units = doc.GetUnits();

            LinksDict = DocumentUtils.GetAllLinks(doc);

            foreach (string link in LinksDict.Keys)
            {
                Document linkdoc = LinksDict[link].Document;

                IList<Element> typecollector = new FilteredElementCollector(linkdoc).OfClass(typeof(ElementType)).ToElements();

                foreach(Element el in typecollector)
                {
                    ElementType type = el as ElementType;

                    if(type.Category == null) { continue; }

                    string category = type.Category.Name;

                    string family = type.FamilyName;

                    string name = type.Name;

                    if (!Database.ContainsKey(category))
                    {
                        Database.Add(category, new Dictionary<string, Dictionary<string, List<ElementType>>>());
                    }

                    if (!Database[category].ContainsKey(family))
                    {
                        Database[category].Add(family, new Dictionary<string, List<ElementType>>());
                    }

                    if (!Database[category][family].ContainsKey(name))
                    {
                        Database[category][family].Add(name, new List<ElementType>());
                    }

                    Database[category][family][name].Add(type);
                }
            }

            CompareParametersDialog dialog = new CompareParametersDialog();

            DialogResult result = dialog.ShowDialog();

            if (result != DialogResult.OK) { return Result.Cancelled; }

            for(int i = 2; i < dialog.TypesDatagrid.Columns.Count; i++)
            {

            }

            return Result.Succeeded;
        }        
    }
}
