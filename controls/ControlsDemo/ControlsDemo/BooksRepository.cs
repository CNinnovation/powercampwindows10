using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsDemo
{
    public class BooksRepository
    {
        private readonly List<Book> _books = new List<Book>();
        public BooksRepository()
        {
            _books.AddRange(new Book[]
            {
                new Book { Title = "Professional C# 6", Publisher = "Wrox Press"},
                new Book { Title = "Professional C# 5.0", Publisher = "Wrox Press"},
                new Book { Title = "Enterprise Services", Publisher = "Addison Wesley"},
            });
        }
        public IEnumerable<Book> GetBooks() => _books;
            
    }
}
