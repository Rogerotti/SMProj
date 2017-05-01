using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Windows.Media;
using VJPlayer.Interfaces;

namespace VJPlayer.Views.SubtitlesPicker
{
    /// <summary>
    /// Widok dla okna zarządzającym napisami.
    /// </summary>
    public interface ISubtitlesPickerView : IView, IOwnable
    {
        /// <summary>
        /// Scieżka do napisów.
        /// </summary>
        String SubtitlesPath { get; set; }

        /// <summary>
        /// Rozmiar czcionki napisów.
        /// </summary>
        Int32 SubtitlesFontSize { get; set; }

        /// <summary>
        /// Czy napisy są dostępne.
        /// </summary>
        Boolean SubtitlesEnable { get; set; }

        /// <summary>
        /// Kolor napisów.
        /// </summary>
        Color SubtitlesFontColor { get; set; }

        void ShowWindow();
    }
}
