using System.Windows.Input;
using VJPlayer.Commands;

namespace VJPlayer.ViewModels
{
    public class MediaViewModel : BaseViewModel
    {
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
            MuteCommand = new MuteCommand();
        }
    }
}
