using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VJPlayer.ViewModels;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System;
using System.Windows.Input;

namespace VJPlayer.Views
{
    /// <summary>
    /// Interaction logic for CoreWindow.xaml
    /// </summary>
    public partial class CoreWindow : Window
    {
        private DispatcherTimer timer;
        public CoreWindow()
        {
            InitializeComponent();
            DataContext = new MediaViewModel();
            Drop += CoreWindow_Drop;
            MouseLeftButtonDown += CoreWindow_MouseLeftButtonDown;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
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
            CommandManager.InvalidateRequerySuggested();
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

        private void SliderValueChanged(object sender, EventArgs e)
        {
            //TODO czas filmu
            var viewModel = (MediaViewModel)DataContext;
            if (slider.MiddleSlider.Value >= slider.UpperSlider.Value)
            {               
                if (viewModel.MediaModel.Loop)
                {
                    slider.MiddleSlider.Value = slider.LowerSlider.Value;
                    mediaElement.Position = TimeSpan.FromMilliseconds(slider.LowerSlider.Value);
                }
                else
                {
                    slider.MiddleSlider.Value = slider.UpperSlider.Value;
                    viewModel.StopCommand.Execute(mediaElement);
                }
            }
            else if (slider.MiddleSlider.Value <= slider.LowerSlider.Value)
            {
                slider.MiddleSlider.Value = slider.LowerSlider.Value;
                mediaElement.Position = TimeSpan.FromMilliseconds(slider.LowerSlider.Value);
            }
        }

        private void LowerLoopSliderValueChanged(object sender, EventArgs e)
        {
            //TODO dolny loop, ustawienie
        }

        private void UpperLoopSliderValueChanged(object sender, EventArgs e)
        {
            //TODO gorny loop, ustawienie
        }


        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            var viewModel = (MediaViewModel)DataContext;
            viewModel.ManageMediaEndEvent.Invoke(mediaElement, EventArgs.Empty);
        }

        private void sliderMiddleSliderDragCompleted(object sender, EventArgs e)
        {
            var viewModel = (MediaViewModel)DataContext;
            object[] arrayOfObjects = new object[2];
            arrayOfObjects[0] = mediaElement;
            arrayOfObjects[1] = slider;

            if (viewModel.ThumbDragCompletedCommand.CanExecute(arrayOfObjects))
                viewModel.ThumbDragCompletedCommand.Execute(arrayOfObjects);
        }

        private void sliderMiddleSliderDragStarted(object sender, EventArgs e)
        {
            var viewModel = (MediaViewModel)DataContext;
            viewModel.ThumbDragStartedCommand.Execute(null);
        }

        private void LowerSliderDragStarted(object sender, EventArgs e)
        {
           // timer.Stop();
        }

        private void LowerSliderDragCompleted(object sender, EventArgs e)
        {
            var viewModel = (MediaViewModel)DataContext;
            object[] array = new object[2];
            array[0] = mediaElement;
            array[1] = slider.LowerValue;
            //viewModel.LowerSliderCompletedCommand.Execute(array);
        }

        private void VolumeValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var viewModel = (MediaViewModel)DataContext;
            viewModel.ChangeVolumeCommand.Execute(mediaElement);
        }

    }
}