using FluentValidation;
using FluentValidation.AspNetCore;
using TabooGameApi.Services.Implements;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(Program).Assembly);

        service.AddFluentValidationAutoValidation();
        service.AddValidatorsFromAssemblyContaining(typeof(Program));

        service.AddScoped<ILanguageService, LanguageService>();
        service.AddScoped<IWordService, WordService>();
        service.AddScoped<IBannedWordService, BannedWordService>();
        service.AddScoped<ILevelService, LevelService>();
    }
}
