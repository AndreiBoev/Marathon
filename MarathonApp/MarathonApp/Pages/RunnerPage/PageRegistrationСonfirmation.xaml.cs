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

namespace MarathonApp.Pages.RunnerPage
{
    /// <summary>
    /// Interaction logic for PageRegistrationСonfirmation.xaml
    /// </summary>
    public partial class PageRegistrationСonfirmation : Page
    {
        public PageRegistrationСonfirmation()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMenuRunner());
        }
    }
}
