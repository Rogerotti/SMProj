using System.Windows.Controls;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class MuteCommand : MediaCommand
    {
        public MuteCommand(IMediaModel mediaModel) : base(mediaModel) { }

        public override bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            return mediaElement != null && mediaModel.IsPlaying && mediaElement.DataContext != null;
        }

        public override void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            mediaElement.IsMuted = !mediaElement.IsMuted;
        }
    }
}
