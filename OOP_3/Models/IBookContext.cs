using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OOP_3.Models
{
    public interface IBookContext
    {
        public DbSet<Book> Books { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
