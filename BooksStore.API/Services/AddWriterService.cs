using BooksStore.Data;
using BooksStore.Errors.Exceptions;
using BooksStore.Models.Entities;
using BooksStore.Models.DOTs;
using Microsoft.EntityFrameworkCore;
using BooksStore.Controllers;

namespace BooksStore.Services;
public class AddWriterService
{
    private readonly AppDbContext _context;
    private readonly ILogger<AddWriterService> _logger;

    public AddWriterService(AppDbContext context, ILogger<AddWriterService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Add(AddWriterRequest request)
    {
        _logger.LogInformation("Request Name = {Name}", request.Name);
        var writer = new Writer { Id = Guid.NewGuid(), Name = request.Name };
        _context.Writers.Add(writer);
        await _context.SaveChangesAsync();
    }
}
