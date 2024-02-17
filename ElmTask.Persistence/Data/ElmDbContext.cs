using ElmTask.Application.Common.Interfaces;
using ElmTask.Domain.Entites;
using ElmTask.Domain.Entites.Book;
using ElmTask.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ElmTask.Persistence.Data
{
    public class ElmDbContext : DbContext, IElmDbContext
    {
        static Random _rand = new Random((int)DateTime.Now.Ticks);

        public ElmDbContext(DbContextOptions<ElmDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
        }

        public DbSet<Book> Books { get; set; }

        public Task<int> SaveChangesAsync()
                                => base.SaveChangesAsync();




    }
}
