using KADataAccess.Models;
using KADataAccess;
using KARepository.Ifrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KARepository.Ifrastructure.Repositories.Implementations
{
    public class UserEFRepo : IUserRepo
    {
        private readonly KAContext context;
        public UserEFRepo(KAContext context)
        {
            this.context = context;
        }

        public void CreateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentException(nameof(contact));
            }

            context.Contact.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentException(nameof(contact));
            }

            context.Contact.Remove(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return context.Contact.ToList();
        }

        public Contact GetContactById(int id)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id));
            }

            return context.Contact.Find(id);
        }
        public void UpdateContact(Contact contact)
        {
            Contact current = context.Contact.Find(contact.Id);

            context.Contact.Update(current);

            current = contact;
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

       
    }
}
