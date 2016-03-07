using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using VJPlayer.Commands;

namespace VJPlayer.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand closeWindowCommand;
        public ICommand CloseWindowCommand
        {
            get { return closeWindowCommand; }
            set
            {
                closeWindowCommand = value;
                OnPropertyChanged("CloseWindowCommand");
            }

        }

        private readonly Window window;
        public BaseViewModel(Window window)
        {
            this.window = window;
            CloseWindowCommand = new CloseWindowCommand(this);
        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CloseWindow()
        {
            window.Close();
        }
    }
}
