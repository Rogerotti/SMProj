using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VideoLibrary;
using VJPlayer.Managers;

namespace VJPlayer.Views
{
    /// <summary>
    /// Interaction logic for YouTubePicker.xaml
    /// </summary>
    public partial class YouTubePicker : Window
    {
        private Semaphore semaphore;
        public YouTubePicker()
        {
            InitializeComponent();
            semaphore = new Semaphore(1, 1);
        }

        private async void DownloadTemporaryClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (semaphore.WaitOne())
                {
                    progressRing.IsActive = true;
                   
                    var youTube = YouTube.Default; // starting point for YouTube actions

                    YouTubeVideo video = await youTube.GetVideoAsync(YouTubeLink.Text); // gets a Video object with info about the video
                    using (var stream = new FileStream(FileManagement.GetTempFolderFilePath(video.FullName), FileMode.OpenOrCreate))
                    using (var writer = new BinaryWriter(stream))
                    {
                        var byteArray = await video.GetBytesAsync();
                        await stream.WriteAsync(byteArray, 0, byteArray.Length);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                semaphore.Release();
                progressRing.IsActive = false;
            }
        }

        private void PickDirectory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
