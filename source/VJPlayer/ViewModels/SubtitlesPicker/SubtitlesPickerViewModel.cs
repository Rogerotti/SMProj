using System;
using VJPlayer.Models;
using System.Windows;
using VJPlayer.Views.SubtitlesPicker;
using System.Windows.Input;
using VJPlayer.Commands.MediaCommands;

namespace VJPlayer.ViewModels
{
    public class SubtitlesPickerViewModel : BaseViewModel, ISubtitlesPickerViewModel
    {
        private readonly ISubtitlesPickerView view;

        private IMediaModel mediaModel;
        private ICommand loadSubtitles;

        public ICommand LoadSubtitles
        {
            get { return loadSubtitles; }
            set
            {
                loadSubtitles = value;
                OnPropertyChanged(nameof(LoadSubtitles));
            }
        }

        public SubtitlesPickerViewModel(ISubtitlesPickerView view)
        {
            this.view = view;
            this.view.DataContext = this;
        }

        public void Initialize(IMediaModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            mediaModel = model;
            view.ShowWindow();
            LoadSubtitles = new LoadSubtitlesCommand(model);
            view.SubtitlesEnable = mediaModel.Subtitles.SubtitlesEnable;
            view.SubtitlesFontSize = mediaModel.Subtitles.SubtitlesFont;
            view.SubtitlesFontColor = mediaModel.Subtitles.SubtitlesColor;
            view.SubtitlesPath = mediaModel.Subtitles.SubtitlesPath;

        }

        public void SetOwner(Window window)
        {
            view.SetOwner(window);
        }
    }
}
