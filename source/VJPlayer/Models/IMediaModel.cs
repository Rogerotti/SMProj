using System;

namespace VJPlayer.Models
{
    public interface IMediaModel
    {
        /// <summary>
        /// Określa stan modelu.
        /// </summary>
        MediaModelState State { get; set; }

        /// <summary>
        /// Dźwięk odtwarzanego elementu. Przyjmuje wartości od 0 - 1.
        /// </summary>
        Double Volume { get; set; }


        String ActualVideoPath { get; set; }

        /// <summary>
        /// Całkowity czas odtwarzanego elementu.
        /// </summary>
        Double TotalLength { get; set; }

        /// <summary>
        /// Decyduje o zapętleniu aktualnie odtwarzanego elementu.
        /// </summary>
        Boolean Loop { get; set; }

        /// <summary>
        /// Informuje o aktualnym przeciąganiu środkowego suwaka odpowiedzialnego za przewijanie elementu.
        /// </summary>
        Boolean UserDraggingMiddleSliderThumb { get; set; }
    }
}
