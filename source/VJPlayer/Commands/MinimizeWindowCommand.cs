using System;
using System.Windows;
using System.Windows.Input;

namespace VJPlayer.Commands
{
    public class MinimizeWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var window = parameter as Window;
            return window != null;
        }

        public void Execute(object parameter)
        {
            var window = parameter as Window;
            if(window != null)
                window.WindowState = WindowState.Minimized;
        }
    }
}
