using EffectsLibrary.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJPlayer.Models;
using VJPlayer.Views;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows;

namespace VJPlayer.ViewModels
{
    class EffectsViewModel : BaseViewModel, IEffectsViewModel
    {
        public IList<IEffectModel> Effects { get; set; }

        private readonly IMediaModel model;
        private readonly IEffectPickerView view;

        private MediaElement mediaElement;

        public EffectsViewModel( IMediaModel model, IEffectPickerView view)
        {
            Effects = new List<IEffectModel>();
            this.model = model;
            this.view = view;
            this.view.DataContext = this;
            addEffects();
            view.EffectChecked = ApplyEffects;
        }

        private void addEffects()
        {
            Effects.Add(new EffectModel() { Effect = new BandedSwirlEffect(), Name = "Banded Swirl", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new BloomEffect(), Name = "Bloom", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new BrightExtractEffect(), Name = "Bright Extract", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new ColorKeyAlphaEffect(), Name = "Color Key Alpha", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new ColorToneEffect(), Name = "Color Tone", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new ContrastAdjustEffect(), Name = "Contrast Adjust", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new DirectionalBlurEffect(), Name = "Directional Blur", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new EmbossedEffect(), Name = "Embossed", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new GloomEffect(), Name = "Gloom", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new GrowablePoissonDiskEffect(), Name = "Growable Poisson Disk", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new InvertColorEffect(), Name = "Invert Color", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new LightStreakEffect(), Name = "Light Streak", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new MagnifyEffect(), Name = "Magnify", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new MonochromeEffect(), Name = "Monochrome", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new PinchEffect(), Name = "Pinch", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new PixelateEffect(), Name = "Pixelate", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new RippleEffect(), Name = "Ripple", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new SharpenEffect(), Name = "Sharpen", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new SmoothMagnifyEffect(), Name = "Smooth Magnify", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new SwirlEffect(), Name = "Swirl", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new ToneMappingEffect(), Name = "Tone Mapping", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new ToonShaderEffect(), Name = "Toon Shader", IsActive = false });
            Effects.Add(new EffectModel() { Effect = new ZoomBlurEffect(), Name = "Zoom Blur", IsActive = false });
        }

        public void Initialize(MediaElement element)
        {
            mediaElement = element;
            view.ShowWindow();
        }

        private void ApplyEffects()
        {
            Effect effect = null;
            List<Effect> activeEffects = new List<Effect>();
            try
            {
                foreach (var item in Effects)
                {
                    if (item.IsActive == true)
                        activeEffects.Add(item.Effect);
                }
                if (activeEffects.Count != 0)
                {
                    Grid grid = mediaElement.Parent as Grid;
                    while (grid.Name != "EffectGrid")
                    {
                        grid.Children.Clear();
                        grid = grid.Parent as Grid;

                    }

                    grid.Children.Clear();


                    mediaElement.Effect = activeEffects[0];
                    for (int i = 1; i < activeEffects.Count; i++)
                    {
                        Grid grid2 = new Grid();
                        grid2.Effect = activeEffects[i];
                        grid.Children.Add(grid2);
                        grid = grid2;
                    }
                    grid.Children.Add(mediaElement);
                    //grid.Children.Add(mediaElement);
                    //for (int i = 0; i < activeEffects.Count; i++)
                    //{
                    //    grid.Children[i].Effect = activeEffects[i];
                    //    grid.Children.Add(new Grid());
                    //}
                }

            }
            catch (Exception) {}
            finally
            {
       

            }

              
        }

    }
}