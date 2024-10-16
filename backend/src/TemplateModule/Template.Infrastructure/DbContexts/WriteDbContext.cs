using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Aggregate;

namespace Template.Infrastructure.DbContexts
{
    public class WriteDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public WriteDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Изменить способ конфигурации
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WriteDbContext).Assembly);
        }

        public DbSet<Librarian> Librarians { get; set; } = null!;
    }
}
