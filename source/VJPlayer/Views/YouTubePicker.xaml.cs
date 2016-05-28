using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;


namespace VJPlayer.Views
{
    /// <summary>
    /// Interaction logic for YouTubePicker.xaml
    /// </summary>
    public partial class YouTubePicker : Window, IYouTubePickerView, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string YoutubePath
        {
            get { return YouTubeLink.Text; }
        }


        public string FilePath
        {
            get
            {
                return Directory.Text;
            }
        }

        public YouTubePicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pobiera plik z youtube tymczasowo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadTemporaryClick(object sender, RoutedEventArgs e)
        {
            OnPropertyChanged(nameof(YoutubePath));
        }

        public void ShowProgress(bool show)
        {
            progressRing.IsActive = show;
        }

        private void PickDirectoryClick(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes)
                Directory.Text = dialog.SelectedPath;
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            OnPropertyChanged(nameof(YoutubePath));
            OnPropertyChanged(nameof(FilePath));
        }


        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
