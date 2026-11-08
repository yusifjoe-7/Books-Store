namespace BooksStore.Models.DOTs;

public class BookResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public WriterBookResponse writer {get; set;}
    public List<TagsResponse> tags { get; set; }
}
