using System;
using VJPlayer.Models;
using VJPlayer.ViewModels;
using VJPlayer.Views;

namespace VJPlayer.Commands.MediaCommands
{
    public class SpawnYouTubePickerCommand : MediaCommand
    {
        Action playAfter;
        public SpawnYouTubePickerCommand(IMediaModel mediaModel, Action playAfter) : base(mediaModel) { this.playAfter = playAfter; }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var view = new YouTubePicker();
            var viewModel = new YouTubeDownloaderViewModel(view, mediaModel, playAfter);
            view.Show();
        }
    }
}
