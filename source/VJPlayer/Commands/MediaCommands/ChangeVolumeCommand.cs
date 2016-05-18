using System.Windows.Controls;
using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    /// <summary>
    /// Zmienia dźwięk odtwarzanego materiału.
    /// </summary>
    public class ChangeVolumeCommand : MediaCommand
    {
        public ChangeVolumeCommand(IMediaModel mediaModel)
            : base(mediaModel) { }

        public override bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            if (mediaElement != null)
                return true;

            return false;
        }

        public override void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            mediaElement.Volume = mediaModel.Volume;
        }
    }
}
