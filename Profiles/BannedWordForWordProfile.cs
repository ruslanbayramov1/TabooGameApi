using AutoMapper;
using TabooGameApi.DTOs.BannedWordsForWords;
using TabooGameApi.Entities;

namespace TabooGameApi.Profiles;

public class BannedWordForWordProfile : Profile
{
    public BannedWordForWordProfile()
    {
        CreateMap<BannedWord, BannedWordForWordGetDto>();
        CreateMap<BannedWordForWordCreateDto, BannedWord>();
        CreateMap<BannedWordForWordPutDto, BannedWord>();
    }
}
