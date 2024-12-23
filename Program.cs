
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using TabooGameApi.DAL;

namespace TabooGameApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TabooDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Remote"));
            });

            // custom extension 
            builder.Services.AddServices();

            var app = builder.Build();

            // global error handler 
            app.UseTabooExceptionHandler();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
