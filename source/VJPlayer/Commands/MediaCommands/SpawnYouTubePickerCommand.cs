using System;
using VJPlayer.Models;
using VJPlayer.ViewModels;
using VJPlayer.Views;
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
          
            UnityContainer container = new UnityContainer();
            container.RegisterInstance(mediaModel);
            container.RegisterType<IYouTubeDownloaderViewModel, YouTubeDownloaderViewModel>();
            container.RegisterType<IYouTubePickerView, YouTubePicker>();
            var res = container.Resolve<YouTubeDownloaderViewModel>();
            res.LaunchVideo = playAfter;

        }
    }
}
