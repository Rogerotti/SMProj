using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPlayer.Models
{
    /// <summary>
    /// Stan aktualnego odtwarzania. NoTrack = brak utworu, Playing = odtwarza, Pause = utwór zatrzymany, Stop = utwór zastopowany.
    /// </summary>
    public enum MediaModelState{NoTrack, Playing, Paused, Stoped}
}
