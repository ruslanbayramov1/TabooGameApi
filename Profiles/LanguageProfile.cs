using AutoMapper;
using TabooGameApi.DTOs.Languages;
using TabooGameApi.Entities;

namespace TabooGameApi.Profiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<LanguageCreateDto, Language>()
            .ForMember(l => l.Icon, opt => opt.MapFrom(d => d.IconUrl));

        CreateMap<Language, LanguageGetDto>()
            .ForMember(d => d.IconUrl, opt => opt.MapFrom(l => l.Icon))
            .ReverseMap();

        CreateMap<LanguagePutDto, Language>()
            .ForMember(l => l.Icon, opt => opt.MapFrom(d => d.IconUrl));
    }
}
