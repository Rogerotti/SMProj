using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VJPlayer.Models
{
    public class MediaModel : INotifyPropertyChanged
    {
        private bool isPlaying;
        private double volume;
        private double totalMilliseconds = 1;

        public int LowerThumbValue;

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

        public Double TotalMilliseconds
        {
            get
            {
                return totalMilliseconds;
            }
            set
            {
                if (totalMilliseconds != value)
                {
                    totalMilliseconds = value;
                    NotifyPropertyChanged(nameof(TotalMilliseconds));
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
