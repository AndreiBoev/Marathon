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

namespace MarathonApp.Pages
{
    /// <summary>
    /// Interaction logic for PageSponsorshipСonfirmation.xaml
    /// </summary>
    public partial class PageSponsorshipСonfirmation : Page
    {
        public PageSponsorshipСonfirmation(string Amount, string Runner, string Charity)
        {
            InitializeComponent();
            TBlockAmount.Text = Amount;
            TBlockRunner.Text = Runner;
            TBlockCharity.Text = Charity;

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageStart());
        }
    }
}
