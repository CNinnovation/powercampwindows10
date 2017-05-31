using BooksLib.Events;
using BooksLib.Models;
using BooksLib.Services;
using Prism.Events;
using Prism.Mvvm;

namespace BooksLib.ViewModels
{
    public class BookDetailViewModel : BindableBase
    {
        private readonly ISelectedBookService _selectedBookService;
        private readonly IEventAggregator _eventAggregator;
        public BookDetailViewModel(ISelectedBookService selectedBookService, IEventAggregator eventAggregator)
        {
            _selectedBookService = selectedBookService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<BookInfoEvent>().Subscribe(b =>
            {
                SelectedBook = b;
            });
        }

        private Book _selectedBook;

        public Book SelectedBook
        {
            get => _selectedBook;
            set => SetProperty(ref _selectedBook, value);
        }


        // public ISelectedBookService SelectedBookService => _selectedBookService;
    }
}
