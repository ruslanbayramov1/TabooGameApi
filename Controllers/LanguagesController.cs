using Microsoft.AspNetCore.Mvc;
using TabooGameApi.DTOs.Languages;
using TabooGameApi.Entities;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _langService;
    public LanguagesController(ILanguageService langService)
    {
        _langService = langService;
    }

    [HttpGet]
    public async Task<ActionResult<List<LanguageGetAllDto>>> GetAll()
    {
        var data = await _langService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> Create(LanguageCreateDto dto)
    {
        await _langService.CreateAsync(dto);
        return Created();
    }

    [HttpPut]
    [Route("{code}")]
    public async Task<ActionResult> Update(string code, LanguagePutDto dto)
    { 
        await _langService.PutAsync(code, dto);
        return Created();
    }

    [HttpDelete]
    [Route("{code}")]
    public async Task<ActionResult> Delete(string code)
    {
        await _langService.DeleteAsync(code);
        return NoContent();
    }
}
