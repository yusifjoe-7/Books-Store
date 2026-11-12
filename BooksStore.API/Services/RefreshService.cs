using BooksStore.Auth;
using BooksStore.Data;
using BooksStore.Models.DOTs;
using BooksStore.Services.Inerfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Services;

public class RefreshService : IRefreshService
{
    private readonly AppDbContext _context;
    private readonly IUpdateRefreshTokenService _updateService;
    private readonly TokenService _tokenService;
    public RefreshService(AppDbContext context, IUpdateRefreshTokenService UpdateService, TokenService tokenService)
    {
        _context = context;
        _updateService = UpdateService;
        _tokenService = tokenService;
    }
    public async Task<LogResponse?> Refresh(string UserRefreshToken)
    {
        var OldRefreshToken = await _context.RefreshTokens.Include(t => t.User)
            .SingleOrDefaultAsync(t => t.TokenHash == UserRefreshToken);


        if (OldRefreshToken is null || !OldRefreshToken.IsActive) return null;
        
        var user = OldRefreshToken.User;

        var NewRefreshToken = await _updateService.AddRefreshToken(user);
        var NewAccessToke = _tokenService.CreateToken(user);
        return new LogResponse
        {
            RefreshToken = NewRefreshToken,
            AccessToken = NewAccessToke
        };
    }
    
}
