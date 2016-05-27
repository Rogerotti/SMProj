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

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            try
            {
                var tempFolderPath = FileManagement.GetTempFilesPath();
                Directory.Delete(tempFolderPath, true);
            }
            catch (Exception)
            {
            };
        }
    }
}
