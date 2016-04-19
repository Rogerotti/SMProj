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

        public ICommand MuteCommand
        {
            get { return muteCommand; }
            set
            {
                muteCommand = value;
                OnPropertyChanged(nameof(MuteCommand));
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
            MuteCommand = new MuteCommand();
            StopCommand = new StopCommand();
        }
    }
}
