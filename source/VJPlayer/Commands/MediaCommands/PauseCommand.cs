using System.Windows.Controls;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class PauseCommand : MediaCommand
    {
        public PauseCommand(IMediaModel mediaModel) : base(mediaModel) { }

        public override bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            return mediaElement != null && mediaElement.Source != null && mediaModel.IsPlaying;
        }

        public override void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            mediaElement.Pause();
            mediaModel.IsPlaying = false;

        }
    }
}
