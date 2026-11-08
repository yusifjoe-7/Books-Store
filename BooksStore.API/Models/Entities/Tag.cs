using BooksStore.Helpers;

namespace BooksStore.Models.Entities;

public class Tag
{
    public int Id { get; set; }
    public String title { get; set; }
    public ICollection<Book> books { get; set; } = new List<Book>();
    
}
