﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TabooGameApi.DAL;
using TabooGameApi.DTOs.Games;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Entities;
using TabooGameApi.Exceptions.Commons;
using TabooGameApi.Exceptions.Games;
using TabooGameApi.ExternalServices.Abstracts;
using TabooGameApi.Helpers;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Services.Implements;

public class GameService : IGameService
{
    private readonly IMapper _mapper;
    private readonly TabooDbContext _context;
    private readonly ICacheService _cacheService;
    public GameService(IMapper mapper, TabooDbContext context, ICacheService cacheService)
    {
        _context = context;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<Guid> CreateAsync(GameCreateDto dto)
    {
        await _isValid(dto.LevelId, dto.LanguageCode);

        var entity = _mapper.Map<Game>(dto);
        entity.TimeSecond = 120;

        await _context.Games.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<List<WordGetDto>> StartAsync(string id)
    {
        var entity = await _context.Games.FirstOrDefaultAsync(x => x.Id.ToString() == id && x.TimeSecond != 0);
        if (entity == null) throw new NotFoundException<Game>();

        var gameOpt = _mapper.Map<GameOptions>(entity);
        await _cacheService.Set(id, gameOpt, entity.TimeSecond);

        var wordEntity = await _context.Words
            .Include(x => x.Level)
            .Include(x => x.BannedWords)
            .Where(x => x.LanguageCode == entity.LanguageCode && x.LevelId == entity.LevelId)
            .Take(10).ToListAsync();

        var wordDto = _mapper.Map<List<WordGetDto>>(wordEntity);
        return wordDto;
    }

    public async Task<GameOptions> SkipAsync(string id)
    {
        var data = await _getCacheAsync<GameOptions>(id);
        if (data.SkipCount < 3)
        {
            data.SkipCount++;
        }
        else
        {
            throw new AllowedSkipLimitException();
        }
        await _setCacheAsync(id, data);

        return data;
    }

    public async Task<GameOptions> FailAsync(string id)
    {
        var data = await _getCacheAsync<GameOptions>(id);
        if (data.FailCount > 3)
        {
            if (data.SuccessAnswer > 1)
            { 
                data.SuccessAnswer--;
            }
        }
        data.FailCount++;

        await _setCacheAsync(id, data);

        return data;
    }

    public async Task<GameOptions> SuccessAsync(string id)
    {
        var data = await _getCacheAsync<GameOptions>(id);
        data.SuccessAnswer++;
        await _setCacheAsync(id, data);

        return data;
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

    private async Task<T> _getCacheAsync<T>(string key)
    {
        var data = await _cacheService.Get<T>(key);
        if (data == null) throw new NotFoundException("No data found in cache");

        return data;
    }
    private async Task _setCacheAsync<T>(string key, T gameOpt)
    {
        await _cacheService.Set(key, gameOpt);
    }
}