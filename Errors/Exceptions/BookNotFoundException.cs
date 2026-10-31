namespace BooksStore.Errors.Exceptions;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(int ID) 
    : base($"Cann't found a Book With ID {ID}"){}
}
