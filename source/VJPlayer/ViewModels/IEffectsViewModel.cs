using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    public interface IEffectsViewModel
    {
        IList<IEffectModel> Effects { get; set; }

        void Initialize(MediaElement element);
    }
}
