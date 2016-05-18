using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPlayer.Models
{
    public interface IMediaModel
    {
        /// <summary>
        /// Dźwięk odtwarzanego utworu. Przyjmuje wartości od 0 - 1.
        /// </summary>
        Double Volume { get; set; }

        Boolean IsPlaying { get; set; }

        Boolean Loop { get; set; }
    }
}
