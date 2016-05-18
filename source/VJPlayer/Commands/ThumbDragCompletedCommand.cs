using System;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Models;
using VJPlayer.Views.CustomUserControls;

namespace VJPlayer.Commands
{
    public class ThumbDragCompletedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MediaModel mediaModel;

        public ThumbDragCompletedCommand(MediaModel mediaModel)
        {
            this.mediaModel = mediaModel;
        }

        public bool CanExecute(object parameter)
        {
            var array = parameter as object[];
            if (array != null)
            {
                var mediaElement = array[0] as MediaElement;
                var slider = array[1] as ThreeThumbSlider;
                if (mediaElement != null && slider != null)
                    return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var array = parameter as object[];
            var mediaElement = array[0] as MediaElement;
            var slider = array[1] as ThreeThumbSlider;

            mediaElement.Position = TimeSpan.FromSeconds(slider.MiddleValue);
            mediaModel.UserIsDraggingSlider = false;
        }
    }
}
