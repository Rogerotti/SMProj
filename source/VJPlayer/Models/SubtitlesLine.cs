using System;

namespace VJPlayer.Models
{
    /// <summary>
    /// Reprezentuje pojedynczą linijkę napisów.
    /// </summary>
    public class SubtitlesLine
    {
        // Początek odtwarzania napisów w ms.
        public Int32 StartTime { get; set; }

        // Koniec odtwarzania napisów w ms.
        public Int32 EndTime { get; set; }

        // Odtwarzany tekst.
        public String Text { get; set; }
    }
}
