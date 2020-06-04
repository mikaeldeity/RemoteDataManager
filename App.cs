using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace RemoteDataManager
{
    public class App : IExternalApplication
    {
        static void AddRibbonPanel(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Remote Data Manager");

            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData b1Data = new PushButtonData("Type", "Type", thisAssemblyPath, "RemoteDataManager.EditSelectedElementTypeParameters");
            PushButton pb1 = ribbonPanel.AddItem(b1Data) as PushButton;
            pb1.ToolTip = "Publish Type Parameter to Links.";
            Uri addinImage1 = new Uri("pack://application:,,,/RemoteDataManager;component/Resources/EditSelectedElementTypeParameters.png");
            BitmapImage pb1Image = new BitmapImage(addinImage1);
            pb1.LargeImage = pb1Image;

            PushButtonData b2Data = new PushButtonData("Global", "Global", thisAssemblyPath, "RemoteDataManager.EditGlobalParameters");
            PushButton pb2 = ribbonPanel.AddItem(b2Data) as PushButton;
            pb2.ToolTip = "Publish Global Parameter to Links.";
            Uri addinImage2 = new Uri("pack://application:,,,/RemoteDataManager;component/Resources/EditGlobalParameters.png");
            BitmapImage pb2Image = new BitmapImage(addinImage2);
            pb2.LargeImage = pb2Image;

            PushButtonData b3Data = new PushButtonData("Compare", "Compare", thisAssemblyPath, "RemoteDataManager.CompareParameters");
            PushButton pb3 = ribbonPanel.AddItem(b3Data) as PushButton;
            pb3.ToolTip = "Publish Global Parameter to Links.";
            Uri addinImage3 = new Uri("pack://application:,,,/RemoteDataManager;component/Resources/CompareParameters.png");
            BitmapImage pb3Image = new BitmapImage(addinImage3);
            pb3.LargeImage = pb3Image;
        }
        public Result OnStartup(UIControlledApplication application)
        {
            AddRibbonPanel(application);
            application.ControlledApplication.FailuresProcessing += FailureProcessor;
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        private void FailureProcessor(object sender, FailuresProcessingEventArgs e)
        {
            FailuresAccessor fas = e.GetFailuresAccessor();

            List<FailureMessageAccessor> fma = fas.GetFailureMessages().ToList();

            foreach (FailureMessageAccessor fa in fma)
            {
                //TODO
            }
        }
    }
}
