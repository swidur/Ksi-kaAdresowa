using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.Repositories.Implementations;
using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using KsiążkaAdresowaGUI.Windows;

namespace KsiążkaAdresowaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> people;
        ContactEFRepo repo;
        public bool showActiveContacts = true;
        public Contact selectedEdit;

        public MainWindow()
        {
            repo = new ContactEFRepo(new KAContext());
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (showActiveContacts)
            {
                GetActiveContacts(SearchBox.Text);
            }
            else
            {
                GetDeletedContacts(SearchBox.Text);
            }
        }
        private void ContactsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            GetActiveContacts(SearchBox.Text);
        }

        private void WindowActivated(object sender, EventArgs e)
        {
            GetActiveContacts(SearchBox.Text);
        }

        public void GetActiveContacts(string where)
        {
            LocationLabel.Content = "Kontakty";
            people = new ObservableCollection<Contact>(repo.GetAllContacts(where));
            this.ContactsDataGrid.ItemsSource = people;
        }

        public void GetDeletedContacts(string where)
        {
            LocationLabel.Content = "Kosz";
            people = new ObservableCollection<Contact>(repo.GetAllDeletedContacts(where));
            ContactsDataGrid.ItemsSource = people;
        }

        private void AddContact_Clik(object sender, RoutedEventArgs e)
        {
            AddContactWindow addContactWindow = new AddContactWindow() { Owner = this };
            addContactWindow.ShowDialog();
        }

        private void SearchBox_SetText(string newText)
        {
            SearchBox.Text = newText;
        }
        private void Contacts_Clik(object sender, RoutedEventArgs e)
        {
            showActiveContacts = true;
            SearchBox_SetText("");
            GetActiveContacts(SearchBox.Text);
        }

        private void Bin_Clik(object sender, RoutedEventArgs e)
        {
            showActiveContacts = false;
            SearchBox_SetText("");
            GetDeletedContacts(SearchBox.Text);
        }

        private object GetDataGridElement(object sender)
        {
            var menuItem = (MenuItem)sender;
            var contextMenu = (ContextMenu)menuItem.Parent;
            var item = (DataGrid)contextMenu.PlacementTarget;

            return (Contact)item.SelectedCells[0].Item;
        }

        private void Delete_DGContext(object sender, RoutedEventArgs e)
        {

            var toDeleteFromDG = (Contact)GetDataGridElement(sender);
            people.Remove(toDeleteFromDG);
            toDeleteFromDG.IsDeleted = !toDeleteFromDG.IsDeleted;
            repo.SaveChanges();
        }

        private void Edit_DGContext(object sender, RoutedEventArgs e)
        {
            selectedEdit = (Contact)GetDataGridElement(sender);

            EditContactWindow addContactWindow = new EditContactWindow() { Owner = this };
            addContactWindow.ShowDialog();
        }

        private void Export_Clik(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Import_Clik(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
