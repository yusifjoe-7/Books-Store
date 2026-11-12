using AutoMapper;
using BooksStore.Auth;
using BooksStore.Data;
using BooksStore.Models.DOTs;
using BooksStore.Models.Entities;
using BooksStore.Services.Inerfaces;

namespace BooksStore.Services;

public class CreateAcountService : ICreateAcountService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly AuthHelpers _helper;
    private readonly TokenService _tokenService;
    private readonly IUpdateRefreshTokenService _refreshService;
    public CreateAcountService(AppDbContext DB, IMapper mapper, AuthHelpers helpers, TokenService tokenService,  IUpdateRefreshTokenService RefreshService)
    {
        _context = DB;
        _mapper = mapper;
        _helper = helpers;
        _tokenService = tokenService;
        _refreshService = RefreshService;
    }


    public async Task<LogResponse> Create(NewUser NUser)
    {

        var Hashed = _helper.Hash(NUser.Password);
        var TheUser = _mapper.Map<User>(NUser);
        TheUser.HashedPassword = Hashed;
        _context.Users.Add(TheUser);
        await _context.SaveChangesAsync();
        var refresh = await _refreshService.AddRefreshToken(TheUser);
        var access = _tokenService.CreateToken(TheUser);
        return new LogResponse
        {
            AccessToken = access,
            RefreshToken = refresh 
        };
        
    }
}
