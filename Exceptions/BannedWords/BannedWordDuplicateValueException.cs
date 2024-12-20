namespace TabooGameApi.Exceptions.BannedWords;

public class BannedWordDuplicateValueException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status409Conflict;

    public string ErrorMessage { get; }

    public BannedWordDuplicateValueException()
    {
        ErrorMessage = "The word with same name and word id already exists";
    }

    public BannedWordDuplicateValueException(string message)
    {
        ErrorMessage = message;
    }
}
