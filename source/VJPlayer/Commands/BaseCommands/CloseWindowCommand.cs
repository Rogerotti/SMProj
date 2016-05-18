using System;
using System.Windows;
using System.Windows.Input;

namespace VJPlayer.Commands
{
    public class CloseWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            var currentWindow = parameter as Window;
            return currentWindow != null;
        }

        public void Execute(object parameter)
        {
            var currentWindow = parameter as Window;
            currentWindow.Close();
        }
    }
}
