using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.Repositories.Implementations;
using KsiążkaAdresowaGUI.Helpers;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KsiążkaAdresowaGUI.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        ContactEFRepo _repo;
        public AddContactWindow()
        {
            InitializeComponent();
            _repo = new ContactEFRepo(new KAContext());
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text.Trim() == "")
            {
                ResponseLabel.Content = "Podaj imię";
                return;
            }

            _repo.CreateContact(new Contact()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                DateOfBirth = Helper.GetDateOfBirthFromTextBox(AgeTextBox),
                Sex = Helper.GetSexComboBoxSelectedItemText(SexComboBox),
                AreaCode = AreaCodeTextBox.Text,
                City = CityTextBox.Text,
                Street = StreetTextBox.Text,
                HouseNumber = HouseNumberTextBox.Text,
                FlatNumber = FlatNumberTextBox.Text,
                Phone = PhoneTextBox.Text,
                Email = EmailTextBox.Text,
                Comment = CommentTextBox.Text
            });

            if (_repo.SaveChanges())
            {
                FirstNameTextBox.Text =
                LastNameTextBox.Text =
                AgeTextBox.Text = 
                AreaCodeTextBox.Text = 
                CityTextBox.Text =
                StreetTextBox.Text =
                HouseNumberTextBox.Text =
                FlatNumberTextBox.Text =
                PhoneTextBox.Text =
                EmailTextBox.Text =
                CommentTextBox.Text = " ";
                SexComboBox.SelectedItem = null;
                ResponseLabel.Content = "Dodano!";
            }
        }

        private void NumberValidationAgeTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void ClearResponseLabel(object sender, TextChangedEventArgs e)
        {
            ResponseLabel.Content = " ";
        }
    }
}
