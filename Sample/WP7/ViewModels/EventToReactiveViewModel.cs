﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codeplex.Reactive;
using Microsoft.Phone.Reactive;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace WP7.ViewModels
{
    public class EventToReactiveViewModel
    {
        // binding from UI
        public ReactiveProperty<MouseEventArgs> MouseMove { get; private set; }
        public ReactiveProperty<string> CurrentPoint { get; private set; }

        public EventToReactiveViewModel()
        {
            // mode off RaiseLatestValueOnSubscribe, because initialValue is null.
            var mode = ReactivePropertyMode.DistinctUntilChanged;

            MouseMove = new ReactiveProperty<MouseEventArgs>(mode: mode);

            CurrentPoint = MouseMove
                .Select(m => m.GetPosition(null))
                .Select(p => string.Format("X:{0} Y:{1}", p.X, p.Y))
                .ToReactiveProperty("MouseDown and drag move");
        }
    }
}