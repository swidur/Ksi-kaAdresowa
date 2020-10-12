using AutoMapper;
using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using KARepository.Infrastructure.Profiles;
using KARepository.DTOs;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace KsiążkaAdresowaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> people;

        ContactEFRepo repo = new ContactEFRepo(new KAContext());
        Mapper mapper;
        public bool showActiveContacts = true;

        public MainWindow()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ContactProfile()));
            mapper = new Mapper(config);

        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (showActiveContacts)
            {
                UpdateActiveContacts(SearchBox.Text);
            }
            else
            {
                UpdateDeletedContacts(SearchBox.Text);
            }
        }
        private void ContactsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateActiveContacts(SearchBox.Text);
        }

        private void WindowActivated(object sender, EventArgs e)
        {
            UpdateActiveContacts(SearchBox.Text);
        }

        public void UpdateActiveContacts(string where)
        {
            //people = new ObservableCollection<ContactReadDTO>(mapper.Map<IEnumerable<ContactReadDTO>>(repo.GetAllContacts(where)));
            people = new ObservableCollection<Contact>(repo.GetAllContacts(where));
            this.ContactsDataGrid.ItemsSource = people;
        }
        
        public void UpdateDeletedContacts(string where)
        {
            //people = new ObservableCollection<ContactReadDTO>(mapper.Map<IEnumerable<ContactReadDTO>>(repo.GetAllDeletedContacts(where)));
            people = new ObservableCollection<Contact>(repo.GetAllDeletedContacts(where));

            this.ContactsDataGrid.ItemsSource = people;
        }

        private void AddContact_Clik(object sender, RoutedEventArgs e)
        {
            //repo.CreateContact(new Contact() { FirstName = "Alastor", LastName = "Moody", Email = "defencedarkarts@hogwart.co.uk", Comment = "Do not contact unless emergency" });
            //repo.SaveChanges();

            //UpdateContacts(SearchBox.Text);
            AddContactWindow addContactWindow = new AddContactWindow() { Owner = this};
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
            UpdateActiveContacts(SearchBox.Text);
        }

        private void Bin_Clik(object sender, RoutedEventArgs e)
        {
            showActiveContacts = false;
            SearchBox_SetText("");
            UpdateDeletedContacts(SearchBox.Text);
        }

        private void Export_Clik(object sender, RoutedEventArgs e)
        {

        }
        private void Import_Clik(object sender, RoutedEventArgs e)
        {

        }
      

        private void Delete_DGContext(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toDeleteFromBindedList = (Contact)item.SelectedCells[0].Item;

            //Remove the toDeleteFromBindedList object from your ObservableCollection
            people.Remove(toDeleteFromBindedList);
            toDeleteFromBindedList.IsDeleted = true;
            repo.SaveChanges();
        }


    }
}
