using KADataAccess;
using KADataAccess.Models;
using KARepository.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KARepository.Infrastructure.Repositories.Implementations
{
    public class ContactEFRepo : IContactRepo
    {
        public ContactEFRepo()
        {
        }

        public void CreateContact(Contact contact)
        {
            KAContext context = new KAContext();
            if (contact == null)
            {
                throw new ArgumentException(nameof(contact));
            }

            context.Contact.Add(contact);
            SaveChanges(context);
        }

        public void DeleteContact(Contact contact)
        {
            KAContext context = new KAContext();
            if (contact == null)
            {
                throw new ArgumentException(nameof(contact));
            }

            contact.IsDeleted = true;
            context.Update(contact);
            SaveChanges(context);
        }

        public IEnumerable<Contact> GetAllContacts(string where)
        {
            KAContext context = new KAContext();
            where = where.ToLower();
            var result = context.Contact.AsNoTracking().
                Where(c => c.FirstName.ToLower().Contains(where) ||
                            c.LastName.ToLower().Contains(where) ||
                            c.Sex.ToLower().Contains(where) ||
                            c.City.ToLower().Contains(where) ||
                            c.Street.ToLower().Contains(where) ||
                            c.AreaCode.ToLower().Contains(where) ||
                            c.HouseNumber.ToLower().Contains(where) ||
                            c.FlatNumber.ToLower().Contains(where) ||
                            c.Comment.ToLower().Contains(where) ||
                            c.Phone.ToLower().Contains(where) ||
                            c.Email.ToLower().Contains(where)).
                Where(c => c.IsDeleted == false).
                    ToList();
            return result;
        }

        public IEnumerable<Contact> GetAllDeletedContacts(string where)
        {
            KAContext context = new KAContext();
            where = where.ToLower();
            return context.Contact.AsNoTracking().
                Where(c => c.FirstName.ToLower().Contains(where) ||
                            c.LastName.ToLower().Contains(where) ||
                            c.Sex.ToLower().Contains(where) ||
                            c.City.ToLower().Contains(where) ||
                            c.Street.ToLower().Contains(where) ||
                            c.AreaCode.ToLower().Contains(where) ||
                            c.HouseNumber.ToLower().Contains(where) ||
                            c.FlatNumber.ToLower().Contains(where) ||
                            c.Comment.ToLower().Contains(where) ||
                            c.Phone.ToLower().Contains(where) ||
                            c.Email.ToLower().Contains(where)).
                Where(c => c.IsDeleted == true).
                    ToList();
        }

        public Contact GetContactById(int id)
        {
            KAContext context = new KAContext();
            return context.Contact.Find(id);
        }

        public void UpdateContact(Contact contact)
        {
            KAContext context = new KAContext();
            context.Update(contact);
            this.SaveChanges(context);
        }

        public bool SaveChanges(KAContext context)
        {
            return (context.SaveChanges() >= 0);
        }


    }
}
