using AutoMapper;
using TabooGameApi.DTOs.Languages;
using TabooGameApi.Entities;

namespace TabooGameApi.Profiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<LanguageCreateDto, Language>().ForMember(l => l.Icon, d => d.MapFrom(t => t.IconUrl));
        CreateMap<Language, LanguageGetAllDto>().ForMember(d => d.IconUrl, l => l.MapFrom(t => t.Icon));
        CreateMap<LanguagePutDto, Language>().ForMember(l => l.Icon, d => d.MapFrom(t => t.IconUrl));
    }
}
