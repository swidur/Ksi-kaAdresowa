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
    public partial class EditContactWindow : Window
    {
        ContactReadDTO contactFromDataGrid = ((MainWindow)Application.Current.MainWindow)._selectedEdit;
        ContactEFRepo _repo;
        private Mapper _mapper;

        public EditContactWindow()
        {
            InitializeComponent();
            _repo = new ContactEFRepo();
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(new ContactProfile()));
            _mapper = new Mapper(config);

            FirstNameTextBox.Text = contactFromDataGrid.FirstName;
            LastNameTextBox.Text = contactFromDataGrid.LastName;
            AgeTextBox.Text = contactFromDataGrid.Age != null ? contactFromDataGrid.Age.ToString() : "";
            SexComboBox.SelectedIndex = Helper.SetSexComboBoxFromContact(contactFromDataGrid);
            CityTextBox.Text = contactFromDataGrid.City;
            StreetTextBox.Text = contactFromDataGrid.Street;
            AreaCodeTextBox.Text = contactFromDataGrid.AreaCode;
            HouseNumberTextBox.Text = contactFromDataGrid.HouseNumber;
            FlatNumberTextBox.Text = contactFromDataGrid.FlatNumber;
            PhoneTextBox.Text = contactFromDataGrid.Phone;
            EmailTextBox.Text = contactFromDataGrid.Email;
            CommentTextBox.Text = contactFromDataGrid.Comment;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            KAContext context = new KAContext();

            if (FirstNameTextBox.Text == "")
            {
                ResponseLabel.Content = "Podaj imię";
                return;
            }

            contactFromDataGrid.FirstName = FirstNameTextBox.Text;
            contactFromDataGrid.LastName = LastNameTextBox.Text;
            contactFromDataGrid.Age = AgeTextBox.Text != "" ? int.Parse(AgeTextBox.Text) : -1;
            contactFromDataGrid.Sex = Helper.GetSexComboBoxSelectedItemText(SexComboBox);
            contactFromDataGrid.AreaCode = AreaCodeTextBox.Text;
            contactFromDataGrid.City = CityTextBox.Text;
            contactFromDataGrid.Street = StreetTextBox.Text;
            contactFromDataGrid.HouseNumber = HouseNumberTextBox.Text;
            contactFromDataGrid.FlatNumber = FlatNumberTextBox.Text;
            contactFromDataGrid.Phone = PhoneTextBox.Text;
            contactFromDataGrid.Email = EmailTextBox.Text;
            contactFromDataGrid.Comment = CommentTextBox.Text;

            Contact contact = _mapper.Map<Contact>(contactFromDataGrid);
            context.Update(contact);
            _repo.SaveChanges(context);
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
