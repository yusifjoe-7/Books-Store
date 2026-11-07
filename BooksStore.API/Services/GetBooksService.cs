using BooksStore.Data;
using BooksStore.Errors.Exceptions;
using BooksStore.Models.Entities;
using BooksStore.Services.Inerfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Services;

public class GetBooksService : IGetBooksService
{
    private AppDbContext _DB;
    public GetBooksService(AppDbContext DB)
    {
        _DB = DB;
    }

    public async Task<Book[]> GetBooks(int skip, int take)
    {
        var Books = await _DB.Books
                            .Skip(skip)
                            .Take(take)
                            .ToArrayAsync();

        if (Books.Length == 0)
            throw new TooManySkipsException(skip); 

        return Books;

    }

    public async Task<Book> GetABook(Guid Id)
    {
        var book = await _DB.Books
                                .SingleOrDefaultAsync(b => b.Id == Id);

        if (book == null)
        {
            throw new BookNotFoundException(Id);
        }
        return book;
    }
}
