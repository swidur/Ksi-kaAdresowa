using KADataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
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

        internal static string SetAgeTextBoxFromContact(Contact selectedContact)
        {
            if (selectedContact.DateOfBirth.HasValue)
            {
                return (DateTime.Now.Year - selectedContact.DateOfBirth.Value.Date.Year).ToString();
            }
            else return "";
        }

        internal static DateTime? GetDateOfBirthFromTextBox(TextBox ageTextBox)
        {
            DateTime? dob = null;
            if (ageTextBox.Text.Trim() != "")
            {
                dob = DateTime.Now.AddYears(-int.Parse(ageTextBox.Text)).Date;
            }
            return dob;
        }

        public static int SetSexComboBoxFromContact(Contact contact)
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
