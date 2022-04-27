using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace OOP_3.Models
{
    public class BookContext : DbContext, IBookContext //DbContext: определяет контекст данных, используемый для взаимодействия с базой данных
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
