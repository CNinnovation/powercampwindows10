using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03.Services
{
    public interface IBooksService
    {
        IEnumerable<CBook> getBookList();
    }


    public class BooksService : IBooksService
    {
        private readonly List<CBook> _books;

        public BooksService()
        {
            _books = new List<CBook>()
            {
                new CBook("Autor1", "Titel1"),
                new CBook("Autor2", "Titel2"),
                new CBook("Autor3", "Titel3")
            };
        }

        public IEnumerable<CBook> getBookList()
        {
            return _books;
        }


    }
}
