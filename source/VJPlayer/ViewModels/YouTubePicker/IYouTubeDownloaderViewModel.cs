using System;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    /// <summary>
    /// View model dla pobierania filmów z youtube.
    /// </summary>
    public interface IYouTubeDownloaderViewModel
    {
        Action LaunchVideo { get; set; }
        /// <summary>
        /// Pobiera plik z youtube tymczasowo do momentu zamknięcia aplikacji.
        /// </summary>
        ICommand DownloadTemporary { get; set; }

        /// <summary>
        /// Pobiera plik z youtube na dysk o podanej ścieżce.
        /// </summary>
        ICommand Download { get; set; }

        void Initialize(IMediaModel model);
    }
}
