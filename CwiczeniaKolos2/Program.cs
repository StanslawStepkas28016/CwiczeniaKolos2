using Kolos2.Entities;
using Kolos2.Repositories;
using Kolos2.Services;
using Microsoft.EntityFrameworkCore;

namespace Kolos2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddScoped<IMuzykaRepository, MuzykaRepository>();
        builder.Services.AddScoped<IMuzykaService, MuzykaService>();

        builder.Services.AddDbContext<MuzykaContext>(opt =>
        {
            var connectionString = builder
                .Configuration
                .GetConnectionString("DefaultConnection");
            opt.UseSqlServer(connectionString);
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}