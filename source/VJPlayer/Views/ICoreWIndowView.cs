using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Controls;

namespace VJPlayer.Views
{
    public interface ICoreWindowView : IView
    {
        MediaElement Player { get; }

        void ShowWindow();
    }
}
