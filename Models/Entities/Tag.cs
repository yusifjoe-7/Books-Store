using BooksStore.Helpers;

namespace BooksStore.Models.Entities;

public class Tag
{
    public Guid Id;
    public TagsEnum type;
    public List<Book> books;
    
}
