using BooksStore.Models.DOTs;

namespace BooksStore.Services.Inerfaces;

public interface IAddWriterService
{
    public Task Add(AddWriterRequest request);
}
