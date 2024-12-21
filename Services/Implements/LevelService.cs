using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.Levels;
using TabooGameApi.Entities;
using TabooGameApi.Exceptions.Commons;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Services.Implements;

public class LevelService : ILevelService
{
    private readonly IMapper _mapper;
    private readonly TabooDbContext _context;
    public LevelService(IMapper mapper, TabooDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task CreateAsync(LevelCreateDto dto)
    {
        if (await _context.Levels.AnyAsync(x => x.Name == dto.Name))
        {
            throw new DuplicateKeyException<Level>();
        }

        var entity = _mapper.Map<Level>(dto);
        await _context.Levels.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _getById(id);
        _context.Levels.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<LevelGetDto>> GetAllAsync()
    {
        var entities = await _context.Levels.ToListAsync();
        var data = _mapper.Map<List<LevelGetDto>>(entities);
        return data;
    }

    public async Task<LevelGetDto> GetByIdAsync(int id)
    {
        var entity = await _getById(id);
        var data = _mapper.Map<LevelGetDto>(entity);
        return data;
    }

    public async Task PutAsync(int id, LevelPutDto dto)
    {
        var entity = await _getById(id);
        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
    }

    private async Task<Level> _getById(int id)
    {
        var entity = await _context.Levels.FindAsync(id);
        if (entity == null) throw new NotFoundException<Level>();
        return entity;
    }
}
