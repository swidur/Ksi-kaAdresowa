using KADataAccess.Models;
using KADataAccess;
using KARepository.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KARepository.Infrastructure.Repositories.Implementations
{
    public class ContactEFRepo : IContactRepo
    {
        private readonly KAContext context;
        public ContactEFRepo(KAContext context)
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

        public IEnumerable<Contact> GetAllContacts(string where)
        {
            where = where.ToLower();
            return context.Contact.
                Where(c => c.FirstName.ToLower().Contains(where) ||
                            c.LastName.ToLower().Contains(where) ||
                            c.Comment.ToLower().Contains(where) ||
                            c.Phone.ToLower().Contains(where) ||
                            c.Email.ToLower().Contains(where)).
                Where(c => c.IsDeleted == false).
                    ToList();
        }

        public IEnumerable<Contact> GetAllDeletedContacts(string where)
        {
            where = where.ToLower();
            return context.Contact.
                Where(c => c.FirstName.ToLower().Contains(where) ||
                            c.LastName.ToLower().Contains(where) ||
                            c.Comment.ToLower().Contains(where) ||
                            c.Phone.ToLower().Contains(where) ||
                            c.Email.ToLower().Contains(where)).
                Where(c => c.IsDeleted == true).
                    ToList();
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
