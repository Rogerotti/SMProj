using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace VJPlayer.Models
{
    public interface IEffectModel
    {
        Effect Effect { get; set; }

        string Name { get; set; }

        bool IsActive { get; set; }
    }
}
