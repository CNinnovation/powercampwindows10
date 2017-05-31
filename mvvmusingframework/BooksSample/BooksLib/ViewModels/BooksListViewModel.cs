using BooksLib.Events;
using BooksLib.Models;
using BooksLib.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BooksLib.ViewModels
{
    public class BooksListViewModel : BindableBase
    {
        private readonly ObservableCollection<Book> _books = new ObservableCollection<Book>();
        private readonly IBooksService _booksService;
        private readonly IMessageService _messageService;
        private readonly ISelectedBookService _selectedBookService;
        private readonly IEventAggregator _eventAggregator;
       

        public BooksListViewModel(IBooksService booksService, ISelectedBookService selectedBookService, IMessageService messageService, IEventAggregator eventAggregator)
        {
            _booksService = booksService;
            _messageService = messageService;
            _selectedBookService = selectedBookService;
            _eventAggregator = eventAggregator;

            ShowMessageCommand = new DelegateCommand(() => ShowMessage("command invoked"));

            InitializeBooks();
        }

        public ICommand ShowMessageCommand { get; }

        private void InitializeBooks()
        {
            var books = _booksService.GetBooks();
            foreach (var book in books)
            {
                _books.Add(book);
            }
        }

        public IEnumerable<Book> Books => _books;


        //public Book SelectedBook
        //{
        //    get => _selectedBookService.SelectedBook;
        //    set => _selectedBookService.SelectedBook = value;            
        //}

        private Book _selectedBook;

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (SetProperty(ref _selectedBook, value))
                {
                    _eventAggregator.GetEvent<BookInfoEvent>().Publish(_selectedBook);
                }
            }
        }

        public async void ShowMessage(string message)
        {
            await _messageService.ShowMessageAsync(message);
        }

    }
}
