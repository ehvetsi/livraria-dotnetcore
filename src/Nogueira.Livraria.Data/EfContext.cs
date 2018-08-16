using Microsoft.EntityFrameworkCore;
using Nogueira.Livraria.Data.EntitiesConfiguration;
using Nogueira.Livraria.Domain.Entities;

namespace Nogueira.Livraria.Data
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}