using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VJPlayer.Commands;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    public class MediaViewModel : BaseViewModel
    {
        private ICommand muteCommand;
        public ICommand MuteCommand
        {
            get { return muteCommand; }
            set
            {
                muteCommand = value;
                OnPropertyChanged("MuteCommand");
            }

        }

        private MediaElement mediaElement;

        public MediaViewModel(Window window, MediaElement mediaElement) : base(window)
        {
            this.mediaElement = mediaElement;
            MuteCommand = new MuteCommand(this);
        }

        public void Mute()
        {
            mediaElement.IsMuted = !mediaElement.IsMuted;
        }
    }
}
