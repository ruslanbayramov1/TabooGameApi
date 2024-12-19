using Microsoft.AspNetCore.Mvc;
using TabooGameApi.DTOs.BannedWords;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Services.Implements;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BannedWordsController : ControllerBase
{
    private readonly IBannedWordService _bannedWordService;
    public BannedWordsController(IBannedWordService bannedWordService)
    {
        _bannedWordService = bannedWordService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _bannedWordService.GetAllAsync();
        return Ok(data);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _bannedWordService.GetByIdAsync(id);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(BannedWordCreateDto dto)
    {
        await _bannedWordService.CreateAsync(dto);
        return Created();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, BannedWordPutDto dto)
    {
        await _bannedWordService.PutAsync(id, dto);
        return Created();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _bannedWordService.DeleteAsync(id);
        return NoContent();
    }
}
