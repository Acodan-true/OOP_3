using OOP_3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OOP_3.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task Post(Book book);
        Task Put(Book book);
        Task Delete(int id);

    }
}
