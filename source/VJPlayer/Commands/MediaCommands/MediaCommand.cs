using System;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.Commands.MediaCommands
{
    /// <summary>
    /// Podstawowa komenda zarządzająca multimediami.
    /// </summary>
    abstract public class MediaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        protected IMediaModel mediaModel;

        public MediaCommand(IMediaModel mediaModel)
        {
            this.mediaModel = mediaModel;
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
