using TabooGameApi.Entities;

namespace TabooGameApi.Exceptions.Commons;

public class DuplicateKeyException<T> : Exception, IBaseException where T : class, new()
{
    public int StatusCode => StatusCodes.Status409Conflict;

    public string ErrorMessage { get; }

    public DuplicateKeyException()
    {
        if (typeof(T) == typeof(Language))
            ErrorMessage = "The code already exists";
        else if (typeof(T) == typeof(BannedWord))
            ErrorMessage = "The banned word with same name and word id already exists";
        else if (typeof(T) == typeof(Word))
            ErrorMessage = "The word with same name and country code already exists";
    }

    public DuplicateKeyException(string message)
    {
        ErrorMessage = message;
    }
}
