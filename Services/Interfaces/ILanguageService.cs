using TabooGameApi.DTOs.Languages;
using TabooGameApi.Entities;

namespace TabooGameApi.Services.Interfaces;

public interface ILanguageService
{
    Task<List<LanguageGetDto>> GetAllAsync();
    Task<LanguageGetDto> GetByCodeAsync(string code);
    Task CreateAsync(LanguageCreateDto dto);
    Task DeleteAsync(string code);
    Task PutAsync(string code, LanguagePutDto dto);
    Task<Language> _getByCode(string code);
}
