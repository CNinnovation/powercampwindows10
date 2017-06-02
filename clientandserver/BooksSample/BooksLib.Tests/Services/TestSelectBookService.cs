using BooksLib.Services;
using BooksLib.Tests.Mocking;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BooksLib.Models;
using System.ComponentModel;

namespace BooksLib.Tests.Services
{
    public class TestSelectBookService
    {
        private SelectedBookService _selectedBookService;
        private MockBooksService _mockBooksService;

        public TestSelectBookService()
        {
            _selectedBookService = new SelectedBookService();
            _mockBooksService = new MockBooksService();
        }

        [Fact]
        public async Task Test()
        {
            // arrange
            Book b = (await _mockBooksService.GetBooksAsync()).First();

            // act and assert
            Assert.PropertyChanged(_selectedBookService, "SelectedBook", () =>
            {
                _selectedBookService.SelectedBook = b;
            });
        }
    }
}
