using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using BooksLib.Models;
using System.Linq;

namespace BooksLib.Tests.Mocking
{
    public class MockBooksService : IBooksService
    {
        public MockBooksService()
        {

        }

        private IEnumerable<Book>
        public IEnumerable<Book> GetBooks() => Enumerable.Range(0, 5)
            .Select(i => new Book { Title = $"title {i}", Publisher = $"publisher {i}" })
            .ToList();
    }
}
