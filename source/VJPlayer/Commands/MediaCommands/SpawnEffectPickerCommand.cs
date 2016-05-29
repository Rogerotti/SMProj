using System;
using System.Collections.Generic;
using VJPlayer.Models;
using VJPlayer.ViewModels;
using VJPlayer.Views;

namespace VJPlayer.Commands.MediaCommands
{
    public class SpawnEffectPickerCommand : MediaCommand
    {
        private List<IEffectModel> effects;

        public SpawnEffectPickerCommand(IMediaModel mediaModel, List<IEffectModel> effects) : base(mediaModel)
        {
            this.effects = effects;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var view = new EffectPicker();
            var viewModel = new EffectsViewModel(effects, mediaModel, view);
            view.Show();
        }
    }
}
