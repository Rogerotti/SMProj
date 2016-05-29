using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace VJPlayer.Views
{
    public interface IYouTubePickerView : IView
    {
        /// <summary>
        /// Scieżka do pliku z youtube.
        /// </summary>
        String YoutubePath { get; }

        /// <summary>
        /// Scieżka do zapisania pliku.
        /// </summary>
        String FilePath { get; }

        /// <summary>
        /// Aktualny format.
        /// </summary>
        String CurrentFormat { get; }

        /// <summary>
        /// Decyduje o pokazaniu progresu.
        /// </summary>
        /// <param name="show"></param>
        void ShowProgress(bool show);

        /// <summary>
        /// Ustawia formaty możliwe do pobrania pliku z youtube.
        /// </summary>
        /// <param name="formats">Lista formatów.</param>
        void SetFormats(IEnumerable<String> formats);
    }
}
