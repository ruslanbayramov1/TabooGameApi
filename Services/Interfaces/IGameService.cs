using TabooGameApi.DTOs.Games;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Helpers;

namespace TabooGameApi.Services.Interfaces;

public interface IGameService
{
    Task<List<GameGetDto>> GetAllAsync();
    Task<GameGetDto> GetByIdAsync(string id);
    Task<Guid> CreateAsync(GameCreateDto dto);
    Task PutAsync(string id, GamePutDto dto);
    Task DeleteAsync(string id);
    Task<List<WordGetDto>> StartAsync(string id);
    Task<GameOptions> SkipAsync(string id);
    Task<GameOptions> FailAsync(string id);
    Task<GameOptions> SuccessAsync(string id);
}
