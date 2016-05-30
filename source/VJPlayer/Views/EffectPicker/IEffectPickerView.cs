using Microsoft.Practices.Prism.Mvvm;
using System;

namespace VJPlayer.ViewModels
{
    public interface IEffectPickerView : IView
    {
        Action EffectChecked { get; set; }

        void ShowWindow();
    }
}
