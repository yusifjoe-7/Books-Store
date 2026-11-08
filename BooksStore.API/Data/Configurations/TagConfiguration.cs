using BooksStore.Helpers;
using BooksStore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksStore.Helpers.TagTitles;

namespace BooksStore.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasData(
        new Tag { Id = 1, title = TagTitles.Fantasy },
        new Tag { Id = 2, title = TagTitles.SciFi },
        new Tag { Id = 3, title = TagTitles.MysteryThriller },
        new Tag { Id = 4, title = TagTitles.Romance },
        new Tag { Id = 5, title = TagTitles.Horror },
        new Tag { Id = 6, title = TagTitles.HistoricalFiction },
        new Tag { Id = 7, title = TagTitles.YA }
    );
    }
}
