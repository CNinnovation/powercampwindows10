using BooksLib.Models;
using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TheBestMVVMFrameworkInTown;

namespace BooksLib.ViewModels
{
    public class BookDetailViewModel : ViewModelBase
    {
        private readonly ISelectedBookService _selectedBookService;
        public BookDetailViewModel(ISelectedBookService selectedBookService)
        {
            _selectedBookService = selectedBookService;
            _selectedBookService.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "SelectedBook")
                {
                    SelectedBook = _selectedBookService.SelectedBook;
                }
            };
        }

        private Book _selectedBook;

        public Book SelectedBook
        {
            get => _selectedBook;
            set => SetProperty(ref _selectedBook, value);
        }

    }
}
