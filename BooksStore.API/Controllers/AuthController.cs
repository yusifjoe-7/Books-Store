using BooksStore.Data;
using BooksStore.Models.DOTs;
using BooksStore.Services.Inerfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers;

[ApiController]
[Route("/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("/signup")]
    public async Task<IActionResult> signup(ICreateAcountService service, [FromBody]NewUser user)
    {
        var result = await service.Create(user);
        return Ok(result);
    }
    

    [HttpPost("/refresh")]
    public async Task<IActionResult> Refresh(IRefreshService service, [FromBody]RefreshDots Dots)
    {
        var result = await service.Refresh(Dots.RefreshToken);

        if (result is null) return Unauthorized();

        return Ok(result);
        
    }
}
