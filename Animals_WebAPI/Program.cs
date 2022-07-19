using AnimalsClassLibrary.Abstractions;
using AnimalsClassLibrary.Data;
using AnimalsClassLibrary.Models;
using AnimalsClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using AnimalsClassLibrary;
using Serilog;


namespace Animals_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
          //  var logger1 =  new WriteLog();
            var builder = WebApplication.CreateBuilder(args);
            //try
            //{
                
                var logger= new LoggerConfiguration().ReadFrom.Configuration(
                builder.Configuration).Enrich.FromLogContext()
                .CreateLogger();
                builder.Logging.ClearProviders();
                builder.Logging.AddSerilog(logger);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
    

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ConnectionStr");
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(connectionString));

            try
            {
                logger.Information("Application is starting");
                
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

                logger.Information("Application started successfully");
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message, "Application failed to start");
            }
           
        }


    }
}