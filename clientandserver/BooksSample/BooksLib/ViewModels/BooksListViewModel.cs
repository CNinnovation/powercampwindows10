using BooksLib.Models;
using BooksLib.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheBestMVVMFrameworkInTown;

namespace BooksLib.ViewModels
{
    public class BooksListViewModel
    {
        private readonly ObservableCollection<Book> _books = new ObservableCollection<Book>();
        private readonly IBooksService _booksService;
        private readonly IMessageService _messageService;
        private readonly ISelectedBookService _selectedBookService;
       

        public BooksListViewModel(IBooksService booksService, ISelectedBookService selectedBookService, IMessageService messageService)
        {
            _booksService = booksService;
            _messageService = messageService;
            _selectedBookService = selectedBookService;

            ShowMessageCommand = new DelegateCommand(() => ShowMessage("command invoked"));
            AddBookCommand = new DelegateCommand(AddTestBook);
            InitializeBooks();
        }

        public ICommand ShowMessageCommand { get; }

        public ICommand AddBookCommand { get; }

        private async void InitializeBooks()
        {
            var books = await _booksService.GetBooksAsync();
            foreach (var book in books)
            {
                _books.Add(book);
            }
        }

        public async void AddTestBook()
        {
            await _booksService.AddBookAsync(new Book { Title = "Professional C# 8.0", Publisher = "Wrox Press" });
        }

        public IEnumerable<Book> Books => _books;


        public Book SelectedBook
        {
            get => _selectedBookService.SelectedBook;
            set => _selectedBookService.SelectedBook = value;            
        }

        public async void ShowMessage(string message)
        {
            await _messageService.ShowMessageAsync(message);
        }

    }
}
