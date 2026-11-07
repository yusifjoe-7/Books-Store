namespace BooksStore.Errors.Exceptions;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(Guid ID) 
    : base($"Cann't found a Book With ID {ID}"){}
}
