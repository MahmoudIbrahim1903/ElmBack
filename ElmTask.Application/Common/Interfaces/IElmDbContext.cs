
using ElmTask.Domain.Entites.Book;
using Microsoft.EntityFrameworkCore;

namespace ElmTask.Application.Common.Interfaces
{
    public interface IElmDbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
