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
        private ICommand spawnNewWindowCommand;

        public ICommand MinimizeWindowCommand
        {
            get { return minimizeWindowCommand; }
            set
            {
                minimizeWindowCommand = value;
                OnPropertyChanged(nameof(MinimizeWindowCommand));
            }
        }

        public ICommand CloseWindowCommand
        {
            get { return closeWindowCommand; }
            set
            {
                closeWindowCommand = value;
                OnPropertyChanged(nameof(CloseWindowCommand));
            }
        }

        public ICommand SpawnNewWindowCommand
        {
            get { return spawnNewWindowCommand; }
            set
            {
                spawnNewWindowCommand = value;
                OnPropertyChanged(nameof(SpawnNewWindowCommand));
            }
        }

        public BaseViewModel()
        {
            CloseWindowCommand = new CloseWindowCommand();
            MinimizeWindowCommand = new MinimizeWindowCommand();
            SpawnNewWindowCommand = new SpawnNewWindowCommand();
        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
