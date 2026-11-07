using BooksStore.Data;
using BooksStore.Models.Entities;
using BooksStore.Models.DOTs;
using BooksStore.Services.Inerfaces;
using AutoMapper;


namespace BooksStore.Services;
public class AddWriterService : IAddWriterService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AddWriterService(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(AddWriterRequest request)
    {
        var writer = _mapper.Map<Writer>(request);
        _context.Writers.Add(writer);
        await _context.SaveChangesAsync();
    }
}
