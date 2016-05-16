using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class PauseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private MediaModel mediaModel;

        public PauseCommand(MediaModel mediaModel)
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
            mediaElement.Pause();
            mediaModel.IsPlaying = false;

        }
    }
}
