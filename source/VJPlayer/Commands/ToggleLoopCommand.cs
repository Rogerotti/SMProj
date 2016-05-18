using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.Commands
{
    public class ToggleLoopCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MediaModel mediaModel;

        public ToggleLoopCommand(MediaModel mediaModel)
        {
            this.mediaModel = mediaModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mediaModel.Loop = !mediaModel.Loop;
        }
    }
}
