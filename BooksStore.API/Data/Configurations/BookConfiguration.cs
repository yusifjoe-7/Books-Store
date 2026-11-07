using BooksStore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksStore.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(b => b.writer)
            .WithMany(w => w.books)
            .HasForeignKey(b => b.WriterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.tags)
            .WithMany(t => t.books);
        builder.Property(b => b.Price)
            .HasColumnType("numeric(5,2)");
    }
}
