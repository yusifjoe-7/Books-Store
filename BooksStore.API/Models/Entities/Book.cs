namespace BooksStore.Models.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid WriterId { get; set; }
    public Writer writer { get; set; }
    public List<Tag> tags { get; set; }
    
}
