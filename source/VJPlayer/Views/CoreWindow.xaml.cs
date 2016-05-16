﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VJPlayer.ViewModels;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System;

namespace VJPlayer.Views
{
    /// <summary>
    /// Interaction logic for CoreWindow.xaml
    /// </summary>
    public partial class CoreWindow : Window
    {
        public CoreWindow()
        {
            InitializeComponent();
            DataContext = new MediaViewModel();
            Drop += CoreWindow_Drop;
            MouseLeftButtonDown += CoreWindow_MouseLeftButtonDown;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateSliderTick; ;
            timer.Start();

        }

        /// <summary>
        /// Aktualizuje położenie paska stanu odtwarzanego materiału.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSliderTick(object sender, EventArgs e)
        {
            var viewModel = (MediaViewModel)DataContext;

            object[] arrayOfObjects = new object[2];
            arrayOfObjects[0] = mediaElement;
            arrayOfObjects[1] = slider;

            if(viewModel.SliderUpdateCommand.CanExecute(arrayOfObjects))
                viewModel.SliderUpdateCommand.Execute(arrayOfObjects);
        }

        /// <summary
        /// >Obsługa drag'n'drop, przekazuje Uri przeciągniętego pliku do mediaElement.
        /// </summary>
        private void CoreWindow_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Można przeciągnąć wiele plików (dlatego tablica)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Na razie pobranie tylko jednego z przeciągniętych plików
                // ToDo: pobierać całą tablicę i w foreachu jakoś to tam układać do listy czy coś
                var filePath = files[0];
                // Utworzenie URI z ścieżki do pliku
                Uri uri;
                System.Uri.TryCreate(filePath, System.UriKind.Absolute, out uri);
                mediaElement.Source = uri;
                var viewModel = (MediaViewModel)DataContext;

                if (viewModel.PlayCommand.CanExecute(mediaElement))
                    viewModel.PlayCommand.Execute(mediaElement);

            }
            Focus();
        }


        /// <summary>
        /// Umożliwia przeciąganie okna bez ramek lewym przyciskiem myszy
        /// </summary>
        private void CoreWindow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (System.InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Wywołanie animacji (fade-in) przy najechaniu kursorem na kontrolki
        /// </summary>
        private void MediaControlsCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Canvas c = (Canvas)sender;
            DoubleAnimation animation = new DoubleAnimation(1, System.TimeSpan.FromMilliseconds(300));
            c.BeginAnimation(Canvas.OpacityProperty, animation);
        }

        /// <summary>
        /// Wywołanie animacji (fade-out) przy najechaniu kursorem na kontrolki
        /// </summary>
        private void MediaControlsCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Canvas c = (Canvas)sender;
            DoubleAnimation animation = new DoubleAnimation(0, System.TimeSpan.FromMilliseconds(300));
            c.BeginAnimation(Canvas.OpacityProperty, animation);
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //TODO czas filmu
        }

        private void sliderDragCompleted(object sender, RoutedEventArgs e)
        {
            var viewModel = (MediaViewModel)DataContext;
            object[] arrayOfObjects = new object[2];
            arrayOfObjects[0] = mediaElement;
            arrayOfObjects[1] = slider;

            if(viewModel.ThumbDragCompletedCommand.CanExecute(arrayOfObjects))
                viewModel.ThumbDragCompletedCommand.Execute(arrayOfObjects);
        }

        private void sliderDragStarted(object sender, RoutedEventArgs e)
        {
            var viewModel = (MediaViewModel)DataContext;
            viewModel.ThumbDragStartedCommand.Execute(null);
        }

        private void playButtonClick(object sender, RoutedEventArgs e)
        {
            playButton.Visibility = Visibility.Collapsed;
            pauseButton.Visibility = Visibility.Visible;
        }

        private void pauseButtonClick(object sender, RoutedEventArgs e)
        {
            pauseButton.Visibility = Visibility.Collapsed;
            playButton.Visibility = Visibility.Visible;
        }

        private void stopButtonClick(object sender, RoutedEventArgs e)
        {
            pauseButton.Visibility = Visibility.Collapsed;
            playButton.Visibility = Visibility.Visible;
        }
    }
}