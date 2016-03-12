using System.Windows.Input;
using VJPlayer.Commands;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    public class MediaViewModel : BaseViewModel
    {
        public MediaModel MediaModel { get; set; }

        private ICommand muteCommand;
       
        public ICommand MuteCommand
        {
            get { return muteCommand; }
            set
            {
                muteCommand = value;
                OnPropertyChanged("MuteCommand");
            }
        }

        public MediaViewModel()
        {
            MediaModel = new MediaModel();
            MuteCommand = new MuteCommand();
        }
    }
}
