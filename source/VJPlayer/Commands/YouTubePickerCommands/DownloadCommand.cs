using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VideoLibrary;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Managers;
using VJPlayer.Models;
using VJPlayer.Views;

namespace VJPlayer.Commands.YouTubePickerCommands
{
    public class DownloadCommand : MediaCommand
    {
        IYouTubePickerView view;
        public DownloadCommand(IYouTubePickerView view, IMediaModel model) : base(model) { this.view = view; }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async void Execute(object parameter)
        {
            var values = (object[])parameter;

            var youtubePath = (String)values[0];
            var filePath = (String)values[1];
            var fileFormat = (String)values[2];

            if (String.IsNullOrWhiteSpace(fileFormat))
                throw new ArgumentNullException(nameof(fileFormat));

            if (String.IsNullOrWhiteSpace(youtubePath))
            {
                System.Windows.MessageBox.Show("Brak adresu youtube.");
                return;
            }
            if (String.IsNullOrWhiteSpace(filePath))
            {
                System.Windows.MessageBox.Show("Podana ścieżka jest pusta.");
                return;
            }
            else if (!Directory.Exists(filePath))
            {
                System.Windows.MessageBox.Show("Podana ścieżka nie istnieje.");
                return;
            }

            try
            {
                view.ShowProgress(true);

                var youTube = YouTube.Default;
                YouTubeVideo video = await youTube.GetVideoAsync(youtubePath); // gets a Video object with info about the video

                var downloadedFilePath = FileManager.GetFolderFilePath(filePath, video.FullName);

                using (var stream = new FileStream(downloadedFilePath, FileMode.OpenOrCreate))
                using (var writer = new BinaryWriter(stream))
                {
                    var byteArray = await video.GetBytesAsync();
                    await stream.WriteAsync(byteArray, 0, byteArray.Length);
                }

                if (fileFormat != Format.mp4)
                    await ConvertFile(downloadedFilePath, fileFormat, true);

            }
            catch (KeyNotFoundException)
            {
                System.Windows.MessageBox.Show("Nie znaleziono pliku");
            }
            catch (ArgumentException)
            {
                System.Windows.MessageBox.Show("Podany adress url jest nieprawidłowy.");
            }
            catch (Exception exc)
            {
                System.Windows.MessageBox.Show(exc.ToString());
            }
            finally
            {
                view.ShowProgress(false);
            }
        }

        /// <summary>
        /// Konwertuje plik na inny format.
        /// </summary>
        /// <param name="filePath">Scieżka pliku docelowego.</param>
        /// <param name="newFormat">Nowy format pliku.</param>
        /// <param name="deleteOldFile">Czy usunąc stary plik.</param>
        /// <returns></returns>
        private async Task ConvertFile(string filePath, string newFormat, bool deleteOldFile = false)
        {
            var ffMpegConverter = new FFMpegConverter();
            var newPath = Path.ChangeExtension(filePath, newFormat);
            await Task.Run(() => { ffMpegConverter.ConvertMedia(filePath, newPath, newFormat); });
            if (deleteOldFile)
                File.Delete(filePath);
        }
    }
}
