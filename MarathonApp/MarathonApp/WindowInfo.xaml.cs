using MarathonApp.Entities;
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
using System.Windows.Shapes;

namespace MarathonApp
{
    /// <summary>
    /// Interaction logic for WindowInfo.xaml
    /// </summary>
    public partial class WindowInfo : Window
    {
        public WindowInfo(
           RegistrationEvent currentEvent)
        {
            InitializeComponent();
            TBSponsor.Text = currentEvent.Registration.Charity.CharityName;
            TBDescription.Text = currentEvent.Registration.Charity.CharityDescription;
            ImLogo.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(
                AppDomain.CurrentDomain.BaseDirectory +  "..\\..\\Assets\\Charities\\" +  currentEvent.Registration.Charity.CharityLogo);
        }

        private void ImClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
