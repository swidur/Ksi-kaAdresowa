using AutoMapper;
using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.DTOs;
using KARepository.Infrastructure.Profiles;
using KARepository.Infrastructure.Repositories.Implementations;
using KsiążkaAdresowaGUI.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace KsiążkaAdresowaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ContactReadDTO> people;
        ContactEFRepo _repo;
        public bool _showActiveContacts = true;
        public ContactReadDTO _selectedEdit;
        Mapper _mapper;

        public MainWindow()
        {
            _repo = new ContactEFRepo();
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(new ContactProfile()));
            _mapper = new Mapper(config);

        }

        private void ShowActiveOrDeleted()
        {
            if (_showActiveContacts) GetActiveContacts(SearchBox.Text);
            else GetDeletedContacts(SearchBox.Text);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowActiveOrDeleted();
        }
        private void ContactsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ShowActiveOrDeleted();
        }
       
        private void WindowActivated(object sender, EventArgs e)
        {
            ShowActiveOrDeleted();
        }

        public void GetActiveContacts(string where)
        {
            people = null;
            LocationLabel.Content = "Kontakty";
            people = new ObservableCollection<ContactReadDTO>(_mapper.Map<IEnumerable<ContactReadDTO>>(_repo.GetAllContacts(where)));
            this.ContactsDataGrid.ItemsSource = people;
        }


        public void GetDeletedContacts(string where)
        {
            LocationLabel.Content = "Kosz";
            people = new ObservableCollection<ContactReadDTO>(_mapper.Map<IEnumerable<ContactReadDTO>>(_repo.GetAllDeletedContacts(where)));
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
            _showActiveContacts = true;
            GetActiveContacts(SearchBox.Text);
        }

        private void Bin_Clik(object sender, RoutedEventArgs e)
        {
            _showActiveContacts = false;
            GetDeletedContacts(SearchBox.Text);
        }

        private object GetDataGridElement(object sender)
        {
            var menuItem = (MenuItem)sender;
            var contextMenu = (ContextMenu)menuItem.Parent;
            var item = (DataGrid)contextMenu.PlacementTarget;

            return (ContactReadDTO)item.SelectedCells[0].Item;
        }

        private void Delete_DGContext(object sender, RoutedEventArgs e)
        {
            var toDeleteFromDG = (ContactReadDTO)GetDataGridElement(sender);
            people.Remove(toDeleteFromDG);

            var contact = _mapper.Map<Contact>(toDeleteFromDG);
            contact.IsDeleted = !contact.IsDeleted;
            _repo.UpdateContact(contact);
        }

        private void Edit_DGContext(object sender, RoutedEventArgs e)
        {
            _selectedEdit = (ContactReadDTO)GetDataGridElement(sender);

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