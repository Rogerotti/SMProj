using System;
using VJPlayer.Models;
using VJPlayer.ViewModels;
using Microsoft.Practices.Unity;
using VJPlayer.Managers;

namespace VJPlayer.Commands.MediaCommands
{
    public class SpawnYouTubePickerCommand : MediaCommand
    {
        private Action playAfter;
        public SpawnYouTubePickerCommand(IMediaModel mediaModel, Action playAfter) : base(mediaModel) { this.playAfter = playAfter; }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var res = DependencyInjectionContainer.Container.Resolve<IYouTubeDownloaderViewModel>();
            res.Initialize(mediaModel);
            res.LaunchVideo = playAfter;
        }
    }
}
