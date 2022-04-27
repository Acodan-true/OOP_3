using OOP_3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OOP_3.Repositories;

namespace OOP_3.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task Post(Book book);
        Task Put(Book book);
        Task Delete(int id);
    }
}
