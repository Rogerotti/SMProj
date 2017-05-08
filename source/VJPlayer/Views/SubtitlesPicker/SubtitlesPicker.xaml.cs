using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using VJPlayer.Models;

namespace VJPlayer.Views.SubtitlesPicker
{
    /// <summary>
    /// Widok dla okna wyboru napisów.
    /// </summary>
    public partial class SubtitlesPicker : Window, ISubtitlesPickerView, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Color currentFontCollor;

        public String SubtitlesPath
        {
            get { return SubtitlesPathTextBox.Text; }
            set { SubtitlesPathTextBox.Text = value; }
        }

        public Int32 SubtitlesFontSize
        {
            get {
                Int32 result;
                return Int32.TryParse(FontSizeTextBox.Text, out result) ? result : 12;
            }
            set { FontSizeTextBox.Text = value.ToString(); }
        }

        public Color SubtitlesFontColor
        {
            get { return ColorPickerBackground.SelectedColor == null ? Color.FromRgb(255, 255, 255) : (Color)ColorPickerBackground.SelectedColor; }
            set { ColorPickerBackground.SelectedColor = value; }
        }

        public Boolean SubtitlesEnable
        {
            get { return SubtitlesEnableCheckBox.IsChecked == null ? false : (Boolean)SubtitlesEnableCheckBox.IsChecked; }
            set { SubtitlesEnableCheckBox.IsChecked = value; }
        }

        public SubtitlesPicker()
        {
            InitializeComponent();
        }

        public void LoadSubtitlesClick(Object sender, RoutedEventArgs e)
        {
            OnPropertyChanged(nameof(SubtitlesFontSize));
            OnPropertyChanged(nameof(SubtitlesFontColor));
            OnPropertyChanged(nameof(SubtitlesPath));
            OnPropertyChanged(nameof(SubtitlesEnable));
            OnPropertyChanged(nameof(SubtitlesEnable));
        }

        private void PickSubtitilesClick(Object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                SubtitlesPathTextBox.Text = dialog.FileName;
                List<SubtitlesLine> subtitles = new List<SubtitlesLine>();
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(dialog.FileName))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Int32 timeStart;
                            Int32 timeEnd;
                            String text;
                            string timePattern = @"{(.*?)}|\[(.*?)\]";
                            string textPattern = @"[^}]*$";
                            // Instantiate the regular expression object.
                            var time = Regex.Matches(line, timePattern)
                                        .Cast<Match>()
                                        .ToArray();
                            timeStart = Int32.Parse(time[0].Value.Substring(1, time[0].Value.Length - 2));
                            timeEnd = Int32.Parse(time[1].Value.Substring(1, time[1].Value.Length - 2));
                            text = Regex.Match(line, textPattern).Value;
                            subtitles.Add(new SubtitlesLine
                            {
                                Text = text,
                                StartTime = timeStart,
                                EndTime = timeEnd
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Nie można odczytać pliku");
                    Console.WriteLine(exception.Message);
                }
                // if (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes)
                //  Directory.Text = dialog.SelectedPath;
            }
            var a = 5;


        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowWindow()
        {
            Show();
        }

        /// <summary>
        /// Filtracja wprowadzanego tekstu. Pozwala na wprowadzanie tylko liczb.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(Object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void SetOwner(Window window)
        {
            Owner = window;
        }

        private void ColorPickerBackgroundSelectedColorChanged(Object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            currentFontCollor = e.NewValue == null ? Color.FromRgb(0, 0, 0) : (Color)e.NewValue;
        }

        public void ShowSubtitlesLoadFailed(String message)
        {
            progressRing.IsActive = false;
            SubtitlesLoadingMessageLabel.Foreground = Brushes.Red;
            SubtitlesLoadingMessageLabel.Content = message;
        }

        public void ShowSubtitlesLoadSuccess(String message)
        {
            progressRing.IsActive = false;
            SubtitlesLoadingMessageLabel.Content = message;
            SubtitlesLoadingMessageLabel.Foreground = Brushes.Green;
        }

        public void ShowSubtitlesLoading()
        {
            progressRing.IsActive = true;
            SubtitlesLoadingMessageLabel.Content = "";
        }
    }
}
