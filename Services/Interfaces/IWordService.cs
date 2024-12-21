using TabooGameApi.DTOs.Words;

namespace TabooGameApi.Services.Interfaces;

public interface IWordService
{
    Task<List<WordGetDto>> GetAllAsync();
    Task<WordGetDto> GetByIdAsync(int id);
    Task CreateAsync(WordCreateDto dto);
    Task CreateManyAsync(List<WordCreateDto> dtos);
    Task DeleteAsync(int id);
    Task PutAsync(int id, WordPutDto dto);
}
