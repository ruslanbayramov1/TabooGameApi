using TabooGameApi.Entities;

namespace TabooGameApi.Exceptions.Commons;

public class NotFoundException<T> : Exception, IBaseException where T : class, new()
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }

    public NotFoundException()
    {
        if (typeof(T) == typeof(Language))
            ErrorMessage = "No language with given code";
        else if (typeof(T) == typeof(BannedWord))
            ErrorMessage = "No banned word with given id";
        else if (typeof(T) == typeof(Word))
            ErrorMessage = "No word with given id";
    }

    public NotFoundException(string message)
    {
        ErrorMessage = message;
    }
}
