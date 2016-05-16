using System.Windows.Input;
using VJPlayer.Commands;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    public class MediaViewModel : BaseViewModel
    {
        public MediaModel MediaModel { get; set; }

        private ICommand muteCommand;
        private ICommand playCommand;
        private ICommand stopCommand;
        private ICommand thumbDragCompletedCommand;
        private ICommand sliderUpdateCommand;
        private ICommand thumbDragStartedCommand;

        public ICommand MuteCommand
        {
            get { return muteCommand; }
            set
            {
                muteCommand = value;
                OnPropertyChanged(nameof(MuteCommand));
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

        public void DropEvent()
        {
            MediaModel.IsPlaying = true;
        }

        public MediaViewModel()
        {
            MediaModel = new MediaModel();
            MuteCommand = new MuteCommand(MediaModel);
            StopCommand = new StopCommand(MediaModel);
            PlayCommand = new PlayCommand(MediaModel);
            SliderUpdateCommand = new SliderUpdateCommand(MediaModel);
            ThumbDragStartedCommand = new ThumbDragStartedCommand(MediaModel);
            ThumbDragCompletedCommand = new ThumbDragCompletedCommand(MediaModel);
        }
    }
}
