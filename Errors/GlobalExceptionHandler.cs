
using BooksStore.Errors.Exceptions;
using BooksStore.Errors.Handlers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Errors;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ProblemDetails problem = exception switch
        {
            BookNotFoundException ex =>
                BookNotFoundExceptionHandler.Handle(ex),

            TooManySkipsException ex =>
                TooManySkipsExceptionHandler.Handle(ex),

            _ => new ProblemDetails
            {
                Status = 500,
                Title = "Internal Server Error",
                Detail = "An unexpected error occurred."
            }
        };

        context.Response.StatusCode = problem.Status!.Value;

        await context.Response.WriteAsJsonAsync(
            problem,
            cancellationToken
        );

        return true;
    }
}