using Drill01.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill01.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students {get;set;}
    }
}