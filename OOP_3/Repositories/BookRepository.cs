using OOP_3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OOP_3.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookContext _bookContext;

        public BookRepository(IBookContext bookContext)
        {
            this._bookContext = bookContext; 
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookContext.Books.ToListAsync();
        }
        public async Task<Book> GetById(int id)
        {
            return await _bookContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Post(Book book)
        {
            await _bookContext.Books.AddAsync(book);
            await _bookContext.SaveChangesAsync();
        }
        public async Task Put(Book book)
        {
            var newBook = new Book { Id = book.Id };
            _bookContext.Attach(newBook);
            newBook.Title = book.Title;
            newBook.Author = book.Author;
            newBook.DatePublish = book.DatePublish;
            await _bookContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var book = new Book { Id = id };
            _bookContext.Books.Remove(book);
            await _bookContext.SaveChangesAsync();
        }
    }
}
