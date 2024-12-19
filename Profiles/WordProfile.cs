using AutoMapper;
using TabooGameApi.DTOs.Words;
using TabooGameApi.Entities;

namespace TabooGameApi.Profiles;

public class WordProfile : Profile
{
    public WordProfile()
    {
        CreateMap<Word, WordGetDto>()
            .ForMember(d => d.Language, opt => opt.MapFrom(w => w.LanguageCode))
            .ForMember(d => d.BannedWords, w => w.MapFrom(t => t.BannedWords));

        CreateMap<WordCreateDto, Word>()
            .ForMember(w => w.LanguageCode, opt => opt.MapFrom(d => d.Language))
            .ForMember(w => w.Language, opt => opt.Ignore())
            .ForMember(w => w.BannedWords, opt => opt.MapFrom(d => d.BannedWords));

        CreateMap<WordPutDto, Word>()
            .ForMember(w => w.LanguageCode, opt => opt.MapFrom(d => d.Language))
            .ForMember(w => w.Language, opt => opt.Ignore())
            .ForMember(w => w.BannedWords, opt => opt.MapFrom(d => d.BannedWords));
    }
}
