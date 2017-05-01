using System;
using System.Windows;
using VJPlayer.Managers;
using VJPlayer.Models;
using VJPlayer.ViewModels;
using Microsoft.Practices.Unity;

namespace VJPlayer.Commands.MediaCommands
{
    public class SpawnSubtitlesPicker : MediaCommand
    {
        public SpawnSubtitlesPicker(IMediaModel mediaModel) : base(mediaModel) {  }

        public override Boolean CanExecute(Object parameter)
        {
            return true;
        }

        public override void Execute(Object parameter)
        {
            var array = parameter as Object[];
            var window = array[0] as Window;

            var viewModel = DependencyInjectionContainer.Container.Resolve<ISubtitlesPickerViewModel>();
            viewModel.Initialize(mediaModel);
            viewModel.SetOwner(window);
        }
    }
}
