using AutoMapper;
using TabooGameApi.DTOs.BannedWords;
using TabooGameApi.Entities;

namespace TabooGameApi.Profiles;

public class BannedWordProfile : Profile
{
    public BannedWordProfile()
    {
        CreateMap<BannedWord, BannedWordGetDto>();
        CreateMap<BannedWordCreateDto, BannedWord>();
        CreateMap<BannedWordPutDto, BannedWord>();
    }
}
