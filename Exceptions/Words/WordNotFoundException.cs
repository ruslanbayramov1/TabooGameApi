namespace TabooGameApi.Exceptions.Words;

public class WordNotFoundException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage {  get; }

    public WordNotFoundException()
    {
        ErrorMessage = "The word with given id not found";
    }

    public WordNotFoundException(string message)
    {
        ErrorMessage = message; 
    }
}
