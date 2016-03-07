﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VJPlayer.ViewModels;

namespace VJPlayer.Views
{
    /// <summary>
    /// Interaction logic for CoreWindow.xaml
    /// </summary>
    public partial class CoreWindow : Window
    {
        double Volume;

        public CoreWindow()
        {
            InitializeComponent();
            Drop += CoreWindow_Drop;
            MouseLeftButtonDown += CoreWindow_MouseLeftButtonDown;
            this.DataContext = new MediaViewModel(this, mediaElement);
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
                System.Uri uri;
                System.Uri.TryCreate(filePath, System.UriKind.Absolute, out uri);
                mediaElement.Source = uri;
                Volume = mediaElement.Volume;
            }

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
        /// Tworzy nowe okno
        /// </summary>
        private void OnSpawnClick(object sender, RoutedEventArgs e)
        {
            CoreWindow newWindow = new CoreWindow();
            newWindow.Show();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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

    }
}