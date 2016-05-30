using EffectsLibrary.Effects;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using VJPlayer.Models;
using System.Windows;

namespace VJPlayer.ViewModels
{
    class EffectsViewModel : BaseViewModel, IEffectsViewModel
    {
        public IList<IEffectModel> Effects { get; set; }

        private readonly IEffectPickerView view;

        private MediaElement mediaElement;

        public EffectsViewModel(IEffectPickerView view)
        {
            this.view = view;
            this.view.DataContext = this;
        }


        public void Initialize(IList<IEffectModel> effects, MediaElement element)
        {
            mediaElement = element;
            Effects = effects;
            view.EffectChecked = ApplyEffects;
            view.ShowWindow();
        }

        private void ApplyEffects()
        {
            Grid grid = mediaElement.Parent as Grid;
            while (grid.Name != "EffectGrid")
            {
                grid.Effect = null;
                grid = grid.Parent as Grid;
            }

            List<Effect> activeEffects = new List<Effect>();

            foreach (var item in Effects)
            {
                if (item.IsActive == true)
                    activeEffects.Add(item.Effect);
            }

            Grid grid2 = mediaElement.Parent as Grid;
            for (int i = 0; i < activeEffects.Count; i++)
            {
                grid2.Effect = activeEffects[i];
                grid2 = grid2.Parent as Grid;
            }
    
        }


        public void SetOwner(Window window)
        {
            view.SetOwner(window);
        }
    }
}