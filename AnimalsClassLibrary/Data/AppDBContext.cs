using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AnimalsClassLibrary.Models;

namespace AnimalsClassLibrary.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionStr"));
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
