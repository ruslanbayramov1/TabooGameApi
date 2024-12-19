namespace TabooGameApi.Exceptions.Language;

public class LanguageNotFoundException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status404NotFound;
    public string ErrorMessage { get; }

    public LanguageNotFoundException()
    {
        ErrorMessage = "No language with given code";
    }

    public LanguageNotFoundException(string message)
    {
        ErrorMessage = message;
    }
}
