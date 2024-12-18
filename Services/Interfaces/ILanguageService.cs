using TabooGameApi.DTOs.Languages;

namespace TabooGameApi.Services.Interfaces;

public interface ILanguageService
{
    Task<List<LanguageGetDto>> GetAllAsync();
    Task<LanguageGetDto> GetByIdAsync(string code);
    Task CreateAsync(LanguageCreateDto dto);
    Task DeleteAsync(string code);
    Task PutAsync(string code, LanguagePutDto dto);
}
