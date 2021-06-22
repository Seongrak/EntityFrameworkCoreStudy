using EntiryFrameworkCoreStudy.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntiryFrameworkCoreStudy.Data
{
    class EfStudyDbContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AspnetCoreEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
