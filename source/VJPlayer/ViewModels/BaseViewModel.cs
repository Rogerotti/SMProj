using System;
using System.ComponentModel;
using System.Windows.Input;
using VJPlayer.Commands;

namespace VJPlayer.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand closeWindowCommand;
        private ICommand minimizeWindowCommand;
        public ICommand MinimizeWindowCommand
        {
            get { return minimizeWindowCommand; }
            set
            {
                minimizeWindowCommand = value;
                OnPropertyChanged("MinimizeWindowCommand");
            }
        }

        public ICommand CloseWindowCommand
        {
            get { return closeWindowCommand; }
            set
            {
                closeWindowCommand = value;
                OnPropertyChanged("CloseWindowCommand");
            }

        }

        public BaseViewModel()
        {
            CloseWindowCommand = new CloseWindowCommand();
            MinimizeWindowCommand = new MinimizeWindowCommand();
        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
