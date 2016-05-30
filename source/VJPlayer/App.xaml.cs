using Microsoft.Practices.Unity;
using System;
using System.IO;
using System.Windows;
using VJPlayer.Managers;

namespace VJPlayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UnityContainer Container;
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            DependencyInjectionContainer.RegisterContainer();
        }

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            try
            {
                var tempFolderPath = FileManager.GetTempFilesPath();
                Directory.Delete(tempFolderPath, true);
            }
            catch (Exception) { };
        }
    }
}
