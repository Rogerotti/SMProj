using System.Windows.Controls;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;
using VJPlayer.Views.CustomUserControls;

namespace VJPlayer.Commands
{
    public class SliderUpdateCommand : MediaCommand
    {
        public SliderUpdateCommand(IMediaModel mediaModel) : base(mediaModel) { }

        public override bool CanExecute(object parameter)
        {
            var array = parameter as object[];
            if (array != null)
            {
                var mediaElement = array[0] as MediaElement;
                var slider = array[1] as ThreeThumbSlider;
                if (mediaElement != null && (mediaElement.Source != null) && (mediaElement.NaturalDuration.HasTimeSpan) && (!mediaModel.UserDraggingMiddleSliderThumb) && slider != null)
                {
                    return true;
                }
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            var array = parameter as object[];
            var mediaElement = array[0] as MediaElement;
            var slider = array[1] as ThreeThumbSlider;

            slider.Minimum = 0;
            slider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            slider.MiddleValue = mediaElement.Position.TotalMilliseconds;

            mediaModel.TotalLength = slider.Maximum;
        }

    }
}