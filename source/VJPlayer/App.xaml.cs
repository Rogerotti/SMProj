﻿using Microsoft.Practices.Unity;
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

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DependencyInjectionContainer.RegisterContainer();
        }
    }
}
