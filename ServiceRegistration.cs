using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using TabooGameApi.Enums;
using TabooGameApi.Exceptions;
using TabooGameApi.ExternalServices.Abstracts;
using TabooGameApi.ExternalServices.Concretes;
using TabooGameApi.Services.Implements;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(Program).Assembly);

        service.AddFluentValidationAutoValidation();
        service.AddValidatorsFromAssemblyContaining(typeof(Program));

        service.AddScoped<ILanguageService, LanguageService>();
        service.AddScoped<IWordService, WordService>();
        service.AddScoped<IBannedWordService, BannedWordService>();
        service.AddScoped<ILevelService, LevelService>();
        service.AddScoped<IGameService, GameService>();

        return service;
    }

    public static IServiceCollection AddCacheServices(this IServiceCollection service, IConfiguration _conf, CacheTypes type = CacheTypes.Redis)
    {
        if (type == CacheTypes.Redis)
        {
            var redisConnectionString = _conf.GetConnectionString("Redis");
            if (string.IsNullOrEmpty(redisConnectionString))
            {
                throw new InvalidOperationException("Redis connection string is not configured.");
            }

            service.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnectionString;
                options.InstanceName = "Tabu_";
            });

            service.AddScoped<ICacheService, RedisService>();
        }
        else
        {
            service.AddMemoryCache();
            service.AddScoped<ICacheService, LocalCacheService>();
        }

        return service;
    }

    public static IApplicationBuilder UseTabooExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(handler =>
        {
            handler.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerFeature>();
                Exception ex = feature!.Error;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                if (ex is IBaseException ibe)
                {
                    context.Response.StatusCode = ibe.StatusCode;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = ibe.StatusCode,
                        Message = ibe.ErrorMessage
                    });
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = ex.Message
                    });
                }
            });
        });

        return app;
    }

    public static IServiceCollection AddCors(this IServiceCollection service)
    {
        service.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
        });

        return service;
    }
}
