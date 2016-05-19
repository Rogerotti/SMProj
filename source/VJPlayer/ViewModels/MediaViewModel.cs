using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Commands;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    public class MediaViewModel : BaseViewModel
    {

        public MediaModel MediaModel { get; set; }

        public EventHandler ManageMediaEndEvent;

        private ICommand muteCommand;
        private ICommand playCommand;
        private ICommand pauseCommand;
        private ICommand stopCommand;
        private ICommand thumbDragCompletedCommand;
        private ICommand sliderUpdateCommand;
        private ICommand thumbDragStartedCommand;
        private ICommand loopCommand;
        private ICommand changeVolumeCommand;

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

        public MediaViewModel()
        {
            MediaModel = new MediaModel();
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
            
        }

        private void ManageMediaEnd(object sender, EventArgs args)
        {      
            if (!MediaModel.Loop)
            {
                var mediaElement = sender as MediaElement;
                StopCommand.Execute(mediaElement);
            }   
        }
    }
}
