using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;
using VJPlayer.Managers;
using VJPlayer.ViewModels;

namespace VJPlayer.Commands
{
    class SpawnNewWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DependencyInjectionContainer.Container.Resolve<CoreWindowViewModel>();
        }
    }
}
