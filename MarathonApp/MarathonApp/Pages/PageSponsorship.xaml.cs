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
    /// Interaction logic for PageSponsorship.xaml
    /// </summary>
    public partial class PageSponsorship : Page
    {
        
        public PageSponsorship()
        {
            InitializeComponent();
            TBoxAmount.Text = TBlockAmount.Text;
            CBoxRunner.ItemsSource = AppData.Context.RegistrationEvents.ToList().Where(p =>
            p.Event.MarathonId == 5).ToList().Take(100).ToList();
            CBoxRunner.SelectedIndex = 0;
        }

        private void ButAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (TBFirstName.Text == "" || TBCard.Text == "" || TBNumberCard.Text == "" || TBMonth.Text == "" || TBoxAmount.Text == "")
            {
                errors.AppendLine("Все поля обязательны для заполнения!");
            }
            if (TBNumberCard.Text.Length != 16)
                errors.AppendLine("Номер карточки состоит из 16 цифр");
            if (TBYear.Text == "" || TBCVC.Text == "") {
                    errors.AppendLine("Данные карты введены некоректно");
            }
            else
            {
                if (new DateTime(int.Parse(TBYear.Text), int.Parse(TBMonth.Text), 01) < DateTime.Now.Date)
                    errors.AppendLine("У Вас просроченная карта");
            }
            if (TBCVC.Text.Length != 3)
                errors.AppendLine("CVC код содержит 3 цифры");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AppData.Context.Sponsorships.Add(new Entities.Sponsorship
            {
                Amount = decimal.Parse(TBoxAmount.Text),
                SponsorName = TBFirstName.Text,
                Registration = (CBoxRunner.SelectedItem as Entities.RegistrationEvent).Registration
            });
               AppData.Context.SaveChanges();
            NavigationService.Navigate(new PageSponsorshipСonfirmation(TBoxAmount.Text, CBoxRunner.Text, TBCharity.Text));
           
        }

        private void ButCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TBoxAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBlockAmount.Text = TBoxAmount.Text;
            try
            {
                int quantity = int.Parse(TBoxAmount.Text);
            }
            catch
            {
                string content = TBoxAmount.Text;
                string newWord = "";
                foreach (var item in content)
                {
                    if (char.IsDigit(item) || item == '.')
                        newWord += item;
                }
                TBoxAmount.Text = newWord;
            }
        }


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CBoxRunner.SelectedItem is Entities.RegistrationEvent currentRegEvent)
            {
                WindowInfo taskWindow = new WindowInfo(currentRegEvent);
                taskWindow.Show();
            }
        }

        private void CBoxRunner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBoxRunner.SelectedItem is Entities.RegistrationEvent currentRegEvent)
            {   
                TBCharity.Text = currentRegEvent.Registration.Charity.CharityName;
            }    
        }

        private void TBNumberCard_TextChanged(object sender, TextChangedEventArgs e)
        {
                TBNumberCard.Text = TBNumberCard.Text;
                try
                {
                    int quantity = int.Parse(TBNumberCard.Text);
                }
                catch
                {
                    string content = TBNumberCard.Text;
                    string newWord = "";
                    foreach (var item in content)
                    {
                        if (char.IsDigit(item) || item == ',')
                            newWord += item;
                    }
                    TBNumberCard.Text = newWord;
                }
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            double amount = Convert.ToDouble(TBoxAmount.Text);
            //amount = amount + 10;
            amount += 10;
            TBoxAmount.Text =  amount.ToString("N2");
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            double amount = Convert.ToDouble(TBoxAmount.Text);
            //amount = amount + 10;
            amount -= 10;
            TBoxAmount.Text = amount.ToString("N2");
        }
    }
}
