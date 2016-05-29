using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using VJPlayer.Commands.YouTubePickerCommands;
using VJPlayer.Models;
using VJPlayer.Views;

namespace VJPlayer.ViewModels
{
    public class YouTubeDownloaderViewModel : BaseViewModel, IYouTubeDownloaderViewModel
    {
        private readonly IMediaModel model;
        private readonly IYouTubePickerView view;

        private Action playAfter;

        private ICommand downloadTemporary;
        private ICommand download;

        public ICommand DownloadTemporary
        {
            get { return downloadTemporary; }
            set
            {
                downloadTemporary = value;
                OnPropertyChanged(nameof(DownloadTemporary));
            }
        }

        public ICommand Download
        {
            get { return download; }
            set
            {
                download = value;
                OnPropertyChanged(nameof(Download));
            }
        }

        public Action LaunchVideo
        {
            get
            {
                return playAfter;
            }
            set
            {
               playAfter = value;
               DownloadTemporary = new DownloadTemporaryCommand(view, model, playAfter);
            }
        }

        public YouTubeDownloaderViewModel(IYouTubePickerView view, IMediaModel model)
        {
            this.model = model;
            this.view = view;
            this.view.DataContext = this;
            this.view.SetFormats(getFormats());
            DownloadTemporary = new DownloadTemporaryCommand(view, model, LaunchVideo);
            Download = new DownloadCommand(view, model);
            view.ShowWindow();
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

    }
}
