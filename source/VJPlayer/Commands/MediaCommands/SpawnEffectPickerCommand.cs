using System.Collections.Generic;
using VJPlayer.Managers;
using VJPlayer.Models;
using VJPlayer.ViewModels;
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
            var array = parameter as object[];
            var mediaElement = array[0] as MediaElement;
            var list = array[1] as IList<IEffectModel>;
            var viewModel = DependencyInjectionContainer.Container.Resolve<IEffectsViewModel>();
            viewModel.Initialize(list, mediaElement);
        }
    }
}
