using BooksStore.Models.DOTs;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult AddNew([FromBody] AddWriterRequest Writer)
    {

        return Ok();
    }
}
