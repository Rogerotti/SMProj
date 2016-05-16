using System;
using System.Collections.Generic;

namespace VJPlayer.Models
{
    public class MediaModel
    {
        public IList<String> UriList { get; set; }

        public Double Volume { get; set; }

        public Boolean IsPlaying { get; set; }

        public Boolean UserIsDraggingSlider { get; set; }

    }
}
