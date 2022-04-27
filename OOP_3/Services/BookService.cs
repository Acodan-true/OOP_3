using OOP_3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OOP_3.Repositories;

namespace OOP_3.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;  
        }
        public async Task<Book> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }
        public async Task Post(Book book)
        {
            await _bookRepository.Post(book);
        }
        public async Task Put(Book book)
        {
            await _bookRepository.Put(book);
        }
        public async Task Delete(int id)
        {
            await _bookRepository.Delete(id);
        }
    }
}
