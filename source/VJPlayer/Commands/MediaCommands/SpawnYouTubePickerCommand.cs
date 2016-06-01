using System;
using VJPlayer.Models;
using VJPlayer.ViewModels;
using Microsoft.Practices.Unity;
using VJPlayer.Managers;
using System.Windows;

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
            var array = parameter as object[];
            var window = array[0] as Window;
            var viewModel = DependencyInjectionContainer.Container.Resolve<IYouTubeDownloaderViewModel>();
            viewModel.Initialize(mediaModel);
            viewModel.LaunchVideo = playAfter;
            viewModel.SetOwner(window);
        }
    }
}
