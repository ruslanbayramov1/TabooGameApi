using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.BannedWords;
using TabooGameApi.Entities;
using TabooGameApi.Enums;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Services.Implements;

public class BannedWordService : IBannedWordService
{
    private readonly IMapper _mapper;
    private readonly TabooDbContext _context;
    public BannedWordService(IMapper mapper, TabooDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task CreateAsync(BannedWordCreateDto dto)
    {
        var data = _mapper.Map<BannedWord>(dto);
        await _context.BannedWords.AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _getById(id);

        if (await _context.BannedWords.CountAsync() == (int)GameLevels.Easy)
        {
            throw new Exception();
        }

        _context.BannedWords.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<BannedWordGetDto>> GetAllAsync()
    {
        var entities = await _context.BannedWords.ToListAsync();
        var data = _mapper.Map<List<BannedWordGetDto>>(entities);

        return data;
    }

    public async Task<BannedWordGetDto> GetByIdAsync(int id)
    {
        var entity = await _getById(id);
        var data = _mapper.Map<BannedWordGetDto>(entity);
        return data;
    }

    public async Task PutAsync(int id, BannedWordPutDto dto)
    {
        var entity = await _getById(id);
        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
    }

    public async Task<BannedWord> _getById(int id)
    {
        var entity = await _context.BannedWords.FindAsync(id);
        if (entity == null) throw new Exception();

        return entity;
    }
}
