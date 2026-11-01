using BooksStore.Data;
using BooksStore.Models.DOTs;
using BooksStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers;

[ApiController]
[Route("/[controller]")]
public class WritersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] AddWriterRequest Writer, AddWriterService service)
    {
        await service.Add(Writer);

        return Ok();
    }
}
