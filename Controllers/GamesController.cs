using Microsoft.AspNetCore.Mvc;
using TabooGameApi.DTOs.Games;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _service;
    public GamesController(IGameService service)
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
    public async Task<IActionResult> GetById(string id)
    {
        var data = await _service.GetByIdAsync(id);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(GameCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Created();
    }

    [HttpGet]
    [Route("/start/{id}")]
    public async Task<IActionResult> Start(string id)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(string id, GamePutDto dto)
    {
        await _service.PutAsync(id, dto);
        return Created();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
