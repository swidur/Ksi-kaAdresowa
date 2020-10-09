using System;
using System.Collections.Generic;
using System.Text;

namespace KsiążkaAdresowaGUI.Classes
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
