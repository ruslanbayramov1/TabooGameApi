namespace TabooGameApi.Exceptions.Words;

public class BannedWordCountException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }

    public BannedWordCountException()
    {
        ErrorMessage = "The allowed limit of count violation. Too big or less.";
    }

    public BannedWordCountException(string message)
    {
        ErrorMessage = message;
    }
}
