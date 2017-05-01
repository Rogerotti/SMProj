using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace VJPlayer.Models
{
    public class SubtitlesModel : ISubtitlesModel, INotifyPropertyChanged
    {
        public List<SubtitlesLine> CurrentSubtitles {get; set;}

        public Int32 CurrentSubtitlesPlayingIndex { get; set; }
    
        public Color SubtitlesColor { get; set; }

        public Boolean SubtitlesEnable { get; set; }

        public Int32 SubtitlesFont { get; set; }

        public String SubtitlesPath { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
