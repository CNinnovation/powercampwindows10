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
        }


        public Book SelectedBook
        {
            get => _selectedBookService.SelectedBook;
        }

    }
}
