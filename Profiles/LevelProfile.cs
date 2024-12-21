using AutoMapper;
using TabooGameApi.DTOs.Levels;
using TabooGameApi.Entities;

namespace TabooGameApi.Profiles;

public class LevelProfile : Profile
{
    public LevelProfile()
    {
        CreateMap<Level, LevelGetDto>();
        CreateMap<LevelCreateDto, Level>();
        CreateMap<LevelPutDto, Level>();
    }
}
