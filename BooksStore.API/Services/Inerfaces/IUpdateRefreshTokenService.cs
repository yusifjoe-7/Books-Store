using BooksStore.Models.Entities;

namespace BooksStore.Services.Inerfaces;

public interface IUpdateRefreshTokenService
{
    public Task<string> AddRefreshToken(User user);
}
