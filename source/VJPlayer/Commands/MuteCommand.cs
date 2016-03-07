using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace VJPlayer.Commands
{
    public class MuteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            return mediaElement != null;
        }

        public void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            if(mediaElement != null)
                mediaElement.IsMuted = !mediaElement.IsMuted;
        }
    }
}
