using BooksStore.Helpers;

namespace BooksStore.Models.Entities;

public class Tag
{
    public Guid Id { get; set; }
    public TagsEnum type { get; set; }
    public List<Book> books { get; set; }
    
}
