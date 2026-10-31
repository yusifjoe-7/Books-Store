namespace BooksStore.Errors.Exceptions;

public class TooManySkipsException : Exception
{
    public TooManySkipsException(int skips) 
    : base($"DataBase doesn't have enough Data to give you {skips} skips"){}
}
