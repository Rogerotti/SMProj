using System;
using System.Windows;
using System.Windows.Input;

namespace VJPlayer.Commands
{
    public class CloseWindowCommand : ICommand
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
            currentWindow.Close();
        }
    }
}
