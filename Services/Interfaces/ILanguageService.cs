using TabooGameApi.DTOs.Languages;

namespace TabooGameApi.Services.Interfaces;

public interface ILanguageService
{
    Task<List<LanguageGetAllDto>> GetAllAsync();
    Task CreateAsync(LanguageCreateDto dto);
    Task DeleteAsync(string code);
    Task PutAsync(string code, LanguagePutDto dto);
}
