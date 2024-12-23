using Microsoft.AspNetCore.Mvc;
using TabooGameApi.DTOs.Languages;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _langService;
    public LanguagesController(ILanguageService languageService)
    {
        _langService = languageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _langService.GetAllAsync();
        return Ok(data);
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
        var data = await _langService.GetByCodeAsync(code);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(LanguageCreateDto dto)
    {
        await _langService.CreateAsync(dto);
        return Created();
    }

    [HttpPut]
    [Route("{code}")]
    public async Task<IActionResult> Put(string code, LanguagePutDto dto)
    {
        await _langService.PutAsync(code, dto);
        return Created();
    }

    [HttpDelete]
    [Route("{code}")]
    public async Task<IActionResult> Delete(string code)
    {
        await _langService.DeleteAsync(code);
        return NoContent();
    }
}
