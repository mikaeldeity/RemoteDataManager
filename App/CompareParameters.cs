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

        internal static Dictionary<string, Dictionary<string, Dictionary<string, List<RemoteType>>>> Database;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {            
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Database = new Dictionary<string, Dictionary<string, Dictionary<string, List<RemoteType>>>>();

            Units = doc.GetUnits();

            LinksDict = Link.GetAllLinks(doc);

            foreach (string link in LinksDict.Keys)
            {
                Document linkdoc = LinksDict[link].Document;

                IList<Element> typecollector = new FilteredElementCollector(linkdoc).OfClass(typeof(ElementType)).ToElements();

                foreach(Element el in typecollector)
                {
                    ElementType type = el as ElementType;

                    RemoteType remotetype = new RemoteType(type, type.GetTypeId(), Units);

                    if (type.Category == null) { continue; }

                    string category = type.Category.Name;

                    string family = type.FamilyName;

                    string name = type.Name;

                    if (!Database.ContainsKey(category))
                    {
                        Database.Add(category, new Dictionary<string, Dictionary<string, List<RemoteType>>>());
                    }

                    if (!Database[category].ContainsKey(family))
                    {
                        Database[category].Add(family, new Dictionary<string, List<RemoteType>>());
                    }

                    if (!Database[category][family].ContainsKey(name))
                    {
                        Database[category][family].Add(name, new List<RemoteType>());
                    }

                    Database[category][family][name].Add(remotetype);
                }
            }

            CompareParametersDialog dialog = new CompareParametersDialog();

            dialog.ShowDialog();

            return Result.Succeeded;
        }
        internal static void DrawDatagrid(List<RemoteType> types, DataGridView datagrid)
        {
            List<string> parameters = new List<string>();

            foreach (RemoteType type in types)
            {
                List<RemoteParameter> parameterset = type.Parameters;

                foreach (RemoteParameter parameter in parameterset)
                {
                    if (!parameters.Contains(parameter.Name))
                    {
                        parameters.Add(parameter.Name);
                        int row = datagrid.Rows.Add();
                        datagrid.Rows[row].Cells["ParameterColumn"].Value = parameter.Name;
                        datagrid.Rows[row].Cells["TypeColumn"].Value = parameter.Type;
                    }
                }
            }

            foreach (RemoteType type in types)
            {
                string link = type.Link;

                //DataGridViewCheckBoxColumn checkbokcolumn = new DataGridViewCheckBoxColumn();
                //checkbokcolumn.Name = link + "-edit";
                //checkbokcolumn.HeaderText = "Edit";
                //int editcolumn = datagrid.Columns.Add(checkbokcolumn);

                int column = datagrid.Columns.Add(link, link);

                List<RemoteParameter> parameterset = type.Parameters;

                foreach (RemoteParameter parameter in parameterset)
                {
                    for (int row = 0; row < datagrid.Rows.Count; row++)
                    {
                        if (datagrid.Rows[row].Cells["ParameterColumn"].Value.ToString() == parameter.Name)
                        {
                            datagrid.Rows[row].Cells[column].Value = parameter.Value;                            
                        }
                    }
                }
            }
        }
    }
}
