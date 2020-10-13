using KARepository.Infrastructure.DTOs;
using System.Windows.Controls;

namespace KsiążkaAdresowaGUI.Helpers
{
    public static class Helper
    {
        public static string GetSexComboBoxSelectedItemText(ComboBox comboBox)
        {
            string result;

            if (comboBox.SelectedItem == null)
            {
                result = "";
            }
            else
            {
                ComboBoxItem selectedItem = (ComboBoxItem)(comboBox.SelectedItem);
                switch (selectedItem.Content.ToString())
                {
                    case "Mężczyzna":
                        result = "M";
                        break;
                    case "Kobieta":
                        result = "K";
                        break;
                    default:
                        result = "";
                        break;
                }
            }
            return result;
        }

        public static int SetSexComboBoxFromContact(ContactReadDTO contact)
        {
            int result;
            switch (contact.Sex)
            {
                case "K":
                    result = 0;
                    break;
                case "M":
                    result = 1;
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;

        }
    }
}
