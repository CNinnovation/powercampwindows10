using BooksLib.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public class BooksService : IBooksService
    {
        private readonly List<Book> _books;
        public BooksService() =>
            _books = new List<Book>()
            {
                new Book {Title = "Professional C# 6", Publisher = "Wrox Press", Authors= new string[] { "Christian Nagel" } },
                new Book {Title = "Professional C# 5.0", Publisher = "Wrox Press", Authors = new string[] {"Christian Nagel", "Morgan Skinner", "Jay Glynn"} },
                new Book {Title = "Enterprise Services", Publisher = "Addison Wesley", Authors = new string[] {"Christian Nagel" } }
                
            };

        public Task<Book> AddBookAsync(Book book) => throw new NotImplementedException();

        public Task<IEnumerable<Book>> GetBooksAsync() => Task.FromResult<IEnumerable<Book>>(_books);
    }
}
