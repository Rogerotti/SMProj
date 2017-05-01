using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace VJPlayer.Models
{
    public interface ISubtitlesModel
    {
        /// <summary>
        /// Czy napisy są dostepne.
        /// </summary>
        Boolean SubtitlesEnable { get; set; }

        List<SubtitlesLine> CurrentSubtitles { get; set; }

        Int32 CurrentSubtitlesPlayingIndex { get; set; }

        Int32 SubtitlesFont { get; set; }

        String SubtitlesPath { get; set; }

        Color SubtitlesColor { get; set; }
    }
}
