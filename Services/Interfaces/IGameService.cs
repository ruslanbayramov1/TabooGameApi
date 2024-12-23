using TabooGameApi.DTOs.Games;

namespace TabooGameApi.Services.Interfaces;

public interface IGameService
{
    Task<List<GameGetDto>> GetAllAsync();
    Task<GameGetDto> GetByIdAsync(string id);
    Task CreateAsync(GameCreateDto dto);
    Task PutAsync(string id, GamePutDto dto);
    Task DeleteAsync(string id);
}
