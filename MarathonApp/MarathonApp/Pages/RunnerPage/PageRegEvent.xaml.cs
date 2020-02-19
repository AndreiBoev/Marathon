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

namespace MarathonApp.Pages.RunnerPage
{
    /// <summary>
    /// Interaction logic for PageRegEvent.xaml
    /// </summary>
    public partial class PageRegEvent : Page
    {
        public PageRegEvent()
        {
            InitializeComponent();
            CBoxRunner.ItemsSource = AppData.Context.Charities.ToList().Take(100).ToList();
            CBoxRunner.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRegistrationСonfirmation());
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
                WindowInfo taskWindow = new WindowInfo();
                taskWindow.Show();           
        }
    }
}
