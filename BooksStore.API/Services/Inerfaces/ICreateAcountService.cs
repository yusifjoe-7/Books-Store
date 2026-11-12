using BooksStore.Models.DOTs;

namespace BooksStore.Services.Inerfaces;

public interface ICreateAcountService
{
    public Task<LogResponse> Create(NewUser NUser);
}
