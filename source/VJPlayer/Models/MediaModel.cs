using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPlayer.Models
{
    public class MediaModel
    {
        public IList<String> UriList { get; set; }

        public Double Volume { get; set; }

        public Boolean IsMuted { get; set; }

        public Boolean IsPlaying { get; set; }

    }
}
