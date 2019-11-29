using DevTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTest
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        //public DbSet<Excecution> Excecutions { get; set; }
    }
}