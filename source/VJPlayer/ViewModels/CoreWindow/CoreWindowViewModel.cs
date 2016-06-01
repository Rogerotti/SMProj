using EffectsLibrary.Effects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Commands;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Managers;
using VJPlayer.Models;
using VJPlayer.Views;
using Microsoft.Practices.Unity;

namespace VJPlayer.ViewModels
{
    public class CoreWindowViewModel : BaseViewModel, ICoreWindowViewModel
    {
        public IMediaModel MediaModel { get; set; }

        public IList<IEffectModel> Effects { get; set; }

        public EventHandler ManageMediaEndEvent;

        private ICoreWindowView view;

        private ICommand muteCommand;
        private ICommand playCommand;
        private ICommand pauseCommand;
        private ICommand stopCommand;
        private ICommand thumbDragCompletedCommand;
        private ICommand sliderUpdateCommand;
        private ICommand thumbDragStartedCommand;
        private ICommand loopCommand;
        private ICommand changeVolumeCommand;
        private ICommand spawnYouTubePickerCommand;
        private ICommand spawnEffectPickerCommand;

        public ICommand ChangeVolumeCommand
        {
            get { return changeVolumeCommand; }
            set
            {
                changeVolumeCommand = value;
                OnPropertyChanged(nameof(ChangeVolumeCommand));
            }
        }

        public ICommand LoopCommand
        {
            get { return loopCommand; }
            set
            {
                loopCommand = value;
                OnPropertyChanged(nameof(LoopCommand));
            }
        }

        public ICommand MuteCommand
        {
            get { return muteCommand; }
            set
            {
                muteCommand = value;
                OnPropertyChanged(nameof(MuteCommand));
            }
        }

        public ICommand PauseCommand
        {
            get { return pauseCommand; }
            set
            {
                pauseCommand = value;
                OnPropertyChanged(nameof(PauseCommand));
            }
        }

        public ICommand ThumbDragStartedCommand
        {
            get { return thumbDragStartedCommand; }
            set
            {
                thumbDragStartedCommand = value;
                OnPropertyChanged(nameof(ThumbDragStartedCommand));
            }
        }

        public ICommand SliderUpdateCommand
        {
            get { return sliderUpdateCommand; }
            set
            {
                sliderUpdateCommand = value;
                OnPropertyChanged(nameof(SliderUpdateCommand));
            }
        }

        public ICommand ThumbDragCompletedCommand
        {
            get { return thumbDragCompletedCommand; }
            set
            {
                thumbDragCompletedCommand = value;
                OnPropertyChanged(nameof(ThumbDragCompletedCommand));
            }
        }

        public ICommand PlayCommand
        {
            get { return playCommand; }
            set
            {
                playCommand = value;
                OnPropertyChanged(nameof(PlayCommand));
            }
        }

        public ICommand StopCommand
        {
            get { return stopCommand; }
            set
            {
                stopCommand = value;
                OnPropertyChanged(nameof(stopCommand));
            }
        }

        public ICommand SpawnYouTubePickerCommand
        {
            get { return spawnYouTubePickerCommand; }
            set
            {
                spawnYouTubePickerCommand = value;
                OnPropertyChanged(nameof(SpawnYouTubePickerCommand));
            }
        }

        public ICommand SpawnEffectPickerCommand
        {
            get { return spawnEffectPickerCommand; }
            set
            {
                spawnEffectPickerCommand = value;
                OnPropertyChanged(nameof(SpawnEffectPickerCommand));
            }
        }

        public CoreWindowViewModel(ICoreWindowView view, IMediaModel model)
        {
            this.view = view;
            this.view.DataContext = this;
            MediaModel = model;
            SpawnYouTubePickerCommand = new SpawnYouTubePickerCommand(MediaModel, playAfter);
            SpawnEffectPickerCommand = new SpawnEffectPickerCommand(MediaModel);
            MuteCommand = new MuteCommand(MediaModel);
            StopCommand = new StopCommand(MediaModel);
            PauseCommand = new PauseCommand(MediaModel);
            PlayCommand = new PlayCommand(MediaModel);
            LoopCommand = new ToggleLoopCommand(MediaModel);
            SliderUpdateCommand = new SliderUpdateCommand(MediaModel);
            ThumbDragStartedCommand = new SliderMiddleThumbDragStartedCommand(MediaModel);
            ThumbDragCompletedCommand = new SliderMiddleThumbDragCompletedCommand(MediaModel);
            ChangeVolumeCommand = new ChangeVolumeCommand(MediaModel);
            ManageMediaEndEvent = new EventHandler(manageMediaEnd);
            MediaModel.Loop = true;
            Effects = new List<IEffectModel>();
            addEffects();
            addEffectsGrid();
            view.ShowWindow();
        }

        private void manageMediaEnd(object sender, EventArgs args)
        {      
            if (!MediaModel.Loop)
            {
                var mediaElement = sender as MediaElement;
                StopCommand.Execute(mediaElement);
            }   
        }

        private void playAfter()
        {
            var mediaElement = view.Player;
            Uri uri;
            Uri.TryCreate(MediaModel.ActualVideoPath, UriKind.Absolute, out uri);
            mediaElement.Source = uri;
            if(playCommand.CanExecute(mediaElement))
                playCommand.Execute(mediaElement);
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

        private void addEffectsGrid()
        {
            Grid grid = view.Player.Parent as Grid;
            var pos = view.Player.Position;
            grid.Children.Remove(view.Player);
            for (int i = 0; i < Effects.Count; i++)
            {
                Grid grid2 = new Grid();
                grid.Children.Add(grid2);
                grid = grid2;
            }
            grid.Children.Add(view.Player);
            view.Player.Position = pos;
        }
    }
}
