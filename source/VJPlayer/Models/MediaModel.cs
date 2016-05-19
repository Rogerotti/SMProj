using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VJPlayer.Models
{
    public class MediaModel : IMediaModel, INotifyPropertyChanged
    {
        private bool isPlaying;
        private double volume = 0.5;
        private double totalLength = 100;

        public int LowerThumbValue;

        /// <summary>
        /// Informacje o aktualnym odtwarzania utworu.
        /// </summary>
        public Boolean IsPlaying
        {
            get
            {
                return isPlaying;
            }
            set
            {
                if (isPlaying != value)
                {
                    isPlaying = value;
                    NotifyPropertyChanged(nameof(IsPlaying));
                }
            }
        }

        /// <summary>
        /// Decyduje o zapętleniu aktualnie odtwarzanego utworu.
        /// </summary>
        public Boolean Loop { get; set; }

        /// <summary>
        /// Dźwięk odtwarzanego utworu. Przyjmuje wartości od 0 - 1.
        /// </summary>
        public Double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (volume != value)
                {
                    volume = value;
                    NotifyPropertyChanged(nameof(Volume));
                }
            }
        }

        /// <summary>
        /// Całkowity czas odtwarzanego elementu.
        /// </summary>
        public Double TotalLength
        {
            get
            {
                return totalLength;
            }
            set
            {
                if (totalLength != value)
                {
                    totalLength = value;
                    NotifyPropertyChanged(nameof(TotalLength));
                }
            }
        }

        public Boolean UserDraggingMiddleSliderThumb { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
