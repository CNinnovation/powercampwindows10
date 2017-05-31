using System.Collections.Generic;
using BooksLib.Models;

namespace BooksLib.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks();
    }
}