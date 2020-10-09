using KsiążkaAdresowaGUI.Classes;
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
        List<Person> people = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();

            people.Add(new Person { FirstName = "Andrzej", LastName = "Lepper", Email = "alepper@polskawies.gov", Phone = "+48 699 488 251" });
            people.Add(new Person { FirstName = "Ireneusz", LastName = "Lis", Email = "lis@gmail.com", Phone = "+48 699 231 251" });
            people.Add(new Person { FirstName = "Tadeusz", LastName = "Kościuszko", Email = "", Phone = "+48 111 000 111" });
            people.Add(new Person { FirstName = "Roman", LastName = "Giertych", Email = "maturatobzdura@buziaczek.pl", Phone = "+48 444 488 251" });

            ListOfContacts.ItemsSource = people;
        }

        private void AddContact_Clik(object sender, RoutedEventArgs e)
        {

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
