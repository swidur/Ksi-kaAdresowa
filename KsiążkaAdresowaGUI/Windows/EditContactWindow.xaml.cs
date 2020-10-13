using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.Repositories.Implementations;
using KsiążkaAdresowaGUI.Helpers;
using Microsoft.EntityFrameworkCore;
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
    public partial class EditContactWindow : Window
    {
        Contact selectedContact = ((MainWindow)Application.Current.MainWindow).selectedEdit;
        KAContext _context;
        ContactEFRepo _repo;
        public EditContactWindow()
        {
            InitializeComponent();
            _context = new KAContext();
            _repo = new ContactEFRepo(_context);

            FirstNameTextBox.Text = selectedContact.FirstName;
            LastNameTextBox.Text  = selectedContact.LastName;
            AgeTextBox.Text = Helper.SetAgeTextBoxFromContact(selectedContact);
            SexComboBox.SelectedIndex = Helper.SetSexComboBoxFromContact(selectedContact);
            CityTextBox.Text  = selectedContact.City;
            StreetTextBox.Text  = selectedContact.Street;
            AreaCodeTextBox.Text  = selectedContact.AreaCode;
            HouseNumberTextBox.Text  = selectedContact.HouseNumber;
            FlatNumberTextBox.Text  = selectedContact.FlatNumber;
            PhoneTextBox.Text     = selectedContact.Phone;
            EmailTextBox.Text     = selectedContact.Email;
            CommentTextBox.Text = selectedContact.Comment;
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text == "")
            {
                ResponseLabel.Content = "Podaj imię";
                return;
            }         

            selectedContact.FirstName = FirstNameTextBox.Text;
            selectedContact.LastName = LastNameTextBox.Text;
            selectedContact.DateOfBirth = Helper.GetDateOfBirthFromTextBox(AgeTextBox);
            selectedContact.Sex = Helper.GetSexComboBoxSelectedItemText(SexComboBox);
            selectedContact.AreaCode = AreaCodeTextBox.Text;
            selectedContact.City = CityTextBox.Text;
            selectedContact.Street = StreetTextBox.Text;
            selectedContact.HouseNumber = HouseNumberTextBox.Text;
            selectedContact.FlatNumber = FlatNumberTextBox.Text;
            selectedContact.Phone = PhoneTextBox.Text;
            selectedContact.Email = EmailTextBox.Text;
            selectedContact.Comment = CommentTextBox.Text;

            _context.Entry(selectedContact).State = EntityState.Modified;
            _repo.SaveChanges();
            this.Close();
        }
            
        private void ClearResponseLabel(object sender, TextChangedEventArgs e)
        {
            ResponseLabel.Content = " ";
        }

        private void NumberValidationAgeTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
