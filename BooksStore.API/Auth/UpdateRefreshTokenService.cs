using BooksStore.Data;
using BooksStore.Models.Entities;
using BooksStore.Services.Inerfaces;

namespace BooksStore.Auth;

public class UpdateRefreshTokenService :IUpdateRefreshTokenService
{
    private readonly AppDbContext _context;
    private readonly AuthHelpers _helper;

     public UpdateRefreshTokenService(AppDbContext DB, AuthHelpers helpers)
    {
        _context = DB;
        _helper = helpers;
    }

     public async Task<string> AddRefreshToken(User user)
    {
        var refreshToken = _helper.GenerateRefreshToken();
        var RefreshTokenEntity = new RefreshToken
        {
             Id = Guid.NewGuid(),

        TokenHash = _helper.Hash(refreshToken),

        UserId = user.Id,

        CreatedAt = DateTime.UtcNow,

        ExpiresAt = DateTime.UtcNow.AddDays(10)
        };
        _context.RefreshTokens.Add(RefreshTokenEntity);
        await _context.SaveChangesAsync();
        return RefreshTokenEntity.TokenHash;
    }
}
