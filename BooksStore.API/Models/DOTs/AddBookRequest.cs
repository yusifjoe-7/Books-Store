using BooksStore.Models.Entities;

namespace BooksStore.Models.DOTs;

public class AddBookRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid WriterId { get; set; }
    public List<int> tagsIds { get; set; } = new List<int>();
}
