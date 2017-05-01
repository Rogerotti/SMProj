using System.Windows.Input;
using VJPlayer.Interfaces;
using VJPlayer.Models;

namespace VJPlayer.ViewModels
{
    /// <summary>
    /// View model dla Wybrania napisów.
    /// </summary>
    public interface ISubtitlesPickerViewModel : IOwnable
    {
        void Initialize(IMediaModel model);

        /// <summary>
        /// Wczytuje napisy.
        /// </summary>
        ICommand LoadSubtitles { get; set; }
    }
}
