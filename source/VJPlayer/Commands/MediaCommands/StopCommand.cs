using System.Windows.Controls;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class StopCommand : MediaCommand
    {
        public StopCommand(IMediaModel mediaModel) : base(mediaModel) { }

        public override bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            return mediaElement != null && mediaElement.Source != null && (mediaModel.State == MediaModelState.Playing || mediaModel.State == MediaModelState.Paused);
        }

        public override void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            mediaElement.Stop();
            mediaModel.State = MediaModelState.Stoped;
        }
    }
}
