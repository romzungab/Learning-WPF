﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFEvents
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
           MainWindow wnd = new MainWindow();
            wnd.Title = "Changing the normal";
            if (e.Args.Length == 1)
                MessageBox.Show("Now opening file:\n \n" + e.Args[0]);
            wnd.Show();
        }
    }
}
