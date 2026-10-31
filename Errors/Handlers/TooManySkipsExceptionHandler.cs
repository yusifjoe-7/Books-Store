using BooksStore.Errors.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Errors.Handlers;

public class TooManySkipsExceptionHandler
{
    public static ProblemDetails Handle(
       TooManySkipsException exception)
    {
        return new ProblemDetails
        {
            Status = 404,
            Title = "Book Not Found",
            Detail = exception.Message
        };
    }
}
