using AutoMapper;
using TabooGameApi.DTOs.Games;
using TabooGameApi.Entities;
using TabooGameApi.Helpers;

namespace TabooGameApi.Profiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, GameGetDto>();
        CreateMap<GameCreateDto, Game>();
        CreateMap<GamePutDto, Game>();
        CreateMap<Game, GameOptions>();
    }
}
