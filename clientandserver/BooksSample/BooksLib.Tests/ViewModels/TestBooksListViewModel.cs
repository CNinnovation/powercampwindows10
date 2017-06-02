using BooksLib.Models;
using BooksLib.Tests.Mocking;
using BooksLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task TestBooks()
        {
            int expected = (await _booksService.GetBooksAsync()).Count();
            int numberbooks = _booksListViewModel.Books.Count();
            Assert.Equal(expected, numberbooks);
        }

        [Fact]
        public async Task TestSelectedBook()
        {
            Book selectBook = (await _booksService.GetBooksAsync()).Skip(1).First();
            _booksListViewModel.SelectedBook = selectBook;
            Assert.Equal(selectBook, _booksListViewModel.SelectedBook);
        }
    }
}
