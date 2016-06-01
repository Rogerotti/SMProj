using Microsoft.Practices.Prism.Mvvm;
using System;
using VJPlayer.Interfaces;

namespace VJPlayer.Views
{
    public interface IEffectPickerView : IView, IOwnable
    {
        Action EffectChecked { get; set; }

        void ShowWindow();
    }
}
