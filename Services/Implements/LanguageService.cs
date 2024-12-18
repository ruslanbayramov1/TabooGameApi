using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.Languages;
using TabooGameApi.Entities;
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

    public async Task<List<LanguageGetDto>> GetAllAsync()
    {
        var entities = await _context.Languages.ToListAsync();
        var data = _mapper.Map<List<LanguageGetDto>>(entities);
        return data;
    }

    public async Task<LanguageGetDto> GetByIdAsync(string code)
    { 
        var entity = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
        if (entity == null) throw new Exception("No language with the code");

        var data = _mapper.Map<LanguageGetDto>(entity);
        return data;
    }

    public async Task CreateAsync(LanguageCreateDto dto)
    {
        var data = _mapper.Map<Language>(dto);
        await _context.Languages.AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string code)
    {
        var entity = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
        if (entity == null) throw new Exception("No language with the code");

        _context.Languages.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task PutAsync(string code, LanguagePutDto dto)
    {
        var entity = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
        if (entity == null) throw new Exception("No language with the code");

        var data = _mapper.Map<Language>(dto);
        
        entity.Name = data.Name;
        entity.Icon = data.Icon;

        await _context.SaveChangesAsync();
    }
}
