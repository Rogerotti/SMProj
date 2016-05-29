﻿using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VJPlayer.Models;

namespace VJPlayer.Views
{
    public interface ICoreWindowView : IView
    {
        MediaElement Player { get; }

        void ShowWindow();
    }
}
