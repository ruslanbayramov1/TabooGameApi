namespace TabooGameApi.Exceptions.Commons;

public class NotFoundException<TEntity> : Exception, IBaseException where TEntity : class, new()
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }

    public NotFoundException()
    {
        ErrorMessage = $"No {typeof(TEntity).Name.ToLower()} with given id";
    }

    public NotFoundException(string message)
    {
        ErrorMessage = message;
    }
}

public class NotFoundException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }

    public NotFoundException(string message)
    {
        ErrorMessage = message;
    }
}
