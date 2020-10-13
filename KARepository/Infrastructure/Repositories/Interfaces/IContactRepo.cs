using KADataAccess;
using KADataAccess.Models;
using System.Collections.Generic;

namespace KARepository.Infrastructure.Repositories.Interfaces
{
    interface IContactRepo
    {
        public IEnumerable<Contact> GetAllContacts(KAContext context, string where);
        public IEnumerable<Contact> GetAllDeletedContacts(KAContext context, string where);
        public Contact GetContactById(KAContext context, int id);
        public void CreateContact(KAContext context, Contact contact);
        public void UpdateContact(KAContext context, Contact contact);
        public void DeleteContact(KAContext context, Contact contact);
        bool SaveChanges(KAContext context);
    }
}
