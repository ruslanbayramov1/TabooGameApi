using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.BannedWords;
using TabooGameApi.Entities;
using TabooGameApi.Exceptions.Commons;
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
        await _isExists(dto.Text, dto.WordId);

        var data = _mapper.Map<BannedWord>(dto);
        await _context.BannedWords.AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _getById(id);

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
        await _isExists(dto.Text, dto.WordId);
        
        var entity = await _getById(id);
        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
    }

    public async Task<BannedWord> _getById(int id)
    {
        var entity = await _context.BannedWords.FindAsync(id);
        if (entity == null) throw new NotFoundException<BannedWord>($"The language with id {id} not found");

        return entity;
    }

    public Task _isExists(string text, int wordId)
    {
        var res = _context.BannedWords.FirstOrDefault(x => x.WordId == wordId && x.Text == text);
        if (res != null) throw new DuplicateKeyException<BannedWord>();

        return Task.CompletedTask;
    }
}
