using System;
using System.ComponentModel;

namespace VJPlayer.Models
{
    public class MediaModel : IMediaModel, INotifyPropertyChanged
    {
        private double volume = 0.5;
        private double totalLength = 100;
        private MediaModelState state;
        private ISubtitlesModel subtitlesModel;

        public int LowerThumbValue;

        public string ActualVideoPath { get; set; }

        /// <summary>
        /// Decyduje o zapętleniu aktualnie odtwarzanego utworu.
        /// </summary>
        public Boolean Loop { get; set; }

        /// <summary>
        /// Dźwięk odtwarzanego utworu. Przyjmuje wartości od 0 - 1.
        /// </summary>
        public Double Volume
        {
            get{ return volume; }
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
            get { return totalLength; }
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

        public MediaModelState State
        {
            get  { return state; }
            set
            {
                if (state != value)
                {
                    state = value;
                    NotifyPropertyChanged(nameof(State));
                }
            }
        }

        public ISubtitlesModel Subtitles
        {
            get { return subtitlesModel; }
            set
            {
                if (subtitlesModel != value)
                {
                    subtitlesModel = value;
                    NotifyPropertyChanged(nameof(State));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
