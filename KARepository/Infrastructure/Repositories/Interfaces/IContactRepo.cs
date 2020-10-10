using KADataAccess.Models;
using System.Collections.Generic;

namespace KARepository.Infrastructure.Repositories.Interfaces
{
    interface IContactRepo
    {
        public IEnumerable<Contact> GetAllContacts();
        public Contact GetContactById(int id);
        public void CreateContact(Contact contact);
        public void UpdateContact(Contact contact);
        public void DeleteContact(Contact contact);
        bool SaveChanges();
    }
}
