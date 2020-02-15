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
    /// Interaction logic for PageMenuRunner.xaml
    /// </summary>
    public partial class PageMenuRunner : Page
    {
        public PageMenuRunner()
        {
            InitializeComponent();
        }

        private void BtnContact_Click(object sender, RoutedEventArgs e)
        {
            WindowContact windowContact = new WindowContact();
            windowContact.Show();
        }
    }
}
