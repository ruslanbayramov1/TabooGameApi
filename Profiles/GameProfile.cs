using AutoMapper;
using TabooGameApi.DTOs.Games;
using TabooGameApi.Entities;

namespace TabooGameApi.Profiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, GameGetDto>();
        CreateMap<GameCreateDto, Game>();
        CreateMap<GamePutDto, Game>();
    }
}
