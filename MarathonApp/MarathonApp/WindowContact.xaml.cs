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
using System.Windows.Shapes;

namespace MarathonApp
{
    /// <summary>
    /// Interaction logic for WindowContact.xaml
    /// </summary>
    public partial class WindowContact : Window
    {
        public WindowContact()
        {
            InitializeComponent();
        }

        private void ImClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
