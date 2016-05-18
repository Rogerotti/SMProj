using System;
using System.Windows;
using System.Windows.Input;

namespace VJPlayer.Commands
{
    public class MinimizeWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            var window = parameter as Window;
            return window != null;
        }

        public void Execute(object parameter)
        {
            var window = parameter as Window;
            window.WindowState = WindowState.Minimized;
        }
    }
}
