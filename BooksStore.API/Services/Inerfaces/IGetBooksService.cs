using BooksStore.Models.Entities;

namespace BooksStore.Services.Inerfaces;

public interface IGetBooksService
{
    public Task<Book[]> GetBooks(int skip, int take);
    public Task<Book> GetABook(Guid Id);

}
