using System;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.ViewModels;

namespace VJPlayer.Commands
{
    public class MuteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly MediaViewModel viewModel;
        public MuteCommand(MediaViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return viewModel != null;
        }

        public void Execute(object parameter)
        {
            viewModel.Mute();
        }
    }
}
