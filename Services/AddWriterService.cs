using BooksStore.Data;
using BooksStore.Errors.Exceptions;
using BooksStore.Models.Entities;
using BooksStore.Models.DOTs;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Services;

public class AddWriterService
{
    private AppDbContext _DB;
    public AddWriterService(AppDbContext DB)

    {
        _DB = DB;
    }

    public async Task Add(AddWriterRequest W)
    {
        var writer = new Writer
        {
            Id = Guid.NewGuid(),
            Name = W.Name,
        };
        _DB.Writers.Add(writer);
        await _DB.SaveChangesAsync();
    }
}
