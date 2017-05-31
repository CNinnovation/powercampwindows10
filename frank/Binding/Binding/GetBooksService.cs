using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
    public class GetBooksService
    {
        List<Book> bookList = new List<Book>();

        public void AddBook(Book b)
        {
            bookList.Add(b);
        }
        public List<Book> GetBooks()
        {
            return bookList;
        }
    }
}
