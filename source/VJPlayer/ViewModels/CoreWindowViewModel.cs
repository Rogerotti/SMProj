using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Commands;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;
using VJPlayer.Views;

namespace VJPlayer.ViewModels
{
    public class CoreWindowViewModel : BaseViewModel, ICoreWindowViewModel
    {

        public MediaModel MediaModel { get; set; }

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
   

        public CoreWindowViewModel(ICoreWindowView view)
        {
            this.view = view;
            this.view.DataContext = this;
            MediaModel = new MediaModel();
            SpawnYouTubePickerCommand = new SpawnYouTubePickerCommand(MediaModel, PlayAfter);
            MuteCommand = new MuteCommand(MediaModel);
            StopCommand = new StopCommand(MediaModel);
            PauseCommand = new PauseCommand(MediaModel);
            PlayCommand = new PlayCommand(MediaModel);
            LoopCommand = new ToggleLoopCommand(MediaModel);
            SliderUpdateCommand = new SliderUpdateCommand(MediaModel);
            ThumbDragStartedCommand = new SliderMiddleThumbDragStartedCommand(MediaModel);
            ThumbDragCompletedCommand = new SliderMiddleThumbDragCompletedCommand(MediaModel);
            ChangeVolumeCommand = new ChangeVolumeCommand(MediaModel);
            ManageMediaEndEvent = new EventHandler(ManageMediaEnd);
            MediaModel.Loop = true;
            MediaModel.Volume = 1;
            MediaModel.Volume = 0;
            view.ShowWindow();
        }

        private void ManageMediaEnd(object sender, EventArgs args)
        {      
            if (!MediaModel.Loop)
            {
                var mediaElement = sender as MediaElement;
                StopCommand.Execute(mediaElement);
            }   
        }

        private void PlayAfter()
        {
            var mediaElement = view.Player;
            Uri uri;
            Uri.TryCreate(MediaModel.ActualVideoPath, UriKind.Absolute, out uri);
            mediaElement.Source = uri;
            if(playCommand.CanExecute(mediaElement))
                playCommand.Execute(mediaElement);
        }
    }
}
