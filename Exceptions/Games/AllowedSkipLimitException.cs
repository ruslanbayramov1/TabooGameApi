namespace TabooGameApi.Exceptions.Games;

public class AllowedSkipLimitException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }

    public AllowedSkipLimitException()
    {
        ErrorMessage = "Currently at the maximum allowed limit of skip count.";
    }

    public AllowedSkipLimitException(string message)
    {
        ErrorMessage = message;
    }
}
