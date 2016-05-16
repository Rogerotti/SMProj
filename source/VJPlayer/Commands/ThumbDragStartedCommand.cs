using System;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class ThumbDragStartedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MediaModel mediaModel;

        public ThumbDragStartedCommand(MediaModel mediaModel)
        {
            this.mediaModel = mediaModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mediaModel.UserIsDraggingSlider = true;
        }
    }
}
