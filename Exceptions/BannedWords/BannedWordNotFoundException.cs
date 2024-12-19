namespace TabooGameApi.Exceptions.BannedWords;

public class BannedWordNotFoundException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status404NotFound;
    public string ErrorMessage { get; }

    public BannedWordNotFoundException()
    {
        ErrorMessage = "No banned word with given id";
    }

    public BannedWordNotFoundException(string message)
    {
        ErrorMessage = message;
    }
}
