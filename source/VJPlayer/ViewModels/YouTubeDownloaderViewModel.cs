using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using VJPlayer.Commands;
using VJPlayer.Commands.YouTubePickerCommands;
using VJPlayer.Models;
using VJPlayer.Views;

namespace VJPlayer.ViewModels
{
    public class YouTubeDownloaderViewModel : BaseViewModel, IYouTubeDownloaderViewModel
    {
        
        private readonly IYouTubePickerView view;

        private Action launchVideo;

        private IMediaModel model;

        private ICommand downloadCommand;
        private ICommand downloadTemporaryCommand;
       

        public ICommand DownloadTemporary
        {
            get { return downloadTemporaryCommand; }
            set
            {
                downloadTemporaryCommand = value;
                OnPropertyChanged(nameof(DownloadTemporary));
            }
        }

        public ICommand Download
        {
            get { return downloadCommand; }
            set
            {
                downloadCommand = value;
                OnPropertyChanged(nameof(Download));
            }
        }

        public Action LaunchVideo
        {
            get
            {
                return launchVideo;
            }
            set
            {
               launchVideo = value;
               DownloadTemporary = new DownloadTemporaryCommand(view, model, launchVideo);
            }
        }


        public YouTubeDownloaderViewModel(IYouTubePickerView view)
        {
            this.view = view;
            this.view.DataContext = this;
            this.view.SetFormats(getFormats());

        }

        private IEnumerable<string> getFormats()
        {
            List<string> formats = new List<string>();
            formats.Add(Format.mp4);
            formats.Add(Format.ac3);
            formats.Add(Format.aiff);
            formats.Add(Format.avi);
            formats.Add(Format.gif);
            formats.Add(Format.mpeg);
            return formats;
        }

        public void Initialize(IMediaModel model)
        {
          
            if (model == null) throw new ArgumentNullException(nameof(model));

            this.model = model;
            DownloadTemporary = new DownloadTemporaryCommand(view, model, LaunchVideo);
            Download = new DownloadCommand(view, model);
            view.ShowWindow();
        }
    }
}
