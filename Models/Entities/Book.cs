namespace BooksStore.Models.Entities;

public class Book
{
    public Guid Id;
    public string Title;
    public Guid WriterId;
    public Writer writer;
    public List<Tag> tags;
    
}
