using KADataAccess.Models;
using System.Collections.Generic;

namespace KADataAccess.Infrastructure.Repositories.Interfaces
{
    public interface IContactRepo
    {
        public IEnumerable<Contact> GetAllContacts(string where);
        public IEnumerable<Contact> GetAllDeletedContacts(string where);
        public Contact GetContactById(int id);
        public void CreateContact(Contact contact);
        public void UpdateContact(Contact contact);
        public void DeleteContact(Contact contact);
        bool SaveChanges(KAContext context);
    }
}
