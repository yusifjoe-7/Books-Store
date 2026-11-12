using BooksStore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksStore.Data.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasOne(r => r.User)
            .WithMany(u => u.RefreshTokens)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => r.TokenHash)
        .IsUnique();

        builder.Property(r => r.TokenHash)
        .IsRequired();

    }  
}
