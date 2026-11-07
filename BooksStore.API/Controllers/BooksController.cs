using BooksStore.Services.Inerfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    

    [HttpGet]
    public async Task<ActionResult> GetBooks( IGetBooksService BookService, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        take = Math.Clamp(take, 0, 100);
        skip = Math.Max(1, skip);
        var data = await BookService.GetBooks(skip, take);

        return Ok(
            data
            );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetABook(Guid Id, IGetBooksService service)
    {
        var book = await service.GetABook(Id);

        return Ok(book);
    }
}
