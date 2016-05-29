using EffectsLibrary.Effects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace VJPlayer.Models
{
    public class EffectModel : IEffectModel, INotifyPropertyChanged
    {
        private Effect effect;

        private string name;

        private bool isActive;

        public Effect Effect
        {
            get
            {
                return effect;
            }

            set
            {
                if (effect != value)
                {
                    effect = value;
                    NotifyPropertyChanged(nameof(Effect));
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                if (isActive != value)
                {
                    isActive = value;
                    NotifyPropertyChanged(nameof(IsActive));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
