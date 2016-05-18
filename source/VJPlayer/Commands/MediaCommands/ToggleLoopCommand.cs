using VJPlayer.Commands.MediaCommands;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class ToggleLoopCommand : MediaCommand
    {
        public ToggleLoopCommand(IMediaModel mediaModel) : base(mediaModel) { }

        public override bool CanExecute(object parameter)
        {
            if (mediaModel != null)
                return true;
            return false;
        }

        public override void Execute(object parameter)
        {
            mediaModel.Loop = !mediaModel.Loop;
        }
    }
}
