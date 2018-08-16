using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nogueira.Livraria.Domain.Entities;

namespace Nogueira.Livraria.Data.EntitiesConfiguration
{
    public class BookConfiguration : BaseConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.AuthorName)
                .HasMaxLength(50);

            builder.Property(c => c.Quantity)
                .IsRequired();

            base.Configure(builder);
        }
    }
}