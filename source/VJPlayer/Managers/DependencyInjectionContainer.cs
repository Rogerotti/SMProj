using Microsoft.Practices.Unity;
using VJPlayer.Models;
using VJPlayer.ViewModels;
using VJPlayer.Views;

namespace VJPlayer.Managers
{
    public static class DependencyInjectionContainer
    {
        public static IUnityContainer Container;

        public static void RegisterContainer()
        {
            Container = new UnityContainer();

            Container.RegisterType<IYouTubeDownloaderViewModel, YouTubeDownloaderViewModel>();
            Container.RegisterType<IYouTubePickerView, YouTubePicker>();
            Container.RegisterType<IMediaModel, MediaModel>();
            Container.RegisterType<ICoreWindowView, CoreWindow>();
            Container.RegisterType<ICoreWindowViewModel, CoreWindowViewModel>();

            Container.RegisterType<IEffectsViewModel, EffectsViewModel>();
            Container.RegisterType<IEffectPickerView, EffectPicker>();

            Container.Resolve<CoreWindowViewModel>();
        }
    }
}
