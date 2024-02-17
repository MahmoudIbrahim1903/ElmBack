using ElmTask.Domain.Entites.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ElmTask.Common.Extentions;

namespace ElmTask.Persistence.EntityConfiguration
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.Property(b => b.BookInfo).HasJsonConversion();
        }
    }
}
