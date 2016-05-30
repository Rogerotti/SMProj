using EffectsLibrary.Effects;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using VJPlayer.Models;

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
    
            //try
            //{
            //    var pos = mediaElement.Position;
            //    foreach (var item in Effects)
            //    {
            //        if (item.IsActive == true)
            //            activeEffects.Add(item.Effect);
            //    }
            //    if (activeEffects.Count != 0)
            //    {
            //        Grid grid = mediaElement.Parent as Grid;
            //        while (grid.Name != "EffectGrid")
            //        {
            //            grid.Children.Clear();
            //            grid = grid.Parent as Grid;
            //        }

            //        grid.Children.Clear();

            //        mediaElement.Effect = activeEffects[0];
            //        for (int i = 1; i < activeEffects.Count; i++)
            //        {
            //            Grid grid2 = new Grid();
            //            grid2.Effect = activeEffects[i];
            //            grid.Children.Add(grid2);
            //            grid = grid2;
            //        }
            //        grid.Children.Add(mediaElement);
            //        mediaElement.Position = pos;

            //    }
            //    else
            //        mediaElement.Effect = null;

            //}
            //catch (Exception) { }
        }

 
    }
}