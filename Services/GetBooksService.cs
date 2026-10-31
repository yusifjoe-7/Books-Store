using BooksStore.Data;
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
        var users = await _DB.Books
                            .Skip(skip)
                            .Take(take)
                            .ToArrayAsync();

        return users;
        
    }
}
