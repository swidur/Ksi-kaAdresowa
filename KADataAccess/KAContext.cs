using KADataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KADataAccess
{
    public class KAContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Temp\\ksiazkaAdresowa.db");
        }




        public DbSet<Contact> Contact { get; set; }
    }

}
