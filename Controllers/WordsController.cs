using Microsoft.AspNetCore.Mvc;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class WordsController : ControllerBase
{
    private readonly IWordService _wordService;
    public WordsController(IWordService wordService)
    {
        _wordService = wordService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _wordService.GetAllAsync();
        return Ok(data);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _wordService.GetByIdAsync(id);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(WordCreateDto dto)
    {
        await _wordService.CreateAsync(dto);
        return Created();
    }

    [HttpPost]
    [Route("PostMany")]
    public async Task<IActionResult> PostMany(List<WordCreateDto> dto)
    {
        await _wordService.CreateManyAsync(dto);
        return Created();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, WordPutDto dto)
    {
        await _wordService.PutAsync(id, dto);
        return Created();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _wordService.DeleteAsync(id);
        return NoContent();
    }
}
