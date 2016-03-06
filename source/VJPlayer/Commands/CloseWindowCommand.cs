using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VJPlayer.ViewModels;

namespace VJPlayer.Commands
{
    public class CloseWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly BaseViewModel viewModel;
        public CloseWindowCommand(BaseViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return viewModel != null;
        }

        public void Execute(object parameter)
        {
            viewModel.CloseWindow();
        }
    }
}
