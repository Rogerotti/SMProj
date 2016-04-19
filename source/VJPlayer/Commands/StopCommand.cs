using System;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class StopCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private MediaModel mediaModel;
        public StopCommand(MediaModel mediaModel)
        {
            this.mediaModel = mediaModel;
        }

        public bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            return mediaElement != null && mediaElement.Source != null && mediaModel.IsPlaying;
        }

        public void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.Stop();
                mediaModel.IsPlaying = false;            }
        }
    }
}
