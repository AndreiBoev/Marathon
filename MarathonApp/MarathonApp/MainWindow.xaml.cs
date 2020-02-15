using MarathonApp.Pages;
using System;
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
using System.Windows.Threading;

namespace MarathonApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _dispatcherTimer;
       public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.PageStart());
            DateNow.Text = DateTime.Now.ToLongDateString();
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Start();
            DispatcherTimer_Tick(null, null);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(2016, 11, 24, 6, 00, 00);
            TimeSpan timeSpan = dateTime - DateTime.Now;
            TBCount.Text = timeSpan.Days.ToString("N0") + " дней " + timeSpan.Hours.ToString("N0") + " часов " + timeSpan.Minutes.ToString("N0") + " минут " + timeSpan.Seconds.ToString("N0") + " секунд до старта марофона!"; 
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            //if(MainFrame.Content is PageStart)
            //{
            //    MainGrid.RowDefinitions[0].Height = new GridLength(150, GridUnitType.Pixel);
            //}
            //else
            //{
            //    MainGrid.RowDefinitions[0].Height = new GridLength(60, GridUnitType.Pixel);
            //}

            Page currentPage = (Page)MainFrame.Content;
   

            //if (currentPage.Tag?.ToString() == "Unauth")
            //{
            //    BtnLogout.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    BtnLogout.Visibility = Visibility.Visible;
            //}

            BtnLogout.Visibility = (currentPage.Tag?.ToString() == "Unauth") 
                ? Visibility.Collapsed
                : Visibility.Visible;

            if (MainFrame.Content is PageStart)
            {
                GridLarge.Visibility = Visibility.Visible;
                GridLittle.Visibility = Visibility.Collapsed;
            }
            else
            {
                GridLarge.Visibility = Visibility.Collapsed;
                GridLittle.Visibility = Visibility.Visible; 
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }
    }
}
