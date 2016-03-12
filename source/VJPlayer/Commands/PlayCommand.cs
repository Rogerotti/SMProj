using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace VJPlayer.Commands
{
    public class PlayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            return mediaElement != null && mediaElement.Source != null;
        }

        public void Execute(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.Play();
                
                //mediaPlayerIsPlaying = true; //trzeba ustawić tu model w viewmodel jakoś
            }
        }
    }
}
