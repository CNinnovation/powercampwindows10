using System.Collections.Generic;
using BooksLib.Models;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> AddBookAsync(Book book);
    }
}