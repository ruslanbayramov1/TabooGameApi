using TabooGameApi.DTOs.BannedWords;
using TabooGameApi.Entities;

namespace TabooGameApi.Services.Interfaces;

public interface IBannedWordService
{
    Task<List<BannedWordGetDto>> GetAllAsync();
    Task<BannedWordGetDto> GetByIdAsync(int id);
    Task CreateAsync(BannedWordCreateDto dto);
    Task DeleteAsync(int id);
    Task PutAsync(int id, BannedWordPutDto dto);
    Task<BannedWord> _getById(int id);
    Task _isExists(string text, int id);
}
