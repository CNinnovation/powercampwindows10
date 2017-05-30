using BooksLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IEnumerable<Book> GetBooks() => _books;
    }
}
