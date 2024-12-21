using TabooGameApi.Entities;
using TabooGameApi.Enums;

namespace TabooGameApi.Constants;

public class CustomResponse<TEntity> where TEntity : IBaseEntity, new()
{
    private string message { get; set; } = "";
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";

    public CustomResponse(DataStatus status)
    {
        StatusCode = status switch
        {
            DataStatus.Create =>  StatusCodes.Status201Created,
            DataStatus.Update => StatusCodes.Status201Created,
            DataStatus.Delete => StatusCodes.Status204NoContent,
            _ => StatusCodes.Status400BadRequest
        };

        Message = GetMessage(typeof(TEntity).Name, status);
    }

    public CustomResponse(int code, string message)
    {
        StatusCode = code;
        Message = message;
    }

    private string GetMessage(string dataName, DataStatus status)
    {
        message = status switch
        {
            DataStatus.Create => $"{dataName} successfully created!",
            DataStatus.Update => $"{dataName} successfully updated!",
            DataStatus.Delete => $"{dataName} successfully deleted!",
            _ => $"{dataName}: An unknown operation occurred."
        };

        return message;
    }
}
