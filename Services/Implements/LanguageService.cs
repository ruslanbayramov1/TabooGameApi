using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.Languages;
using TabooGameApi.Entities;
using TabooGameApi.Exceptions.Language;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Services.Implements;

public class LanguageService : ILanguageService
{
    private readonly TabooDbContext _context;
    private readonly IMapper _mapper;
    public LanguageService(TabooDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateAsync(LanguageCreateDto dto)
    {
        var data = _mapper.Map<Language>(dto);
        await _context.Languages.AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string code)
    {
        var entity = await _getByCode(code);
        _context.Languages.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<LanguageGetDto>> GetAllAsync()
    {
        var entities = await _context.Languages.ToListAsync();
        var data = _mapper.Map<List<LanguageGetDto>>(entities);

        return data;
    }

    public async Task<LanguageGetDto> GetByCodeAsync(string code)
    {
        var entity = await _getByCode(code);
        var data = _mapper.Map<LanguageGetDto>(entity);

        return data;
    }

    public async Task PutAsync(string code, LanguagePutDto dto)
    {
        var entity = await _getByCode(code);
        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Language> _getByCode(string code)
    {
        var entity = await _context.Languages.FindAsync(code);
        if (entity == null) throw new LanguageNotFoundException($"The language with code {code} not found");

        return entity;
    }
}
