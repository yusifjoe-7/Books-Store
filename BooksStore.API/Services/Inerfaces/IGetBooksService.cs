using BooksStore.Models.DOTs;

namespace BooksStore.Services.Inerfaces;

public interface IGetBooksService
{
    public Task<BookResponse[]> GetBooks(int skip, int take);
    public Task<BookResponse> GetABook(Guid Id);

}
