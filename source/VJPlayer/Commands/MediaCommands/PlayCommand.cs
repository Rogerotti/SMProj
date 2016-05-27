using System.Windows.Controls;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class PlayCommand : MediaCommand
    {
        public PlayCommand(IMediaModel mediaModel) : base(mediaModel) { }

        public override bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            return mediaElement != null && mediaElement.Source != null;
        }

        public override void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            mediaElement.Play();
            mediaModel.State = MediaModelState.Playing;
        }
    }
}
