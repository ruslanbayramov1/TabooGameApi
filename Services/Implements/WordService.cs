using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Entities;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Services.Implements;

public class WordService : IWordService
{
    private readonly IMapper _mapper;
    private readonly TabooDbContext _context;
    public WordService(IMapper mapper, TabooDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task CreateAsync(WordCreateDto dto)
    {
        var data = _mapper.Map<Word>(dto);
        await _context.Words.AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _getById(id);
        _context.Words.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<WordGetDto>> GetAllAsync()
    {
        var entities = await _context.Words.Include(x => x.BannedWords).ToListAsync();
        var data = _mapper.Map<List<WordGetDto>>(entities);
        return data;
    }

    public async Task<WordGetDto> GetByIdAsync(int id)
    {
        var entity = await _getById(id);
        var data = _mapper.Map<WordGetDto>(entity);
        return data;
    }

    public async Task PutAsync(int id, WordPutDto dto)
    {
        var entity = await _getById(id);
        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Word> _getById(int id)
    {
        var entity = await _context.Words.Include(x => x.BannedWords).FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new Exception("");

        return entity;
    }
}
