using VJPlayer.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Media;
using System.Text;

namespace VJPlayer.Commands.MediaCommands
{
    public class LoadSubtitlesCommand : MediaCommand
    {
        public LoadSubtitlesCommand(IMediaModel mediaModel)
            : base(mediaModel) { }

        public override bool CanExecute(Object parameter)
        {
            return true;
        }

        public override void Execute(Object parameter)
        {
            var parameters = parameter as object[];
            var path = parameters[0] as String;
            var fontSize = parameters[1] as Int32?;
            var subtitlesEnabled = parameters[2] as Boolean?;
            var fontColor = parameters[3] as Color?;
            if (!String.IsNullOrWhiteSpace(path))
            {
                List<SubtitlesLine> subtitles = new List<SubtitlesLine>();
                try
                {
                    using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("iso-8859-2")))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Int32 timeStart;
                            Int32 timeEnd;
                            String text;
                            string timePattern = @"{(.*?)}";
                            string textPattern = @"[^}]*$";

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
                mediaModel.Subtitles.CurrentSubtitles = subtitles;
                mediaModel.Subtitles.SubtitlesPath = path;
                mediaModel.Subtitles.SubtitlesFont = fontSize != null ? (Int32) fontSize : 12;
                mediaModel.Subtitles.SubtitlesEnable = subtitlesEnabled != null ? (Boolean)subtitlesEnabled : false;
                mediaModel.Subtitles.SubtitlesColor = fontColor != null ? (Color)fontColor : Color.FromRgb(255, 255, 255);
            }
        }
    }
}
