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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace Selene.Components
{
    /// <summary>
    /// Interaction logic for TimeDisplay.xaml
    /// </summary>
    public partial class TimeDisplay : UserControl
    {
        Timer TimeTimer;

        public TimeDisplay()
        {
            InitializeComponent();

            TimeTimer = new Timer(TimerTick, null, 
                TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100));
        }

        private async void TimerTick(object state)
        {
            try
            {
                await Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
                {
                    CurrentTimeText.Text = DateTime.Now.ToString("hh:mm:ss tt");
                }));
            }
            catch (TaskCanceledException) { }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            TimeTimer.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Flyout = new Selene.Flyouts.ClockFlyout();
            //Flyout.Top = 500;
            //Flyout.Left = 500;
            Flyout.Show();
        }
    }
}
