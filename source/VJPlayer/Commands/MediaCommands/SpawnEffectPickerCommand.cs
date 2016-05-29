using System;
using System.Collections.Generic;
using VJPlayer.Managers;
using VJPlayer.Models;
using VJPlayer.ViewModels;
using VJPlayer.Views;
using Microsoft.Practices.Unity;
using System.Windows.Controls;

namespace VJPlayer.Commands.MediaCommands
{
    public class SpawnEffectPickerCommand : MediaCommand
    {

        public SpawnEffectPickerCommand(IMediaModel mediaModel) : base(mediaModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            var viewModel = DependencyInjectionContainer.Container.Resolve<IEffectsViewModel>();
            viewModel.Initialize(mediaElement);
           // var view = new EffectPicker();
           // var viewModel = new EffectsViewModel(effects, mediaModel, view);
           //  view.Show();
        }
    }
}
