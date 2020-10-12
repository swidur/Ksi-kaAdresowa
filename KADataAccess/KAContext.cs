using KADataAccess.Models;
using Microsoft.EntityFrameworkCore;
namespace KADataAccess
{
    public class KAContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlite("Data Source=ksiazkaAdresowa.db");
        }

        public DbSet<Contact> Contact { get; set; }
    }
}
