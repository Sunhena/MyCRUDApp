using Microsoft.EntityFrameworkCore;
using MyCrudAPP.Models;

namespace MyCrudAPP.Services
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        { 
        }
        public DbSet<Items> Items { get; set; }

    }
}
