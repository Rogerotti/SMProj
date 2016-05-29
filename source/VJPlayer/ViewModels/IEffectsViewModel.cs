using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    interface IEffectsViewModel
    {
        List<IEffectModel> Effects { get; set; }
    }
}
