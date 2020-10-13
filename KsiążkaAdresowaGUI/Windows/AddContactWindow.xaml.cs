using AutoMapper;
using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.DTOs;
using KARepository.Infrastructure.Profiles;
using KARepository.Infrastructure.Repositories.Implementations;
using KsiążkaAdresowaGUI.Helpers;
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
        private Mapper _mapper;
        public AddContactWindow()
        {
            InitializeComponent();
            _repo = new ContactEFRepo();
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(new ContactProfile()));
            _mapper = new Mapper(config);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            KAContext context = new KAContext();

            if (FirstNameTextBox.Text.Trim() == "")
            {
                ResponseLabel.Content = "Podaj imię";
                return;
            }

            Contact newContact = _mapper.Map<Contact>(new ContactCreateDTO()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Age = AgeTextBox.Text != "" ? int.Parse(AgeTextBox.Text) : -1,
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


            _repo.CreateContact(context, newContact);

            if (_repo.SaveChanges(context))
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
