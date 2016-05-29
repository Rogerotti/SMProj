using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    public interface ICoreWindowViewModel
    {
        IMediaModel MediaModel { get; set; }

        ICommand ChangeVolumeCommand { get; set; }

        ICommand LoopCommand { get; set; }

        ICommand MuteCommand { get; set; }

        ICommand PauseCommand { get; set; }

        ICommand ThumbDragStartedCommand { get; set; }

        ICommand SliderUpdateCommand { get; set; }

        ICommand ThumbDragCompletedCommand { get; set; }

        ICommand PlayCommand { get; set; }

        ICommand StopCommand { get; set; }

        ICommand SpawnYouTubePickerCommand { get; set; }
    }
}
