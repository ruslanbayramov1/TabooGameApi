using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Entities;
using TabooGameApi.Exceptions.Commons;
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
        await _isExists(dto.Language, dto.Text);

        await _isValid(dto.LevelId, dto.Language, dto.BannedWords.Count());

        var data = _mapper.Map<Word>(dto);
        await _context.Words.AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task CreateManyAsync(List<WordCreateDto> dtos)
    {
        var entities = _mapper.Map<List<Word>>(dtos);
        await _context.Words.AddRangeAsync(entities);
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
        var entities = await _context.Words.Include(x => x.BannedWords).Include(x => x.Level).ToListAsync();
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
        await _isValid(dto.LevelId, dto.Language, dto.BannedWords.Count());

        var entity = await _getById(id);
        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Word> _getById(int id)
    {
        var entity = await _context.Words.Include(x => x.BannedWords).FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new NotFoundException<Word>($"The word with id {id} not found");

        return entity;
    }

    private async Task _isExists(string lang, string text)
    {
        var res = await _context.Words.Include(x => x.Level).FirstOrDefaultAsync(x => x.LanguageCode == lang && x.Text == text);
        if (res != null) throw new DuplicateKeyException<Word>();
    }

    private async Task _isValid(int levelId, string lang, int banCount)
    {
        if (!(await _context.Levels.AnyAsync(x => x.Id == levelId)))
        {
            throw new NotFoundException<Level>();
        }

        if (!(await _context.Languages.AnyAsync(x => x.Code == lang)))
        {
            throw new NotFoundException<Language>();
        }

        var lev = await _context.Levels.FindAsync(levelId);
        if (lev?.BannedWordCount != banCount)
        {
            throw new Exception($"For level {lev?.Name}, banned word count must be {lev?.BannedWordCount}");
        }
    }
}
