namespace BooksStore.Models.Entities;

public class Writer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Book> books { get; set; } = new List<Book>();

}
