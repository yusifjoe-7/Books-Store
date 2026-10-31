using BooksStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    

    [HttpGet]
    public async Task<ActionResult> GetBooks( GetBooksService BookService, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        var data = await BookService.GetBooks(skip, take);
        
        return Ok(
            data
            );
    }

}
