using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab03.Services;

namespace lab03.ViewModels
{
    public class BooksListViewModel
    {

        private ObservableCollection<CBook> _booksList;
        private IBooksService _booksService;
        private ISelectedBookService _selectedBookService;


        public BooksListViewModel(IBooksService booksService, ISelectedBookService selectedBookService)
        {
            _booksService = booksService;
            _selectedBookService = selectedBookService;

            fillList();
        }

        public IEnumerable<CBook> getBooks()
        {
            return _booksList;
        }

        private void fillList()
        {
            foreach (var book in _booksService.getBookList())
            {
                _booksList.Add(book);
            }
        }

        public CBook selectedBook { get => _selectedBookService.selectedBook; set => _selectedBookService.selectedBook = value; }
    }
}
