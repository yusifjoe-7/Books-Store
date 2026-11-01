using BooksStore.Data;
using BooksStore.Errors.Exceptions;
using BooksStore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Services;

public class GetBooksService
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
}
