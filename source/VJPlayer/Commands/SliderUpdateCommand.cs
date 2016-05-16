using System;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class SliderUpdateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MediaModel mediaModel;

        public SliderUpdateCommand(MediaModel mediaModel)
        {
            this.mediaModel = mediaModel;
        }

        public bool CanExecute(object parameter)
        {
            var array = parameter as object[];
            if (array != null)
            {
                var mediaElement = array[0] as MediaElement;
                var slider = array[1] as Slider;
                if (mediaElement != null && (mediaElement.Source != null) && (mediaElement.NaturalDuration.HasTimeSpan) && (!mediaModel.UserIsDraggingSlider) && slider != null)
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var array = parameter as object[];
            var mediaElement = array[0] as MediaElement;
            var slider = array[1] as Slider;

            slider.Minimum = 0;
            slider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            slider.Value = mediaElement.Position.TotalSeconds;
        }

    }
}