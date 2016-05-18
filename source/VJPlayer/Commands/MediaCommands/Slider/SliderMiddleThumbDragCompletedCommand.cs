using System;
using System.Windows.Controls;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;
using VJPlayer.Views.CustomUserControls;

namespace VJPlayer.Commands
{
    public class SliderMiddleThumbDragCompletedCommand : MediaCommand
    {
        public SliderMiddleThumbDragCompletedCommand(IMediaModel mediaModel) : base(mediaModel) { }

        public override bool CanExecute(object parameter)
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

        public override void Execute(object parameter)
        {
            var array = parameter as object[];
            var mediaElement = array[0] as MediaElement;
            var slider = array[1] as ThreeThumbSlider;

            mediaElement.Position = TimeSpan.FromMilliseconds(slider.MiddleValue);
            mediaModel.UserDraggingMiddleSliderThumb = false;
        }
    }
}
