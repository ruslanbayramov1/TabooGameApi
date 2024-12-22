using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.Games;
using TabooGameApi.Entities;
using TabooGameApi.Exceptions.Commons;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Services.Implements;

public class GameService : IGameService
{
    private readonly IMapper _mapper;
    private readonly TabooDbContext _context;
    private readonly IRedisService _redisService;
    public GameService(IMapper mapper, TabooDbContext context, IRedisService redisService)
    {
        _context = context;
        _mapper = mapper;
        _redisService = redisService;
    }

    public async Task CreateAsync(GameCreateDto dto)
    {
        await _isValid(dto.LevelId, dto.LanguageCode);

        var entity = _mapper.Map<Game>(dto);
        entity.TimeSecond = 120;

        await _context.Games.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await _getById(id);
        _context.Games.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<GameGetDto>> GetAllAsync()
    {
        var entites = await _context.Games.Include(x => x.Language).Include(x => x.Level).ToListAsync();
        var data = _mapper.Map<List<GameGetDto>>(entites);
        return data;
    }

    public async Task<GameGetDto> GetByIdAsync(string id)
    {
        var entity = await _getById(id);
        var data = _mapper.Map<GameGetDto>(entity);
        return data;
    }

    public async Task PutAsync(string id, GamePutDto dto)
    {
        await _isValid(dto.LevelId, dto.LanguageCode);

        var entity = await _getById(id);
        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
    }

    public async Task StartAsync(string id)
    {
        var entity = await _getById(id);
        await _redisService.SetAllAsync(id, entity);
    }

    private async Task<Game> _getById(string id)
    {
        var entity = await _context.Games.Include(x => x.Language).Include(x => x.Level).FirstOrDefaultAsync(x => x.Id.ToString() == id);
        if (entity == null) throw new NotFoundException<Game>();

        return entity;
    }

    private async Task _isValid(int levelId, string lang)
    {
        if (!(await _context.Levels.AnyAsync(x => x.Id == levelId)))
        {
            throw new NotFoundException<Level>();
        }

        if (!(await _context.Languages.AnyAsync(x => x.Code == lang)))
        {
            throw new NotFoundException<Language>();
        }
    }
}
