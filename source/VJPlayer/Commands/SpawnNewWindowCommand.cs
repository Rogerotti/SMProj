using System;
using System.Windows;
using System.Windows.Input;
using VJPlayer.Views;

namespace VJPlayer.Commands
{
    class SpawnNewWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var currentWindow = parameter as Window;
            return currentWindow != null;
        }

        public void Execute(object parameter)
        {
            var currentWindow = parameter as Window;
            CoreWindow newWindow = new CoreWindow();
            newWindow.Show();
            
        }
    }
}
