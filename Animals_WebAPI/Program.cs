using AnimalsAppLibrary.Abstractions;
using AnimalsAppLibrary.Data;
using AnimalsAppLibrary.Models;
using AnimalsAppLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Animals_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ConnectionStr");
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddScoped<IGenericRepository<Dog>, DogRepository>();
            builder.Services.AddScoped<IGenericRepository<Cat>, CatRepository>();
            builder.Services.AddScoped<IGenericRepository<Bird>, BirdRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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