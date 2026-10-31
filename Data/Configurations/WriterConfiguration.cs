using BooksStore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksStore.Data.Configurations;

public class WriterConfiguration : IEntityTypeConfiguration<Writer>
{
    public void Configure(EntityTypeBuilder<Writer> builder)
    
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(200);
        
    }
}
