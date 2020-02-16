using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        private string _filePath = ""; 
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
            if (TBEmail.Text == "" || TBPassword.Password == "" || TBPasswordCheck.Password == "" || TBFirstName.Text == "" || TBLastName.Text == "")
            {
                error.AppendLine("Все поля обязательны для заполнения!");
            }

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
            if(TBPassword.Password != TBPasswordCheck.Password)
            {
                error.AppendLine("Пароли не совпадают");
            }
            if (DateTime.Now < DPAge.SelectedDate)
            {
                error.AppendLine("Дата выбранна некоректно");
            }
            else 
            {
                if ((DateTime.Now - DPAge.SelectedDate).Value.Total < 10)
                {
                    error.AppendLine("Бегуну не может быть меньше 10 лет");
                }
            }
            Regex template = new Regex(@"^[A-z0-9.-]+@[A-z0-9]+\.[A-z0-9]+$");
            if (template.IsMatch(TBEmail.Text)) return;
            error.AppendLine("Почта введена некоректно");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image formats | *.jpg; *.png";
            if(ofd.ShowDialog() == true)
            {
                //byte[] imageData = null;
                //  imageData = 
                _filePath = ofd.FileName;
                ImageProfile.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_filePath);
            }
        }
    }
}
