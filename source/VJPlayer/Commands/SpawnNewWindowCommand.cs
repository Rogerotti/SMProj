using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (currentWindow != null)
            {
                CoreWindow newWindow = new CoreWindow();
                newWindow.Show();
            }
        }
    }
}
