using TabooGameApi.Entities;

namespace TabooGameApi.Exceptions.Commons;

public class DuplicateKeyException<TEntity> : Exception, IBaseException where TEntity : IBaseEntity, new()
{
    public int StatusCode => StatusCodes.Status409Conflict;

    public string ErrorMessage { get; }

    public DuplicateKeyException()
    {
        ErrorMessage = $"The {typeof(TEntity).Name.ToLower()} already exists";
    }

    public DuplicateKeyException(string message)
    {
        ErrorMessage = message;
    }
}
