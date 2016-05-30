using System;
using System.IO;

namespace VJPlayer.Managers
{
    public static class FileManager
    {
        private const String MAIN_FOLDER_NAME = "VJPlayer";
        private const String TEMP_FOLDER = "Temp";


        public static String GetTempFolderFilePath(string fileName)
        {
            return Path.Combine(GetTempFilesPath(), fileName);
        }

        public static String GetFolderFilePath(string path, string fileName)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return Path.Combine(path, fileName);
        }

        public static String GetTempFilesPath()
        {
            var tempFileFolderPath = Path.Combine(GetApplicationFolderPath(), TEMP_FOLDER);
            if (!Directory.Exists(tempFileFolderPath))
                Directory.CreateDirectory(tempFileFolderPath);
            return tempFileFolderPath;
        }

        public static String GetApplicationFolderPath()
        {
            var appFolderPath = Path.Combine(GetAppDataPath(), MAIN_FOLDER_NAME);
            if (!Directory.Exists(appFolderPath))
                Directory.CreateDirectory(appFolderPath);
            return appFolderPath;
        }

        private static String GetAppDataPath()
        {
            return Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData, // Szuka w %APPDATA%
            Environment.SpecialFolderOption.Create); // Tworzy folder jeżeli nie istnieje.
        }
    }
}
