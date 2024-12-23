using Microsoft.AspNetCore.Mvc;
using TabooGameApi.DTOs.Levels;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LevelsController : ControllerBase
{
    private readonly ILevelService _service;
    public LevelsController(ILevelService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();
        return Ok(data);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _service.GetByIdAsync(id);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(LevelCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Created();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, LevelPutDto dto)
    {
        await _service.PutAsync(id, dto);
        return Created();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
