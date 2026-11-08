using BooksStore.Data;
using BooksStore.Models.Entities;
using BooksStore.Models.DOTs;
using BooksStore.Services.Inerfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace BooksStore.Services;
public class AddService : IAddService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AddService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Writer> AddWriter(AddWriterRequest request)
    {
        var writer = _mapper.Map<Writer>(request);
        _context.Writers.Add(writer);
        await _context.SaveChangesAsync();
        return writer;
    }

    

    public async Task<AddBookRequest> AddBook(AddBookRequest request)
    {
        var BookCreate = new CreateBooks();
        var requestedIds = request.tagsIds.Distinct().ToList();

        var tags = await _context.Tags
            .Where(t => requestedIds.Contains(t.Id))
            .ToListAsync();

        if (tags.Count != requestedIds.Count)
        {
            var missingIds = requestedIds.Except(tags.Select(t => t.Id)).ToList();
            throw new KeyNotFoundException($"Tag IDs not found: {string.Join(", ", missingIds)}");
        }
        var book = BookCreate.Create(request, tags);
        _context.Books.Add(
            book
        );
        await _context.SaveChangesAsync();

        return request;

    }

    
}
