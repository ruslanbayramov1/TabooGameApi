﻿using TabooGameApi.DTOs.Languages;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Entities;

namespace TabooGameApi.Services.Interfaces;

public interface IWordService
{
    Task<List<WordGetDto>> GetAllAsync();
    Task<WordGetDto> GetByIdAsync(int id);
    Task CreateAsync(WordCreateDto dto);
    Task DeleteAsync(int id);
    Task PutAsync(int id, WordPutDto dto);
    Task<Word> _getById(int id);
}