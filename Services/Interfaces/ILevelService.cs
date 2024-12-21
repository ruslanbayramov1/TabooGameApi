using TabooGameApi.DTOs.Levels;

namespace TabooGameApi.Services.Interfaces;

public interface ILevelService
{
    Task<List<LevelGetDto>> GetAllAsync();
    Task<LevelGetDto> GetByIdAsync(int id);
    Task CreateAsync(LevelCreateDto dto);
    Task PutAsync(int id, LevelPutDto dto);
    Task DeleteAsync(int id);
}
