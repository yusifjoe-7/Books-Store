using BooksStore.Models.DOTs;

namespace BooksStore.Services.Inerfaces;

public interface IRefreshService
{
    public Task<LogResponse> Refresh(string OldRefreshToken);
}
