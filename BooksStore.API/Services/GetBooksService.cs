using AutoMapper;
using AutoMapper.QueryableExtensions;
using BooksStore.Data;
using BooksStore.Errors.Exceptions;
using BooksStore.Models.DOTs;
using BooksStore.Services.Inerfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Services;

public class GetBooksService : IGetBooksService
{
    private readonly AppDbContext _DB;
    private readonly IMapper _mapper;
    public GetBooksService(AppDbContext DB, IMapper mapper)
    {
        _DB = DB;
        _mapper = mapper;
    }

    public async Task<BookResponse[]> GetBooks(int skip, int take)
    {
        var Books = await _DB.Books
                            .OrderBy(b => b.Id)
                            .Skip(skip)
                            .Take(take)
                            .Include(b => b.writer)
                            .Include(b => b.tags)
                            .ProjectTo<BookResponse>(_mapper.ConfigurationProvider)
                            .ToArrayAsync();

        if (Books.Length == 0)
            throw new TooManySkipsException(skip); 

        return Books;

    }

    public async Task<BookResponse> GetABook(Guid Id)
    {
        var book = await _DB.Books
                                .Include(b => b.writer)
                                .Include(b => b.tags)
                                .ProjectTo<BookResponse>(_mapper.ConfigurationProvider)
                                .SingleOrDefaultAsync(b => b.Id == Id);
                               

        if (book == null)
        {
            throw new BookNotFoundException(Id);
        }
        return book;
    }
}
