using KADataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARepository.Ifrastructure.Repositories.Interfaces
{
    interface IUserRepo
    {
        public IEnumerable<Contact> GetAllContacts();
        public Contact GetContactById(int id);
        public void CreateContact(Contact contact);
        public void UpdateContact(Contact contact);
        public void DeleteContact(Contact contact);
        bool SaveChanges();
    }
}
