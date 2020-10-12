using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace KsiążkaAdresowaGUI
{
    /// <summary>
    /// Logika interakcji dla klasy AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        ContactEFRepo repo = new ContactEFRepo(new KAContext());
        public AddContactWindow()
        {
            InitializeComponent();
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text == "")
            {
                ResponseLabel.Content = "Podaj imię";
                return;
            }

            repo.CreateContact(new Contact()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Email = EmailTextBox.Text,
                Comment = CommentTextBox.Text
            });

            if (repo.SaveChanges())
            {
                FirstNameTextBox.Text =
                LastNameTextBox.Text =
                PhoneTextBox.Text =
                EmailTextBox.Text =
                CommentTextBox.Text = null;
                ResponseLabel.Content = "Dodano!";

            }
        }
            
        private void ClearResponseLabel(object sender, TextChangedEventArgs e)
        {
            ResponseLabel.Content = null;
        }
    }
}
