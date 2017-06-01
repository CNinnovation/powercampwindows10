using BooksLib.Models;
using BooksLib.Tests.Mocking;
using BooksLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BooksLib.Tests.ViewModels
{
    public class TestBooksListViewModel
    {
        private BooksListViewModel _booksListViewModel;
        private MockBooksService _booksService;

        public TestBooksListViewModel()
        {
            _booksService = new MockBooksService();
            _booksListViewModel = new BooksListViewModel(_booksService, new MockSelectedBookService(), null);
        }

        [Fact]
        public void TestBooks()
        {
            int expected = _booksService.GetBooks().Count();
            int numberbooks = _booksListViewModel.Books.Count();
            Assert.Equal(expected, numberbooks);
        }

        public void TestSelectedBook()
        {
            Book expectedBook = _booksService.GetBooks().Skip(1).First();
            _booksListViewModel.SelectedBook = 
        }
    }
}
