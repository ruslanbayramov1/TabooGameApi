namespace TabooGameApi.Exceptions.Words;

public class WordDuplicateValueException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status409Conflict;

    public string ErrorMessage { get; }

    public WordDuplicateValueException()
    {
        ErrorMessage = "The word with same name and country code already exists";
    }

    public WordDuplicateValueException(string message)
    {
        ErrorMessage = message;
    }
}
