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
    /// Interaction logic for PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(TBEmail.Text == "" || TBPassword.Password == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var currentUser = AppData.Context.Users.FirstOrDefault(p => p.Email == TBEmail.Text && p.Password == TBPassword.Password);
            if(currentUser != null)
            {
                switch (currentUser.RoleId)
                {
                    case "A":
                        NavigationService.Navigate(new PageMenuAdministrator());
                        break;
                    case "C":
                        NavigationService.Navigate(new PageMenuCoordinator());
                        break;
                    case "R":
                        NavigationService.Navigate(new PageMenuRunner());
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
