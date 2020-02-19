using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PageRegRunner.xaml
    /// </summary>
    public partial class PageRegRunner : Page
    {
        byte[] _imageData = null;
        public PageRegRunner()
        {
            InitializeComponent();
            CBCountry.ItemsSource = AppData.Context.Countries.ToList();
            CBGender.ItemsSource = AppData.Context.Genders.ToList();
            CBCountry.SelectedIndex = 0;
            CBGender.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            //erorr.Clear();
            if (TBEmail.Text == "" || TBPassword.Password == "" || TBPasswordCheck.Password == "" || TBFirstName.Text == "" || TBLastName.Text == "" || ImageProfile == null)
            {
                error.AppendLine("Все поля обязательны для заполнения!");
            }
            else
            {
                //bool hasDigits = false;
                //bool hasUpper = false;
                //bool hasLower = false;

                bool hasDigits = false, hasUpper = false, hasLower = false;


                foreach (var symb in TBPassword.Password)
                {
                    if (char.IsDigit(symb))
                    {
                        hasDigits = true;
                    }
                    if (char.IsUpper(symb))
                    {
                        hasUpper = true;
                    }
                    if (char.IsLower(symb))
                    {
                        hasLower = true;
                    }
                }
                if (!hasDigits)
                {
                    error.AppendLine("Минимум  1 цифра");
                }
                if (!hasUpper)
                {
                    error.AppendLine("Минимум 1 прописная буква");
                }
                if (!hasLower)
                {
                    error.AppendLine("Минимум одна строчная буква");
                }
                if (TBPassword.Password != TBPasswordCheck.Password)
                {
                    error.AppendLine("Пароли не совпадают");
                }
                if (DateTime.Now < DPAge.SelectedDate)
                    {
                        error.AppendLine("Дата выбранна некоректно");
                    }
                else
                {
                   if ((DateTime.Now - DPAge.SelectedDate).Value.TotalDays <= 3650)
                    {
                        error.AppendLine("Бегуну не может быть меньше 10 лет");
                    }
                }
                Regex template = new Regex(@"^[A-z0-9.-]+@[A-z0-9]+\.[A-z0-9]+$");
                if (!template.IsMatch(TBEmail.Text))
                {
                    error.AppendLine("Почта введена некоректно");
                }
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Entities.User currerntUser = new Entities.User
            {
                Email = TBEmail.Text,
                Password = TBPassword.Password,
                FirstName = TBFirstName.Text,
                LastName = TBLastName.Text,
                RoleId = "R"
            };
            AppData.Context.Users.Add(currerntUser);
            Entities.Runner currentRunner = new Entities.Runner
            {
                Email = TBEmail.Text,
                Gender = (CBGender.SelectedItem as Entities.Gender).Gender1,
                DateOfBirth = DPAge.SelectedDate,
                CountryCode = (CBCountry.SelectedItem as Entities.Country).CountryCode,
                Photo = _imageData,
                User = currerntUser
            };
            AppData.Context.Runners.Add(currentRunner);
            AppData.Context.SaveChanges();
            NavigationService.Navigate(new PageRegEvent());
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image formats | *.jpg; *.png";
            if(ofd.ShowDialog() == true)
            {
                _imageData = File.ReadAllBytes(ofd.FileName);
                ImageProfile.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_imageData);
            }
        }
    }
}
