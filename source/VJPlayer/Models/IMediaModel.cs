using System;

namespace VJPlayer.Models
{
    public interface IMediaModel
    {
        /// <summary>
        /// Dźwięk odtwarzanego elementu. Przyjmuje wartości od 0 - 1.
        /// </summary>
        Double Volume { get; set; }

        /// <summary>
        /// Informacje o aktualnym odtwarzanego elemntu.
        /// </summary>
        Boolean IsPlaying { get; set; }

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
