using KADataAccess;
using KADataAccess.Models;
using KARepository.Ifrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KsiążkaAdresowaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> people = new List<Contact>();
        public MainWindow()
        {
            InitializeComponent();

            var mapper = new IMapper();

            var repo = new UserEFRepo(new KAContext());
            people = repo.GetAllContacts().ToList();


            ListOfContacts.ItemsSource = people;
        }

        private void AddContact_Clik(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Contacts_Clik(object sender, RoutedEventArgs e)
        {

        }

        private void Export_Clik(object sender, RoutedEventArgs e)
        {

        }
        private void Import_Clik(object sender, RoutedEventArgs e)
        {

        }
        private void Bin_Clik(object sender, RoutedEventArgs e)
        {

        }
    }
}
