using System;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class MuteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private MediaModel mediaModel;

        public MuteCommand(MediaModel mediaModel)
        {
            this.mediaModel = mediaModel;
        }

        public bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            return mediaElement != null && mediaModel.IsPlaying && mediaElement.DataContext != null;
        }

        public void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            mediaElement.IsMuted = !mediaElement.IsMuted;
        }
    }
}
