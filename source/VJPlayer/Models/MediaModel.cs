using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VJPlayer.Models
{
    public class MediaModel : IMediaModel, INotifyPropertyChanged
    {
        private bool isPlaying;
        private double volume;


        public int LowerThumbValue;

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

        public Boolean Loop { get; set; }

        public Boolean UserIsDraggingSlider { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
