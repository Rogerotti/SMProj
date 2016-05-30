using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Windows;

namespace VJPlayer.ViewModels
{
    public interface IEffectPickerView : IView
    {
        Action EffectChecked { get; set; }

        void SetOwner(Window window);

        void ShowWindow();
    }
}
