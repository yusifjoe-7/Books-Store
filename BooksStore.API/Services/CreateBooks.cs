using BooksStore.Models.DOTs;
using BooksStore.Models.Entities;

namespace BooksStore.Services;

public class CreateBooks
{
    public Book Create(AddBookRequest request, List<Tag> Tags)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            WriterId = request.WriterId,
            tags = Tags
        };
        
        
    }
}
