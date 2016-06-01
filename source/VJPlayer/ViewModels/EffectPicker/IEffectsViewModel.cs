using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VJPlayer.Interfaces;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    public interface IEffectsViewModel : IOwnable
    {
        IList<IEffectModel> Effects { get; set; }

        void Initialize(IList<IEffectModel> effects, MediaElement element);
    }
}
