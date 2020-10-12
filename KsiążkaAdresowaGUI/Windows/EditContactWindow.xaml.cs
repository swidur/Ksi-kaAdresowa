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
    public partial class EditContactWindow : Window
    {
        Contact selectedContact = ((MainWindow)Application.Current.MainWindow).selectedEdit;
        ContactEFRepo repo = new ContactEFRepo(new KAContext());
        public EditContactWindow()
        {
            InitializeComponent();
            FirstNameTextBox.Text = selectedContact.FirstName;
            LastNameTextBox.Text  = selectedContact.LastName ;
            PhoneTextBox.Text     = selectedContact.Phone    ;
            EmailTextBox.Text     = selectedContact.Email    ;
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
            selectedContact.Phone = PhoneTextBox.Text;
            selectedContact.Email = EmailTextBox.Text;
            selectedContact.Comment = CommentTextBox.Text;

            repo.SaveChanges();
            this.Close();
        }
            
        private void ClearResponseLabel(object sender, TextChangedEventArgs e)
        {
            ResponseLabel.Content = " ";
        }
    }
}
