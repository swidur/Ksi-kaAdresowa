using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.Repositories.Implementations;
using System.Windows;
using System.Windows.Controls;


namespace KsiążkaAdresowaGUI.Windows
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
            if (FirstNameTextBox.Text.Trim() == "")
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
                CommentTextBox.Text = " ";
                ResponseLabel.Content = "Dodano!";

            }
        }
            
        private void ClearResponseLabel(object sender, TextChangedEventArgs e)
        {
            ResponseLabel.Content = " ";
        }
    }
}
