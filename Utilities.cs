using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDataManager
{
    class Utilities
    {
        internal static Document CreateLocal(UIApplication app, string path, string temppath)
        {
            string modelname = Path.GetFileNameWithoutExtension(path);

            ModelPath modelpath = ModelPathUtils.ConvertUserVisiblePathToModelPath(path);

            Directory.CreateDirectory(temppath);

            ModelPath targetpath = ModelPathUtils.ConvertUserVisiblePathToModelPath(temppath + modelname);

            WorksharingUtils.CreateNewLocal(modelpath, targetpath);

            OpenOptions openOption = new OpenOptions();

            openOption.DetachFromCentralOption = DetachFromCentralOption.DoNotDetach;

            Document doc = app.Application.OpenDocumentFile(targetpath, openOption);

            return doc;
        }
        internal static void SyncDocument(Document doc)
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

            doc.SynchronizeWithCentral(transact, syncset);
        }
        internal static ElementId FindMaterialByName(Document doc, string name)
        {
            FilteredElementCollector materialcollector = new FilteredElementCollector(doc);
            ICollection<ElementId> collmat = materialcollector.OfClass(typeof(Material)).ToElementIds();
            foreach (ElementId i in collmat)
            {
                if(name.ToLower() == doc.GetElement(i).Name.ToLower())
                {
                    return i;
                }

            }
            return null;
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
