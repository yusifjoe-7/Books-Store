using BooksStore.Models.DOTs;
using BooksStore.Models.Entities;

namespace BooksStore.Services.Inerfaces;

public interface IAddService
{
    public Task<Writer> AddWriter(AddWriterRequest request);
    public Task<AddBookRequest> AddBook(AddBookRequest request);
}
