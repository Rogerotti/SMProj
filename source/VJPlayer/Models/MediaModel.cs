using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VJPlayer.Models
{
    public class MediaModel : INotifyPropertyChanged
    {
        private bool isPlaying;
        public IList<String> UriList { get; set; }

        public Double Volume { get; set; }

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
