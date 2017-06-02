using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using BooksLib.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLib.Tests.Mocking
{
    public class MockBooksService : IBooksService
    {
        public MockBooksService()
        {

        }

        public Task<Book> AddBookAsync(Book book) => throw new NotImplementedException();
        public Task<IEnumerable<Book>> GetBooksAsync() => Task.FromResult<IEnumerable<Book>>(
            Enumerable.Range(0, 5)
                .Select(i => new Book { Title = $"title {i}", Publisher = $"publisher {i}" })
                .ToList());

    }
}
