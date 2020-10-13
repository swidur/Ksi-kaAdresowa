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

        public void CreateContact(KAContext context, Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentException(nameof(contact));
            }

            context.Contact.Add(contact);
        }

        public void DeleteContact(KAContext context, Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentException(nameof(contact));
            }

            contact.IsDeleted = true;
            context.Update(contact);
            SaveChanges(context);
        }

        public IEnumerable<Contact> GetAllContacts(KAContext context, string where)
        {
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

        public IEnumerable<Contact> GetAllDeletedContacts(KAContext context, string where)
        {
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

        public Contact GetContactById(KAContext context, int id)
        {
            return context.Contact.Find(id);
        }

        public void UpdateContact(KAContext context, Contact contact)
        {

        }

        public bool SaveChanges(KAContext context)
        {
            return (context.SaveChanges() >= 0);
        }


    }
}
